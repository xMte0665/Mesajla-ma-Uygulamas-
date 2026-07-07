using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedModels
{
    public class ConversationDetailsDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MessageCount { get; set; }
        public List<string>? Participants { get; set; }
    }

    public class ConversationResponseDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateConversationRequestDto
    {
        [Required(ErrorMessage = "Oda adı boş bırakılamaz!")]
        public string? Title { get; set; }
    }

    public class SendMessageDto
    {
        [Required(ErrorMessage = "Oda ID'si zorunludur!")]
        public int ConversationId { get; set; }

        [Required(ErrorMessage = "Gönderen adı boş olamaz!")]
        public string? Sender { get; set; }

        [Required(ErrorMessage = "Mesaj içeriği boş olamaz!")]
        public string? Content { get; set; }
    }

    public class MessageResponseDto
    {
        public int Id { get; set; }
        public int ConversationId { get; set; }
        public string? Sender { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}