using System.Collections.Generic;
using WebAPI.Entities.Concrete;

namespace WebAPI.Business.Abstract
{
    public interface IConversationService
    {
        void Add(Conversation conversation);
        List<Conversation> GetAll();
        Conversation GetById(int id);  // metot conversation manager için 
    }
}