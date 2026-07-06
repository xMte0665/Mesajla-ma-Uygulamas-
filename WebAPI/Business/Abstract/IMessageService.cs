using System.Collections.Generic;
using WebAPI.Entities.Concrete;

namespace WebAPI.Business.Abstract
{
    public interface IMessageService
    {
        void Add(Message message);

        // Belirli bir sohbete ait mesajları listeleme
        List<Message> GetMessagesByConversationId(int conversationId); // metot message manager için
    }
}