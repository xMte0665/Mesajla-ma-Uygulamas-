using System;
using System.Collections.Generic;
using WebAPI.Business.Abstract;
using WebAPI.DataAccess.Abstract;
using WebAPI.Entities.Concrete;

namespace WebAPI.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;  // readonaly program boyucna değişmez özelliği verir güvenlik için
        private readonly IConversationService _conversationService; // mesaj kısmı conversationa bağımlıdır o yüzden bunu da yazarız

        // Constructor Injection (Dependency Injection)
        public MessageManager(IMessageDal messageDal, IConversationService conversationService)
        {
            _messageDal = messageDal;
            _conversationService = conversationService;
        }

        public void Add(Message message)
        {
            // Gönderen (Sender) ismi boş olamaz
            if (string.IsNullOrWhiteSpace(message.Sender))
            {
                throw new Exception("Kullanici adi (gönderen) boş olamaz!");
            }

            // Mesaj içeriği (Content) boş olamaz 
            if (string.IsNullOrWhiteSpace(message.Content))
            {
                throw new Exception("Boş bir mesaj gönderemezsiniz!");
            }

            // Mesaj atılmak istenen sohbet odası gerçekten var mı?
            // Var olmayan bir sohbete işlem yapılmaya çalışıldığında exception
            var conversationExists = _conversationService.GetById(message.ConversationId);
            if (conversationExists == null)
            {
                throw new Exception("Geçersiz işlem! Mesaj göndermeye çaliştiğiniz sohbet odasi silinmiş veya hiç var olmamiş.");
            }

            // Bütün güvenlik duvarlarından geçtiyse, saati bas ve veritabanına yolla.
            message.CreatedAt = DateTime.UtcNow;
            _messageDal.Add(message);
        }

        public List<Message> GetMessagesByConversationId(int conversationId)
        {
            // Önce böyle bir oda var mı diye kontrol edelim
            _conversationService.GetById(conversationId); // Yoksa zaten Exception fırlatacak

            // Varsa o odaya ait mesajları iste gelsin
            return _messageDal.GetAll(m => m.ConversationId == conversationId);
        }
    }
}