using WebAPI.Entities.Abstract;

namespace WebAPI.Entities.Concrete
{
    public class Message : BaseEntity
    {
        public int ConversationId { get; set; }  // ilişkili sohbet id

        public string? Sender { get; set; }   // kullanıcı girişi sistemi olmadığından dolayı string yapıyoruz 

        public string? Content { get; set; }  // mesaj içeriği 

        // hangi sohbete ait olduğunu bulmak için
        public Conversation Conversation { get; set; } = null!;   // null ile boş değer olmıyacak halletcez demek için koyuyuyoruz bunu
    }
}