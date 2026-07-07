using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebAPI.Business.Abstract;
using SharedModels;
using WebAPI.Entities.Concrete;

namespace WebAPI.Controllers
{
    [ApiController]  // hazır controller şablonu aşağıda kendi claslarıma göre düzenlenecek
    [Route("api/[controller]")]
    public class ConversationsController : ControllerBase
    {
        private readonly IConversationService _conversationService;
        private readonly IMessageService _messageService;

        // Hem sohbetleri hem de detay için mesajları yönetecek servisleri yani bağımlılıkları (injection) çağırıyoruz
        public ConversationsController(IConversationService conversationService, IMessageService messageService)
        {
            _conversationService = conversationService;
            _messageService = messageService;
        }

        [HttpPost]   // dışarıdan veri gönderiliyor kayıt ekleniyor. hazır metot sunucuya veri gönderme işlemi için post kullanılır. get ile veri çekilir.
        public IActionResult Create(CreateConversationRequestDto dto)
        {
            try
            {
                var conversation = new Conversation
                {
                    Title = dto.Title
                };

                _conversationService.Add(conversation);
                return Ok("Sohbet odasi başariyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Kural ihlali varsa 400 Bad Request döndürür
            }
        }

        [HttpGet]  // hazır metot sunucudan veri çekeriz
        public IActionResult GetAll()
        {
            var conversations = _conversationService.GetAll();

            // her dto clasını aracı yaparak sunucuya gönderiyoruz. 
            var responseList = conversations.Select(c => new ConversationResponseDto
            {
                Id = c.Id,
                Title = c.Title,
                CreatedAt = c.CreatedAt
            }).ToList();

            return Ok(responseList);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            try
            {
                var conversation = _conversationService.GetById(id);
                var messages = _messageService.GetMessagesByConversationId(id);

                // Detayları burada hesaplıyoruz.
                var detailsDto = new ConversationDetailsDto
                {
                    Id = conversation.Id,
                    Title = conversation.Title,
                    CreatedAt = conversation.CreatedAt,
                    MessageCount = messages.Count,
                    // Sadece o odadaki benzersiz gönderici isimlerini listeliyoruz  // distinc aynı olanları siler hazır metot
                    Participants = messages.Select(m => m.Sender!).Distinct().ToList()
                };

                return Ok(detailsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}