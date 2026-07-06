using System;

namespace WebAPI.Dtos.MessageDtos
{
    public class MessageResponseDto
    {
        public int Id { get; set; }
        public int ConversationId { get; set; }
        public string? Sender { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } // Mesajın atıldığı saat
    }
}