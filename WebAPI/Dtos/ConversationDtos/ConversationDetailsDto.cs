using System;
using System.Collections.Generic;

namespace WebAPI.Dtos.ConversationDtos
{
    public class ConversationDetailsDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; }

        // Ekstra propertiler isterler için 
        public int MessageCount { get; set; } // O odada toplam kaç mesaj var?
        public List<string>? Participants { get; set; } // O odada kimler konuşmuş? 
    }
}