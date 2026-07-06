using System;

namespace WebAPI.Dtos.ConversationDtos
{
    public class ConversationResponseDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}