using System.Collections.Generic;
using WebAPI.Entities.Abstract; // BaseEntity'yi tanıması için adresini verdik bunu tüm claslarda yapacağız

namespace WebAPI.Entities.Concrete
{
    public class Conversation : BaseEntity
    {
        public string? Title { get; set; }  // boş kalabilir diye ? koyduk c# da olan null değerden oluşan hataları önlemek için bunu da çoğu yerde kullanıcaz bu projede 

        public List<Message> Messages { get; set; } // bir sohbette birden fazla mesaj olabilir. liste tanımladık

        // Sınıf oluşturuken boş değer dönmesin diye consturcor ile boş conversation oluştururuz.
        public Conversation() // constructor tanımladık
        {
            Messages = new List<Message>();
        }
    }
}