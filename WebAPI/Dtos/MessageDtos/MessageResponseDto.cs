namespace WebAPI.Dtos.MessageDtos
{
    public class SendMessageDto
    {
        public int ConversationId { get; set; } // Hangi odaya atıyor?
        public string? Sender { get; set; }      // Kim atıyor?
        public string? Content { get; set; }     // Ne diyor?
    }
}