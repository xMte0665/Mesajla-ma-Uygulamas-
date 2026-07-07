using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;  

namespace ConsoleClient
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            // buraya webapıde çalışan portun adresini yazarız
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5211/api/") };
        }
        // tüm sınıflar için bu kalıbı yazar içini doldururuz
        public async Task<List<ConversationResponse>> GetConversationsAsync()  // async task internet üzerinden çalışacak uzun sürecek işlemlerde hazır mmetot
        {
            return await _httpClient.GetFromJsonAsync<List<ConversationResponse>>("Conversations") ?? new List<ConversationResponse>(); // await de işlem bitene kadar bekleten hazır metot 
        }

        public async Task CreateConversationAsync(string title)
        {
            var req = new { Title = title };
            await _httpClient.PostAsJsonAsync("Conversations", req);
        }

        public async Task<List<MessageResponse>> GetMessagesAsync(int conversationId)
        {
            return await _httpClient.GetFromJsonAsync<List<MessageResponse>>($"Messages/{conversationId}") ?? new List<MessageResponse>();
        }

        public async Task SendMessageAsync(int conversationId, string sender, string content)
        {
            var req = new { ConversationId = conversationId, Sender = sender, Content = content };
            await _httpClient.PostAsJsonAsync("Messages", req);
        }
    }

    // Client'ın API'den gelen verileri karşılayabilmesi için  DTO kopyaları
    public class ConversationResponse { public int Id { get; set; } public string? Title { get; set; } }
    public class MessageResponse { public string? Sender { get; set; } public string? Content { get; set; } public DateTime CreatedAt { get; set; } }
}