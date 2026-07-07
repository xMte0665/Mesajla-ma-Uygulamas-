using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebAPI.Business.Abstract;
using SharedModels;
using WebAPI.Entities.Concrete;

namespace WebAPI.Controllers
{
    [ApiController]     // nerdeyse conversation clasının aynısı sadece burda ihtiyaç olmadığı için conversation clasını injection yapmadık.
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult Send(SendMessageDto dto)
        {
            try
            {
                var message = new Message
                {
                    ConversationId = dto.ConversationId,
                    Sender = dto.Sender,
                    Content = dto.Content
                };

                _messageService.Add(message);
                return Ok("Mesaj gönderildi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{conversationId}")]
        public IActionResult GetByConversation(int conversationId)
        {
            try
            {
                var messages = _messageService.GetMessagesByConversationId(conversationId);

                var responseList = messages.Select(m => new MessageResponseDto
                {
                    Id = m.Id,
                    ConversationId = m.ConversationId,
                    Sender = m.Sender,
                    Content = m.Content,
                    CreatedAt = m.CreatedAt
                }).ToList();

                return Ok(responseList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}