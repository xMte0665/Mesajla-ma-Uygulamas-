using System;
using System.Collections.Generic;
using WebAPI.Business.Abstract;
using WebAPI.DataAccess.Abstract;
using WebAPI.Entities.Concrete;

namespace WebAPI.Business.Concrete
{
    public class ConversationManager : IConversationService
    {
        // Yöneticinin emrindeki DataAccess işçisi
        private readonly IConversationDal _conversationDal;  // readonaly program boyucna değişmez özelliği verir güvenlik için 

        // Constructor Injection (Dependency Injection)
        public ConversationManager(IConversationDal conversationDal)
        {
            _conversationDal = conversationDal;
        }

        public void Add(Conversation conversation)
        {
            // Sohbet başlığı boş olamaz!
            if (string.IsNullOrWhiteSpace(conversation.Title))
            {
                throw new Exception("Sohbet basliği boş birakilamaz!");
            }

            // Sohbet başlığı en az 3 karakter olmalı!
            if (conversation.Title.Length < 3)
            {
                throw new Exception("Sohbet başliği en az 3 karakter olmalidir!");
            }

            // Kurallardan geçtiyse, saati şu anki saat yap ve işçiye "Kaydet" emri ver.
            conversation.CreatedAt = DateTime.UtcNow;
            _conversationDal.Add(conversation);
        }

        public List<Conversation> GetAll()
        {
            // Ekstra bir kurala gerek yok, işçiye "Hepsini getir" de.
            return _conversationDal.GetAll();
        }

        public Conversation GetById(int id)
        {
            var conversation = _conversationDal.Get(c => c.Id == id);  // id uyuyorsa o sohbeti getir, yoksa null döndürür. bu kalıp if else ten kurturlmak içindir

            // Eğer aranan oda veritabanında yoksa, sistemi çökertmek yerine bilgi ver.
            if (conversation == null)
            {
                throw new Exception("Böyle bir sohbet odasi bulunamadi!");
            }

            return conversation;
        }
    }
}