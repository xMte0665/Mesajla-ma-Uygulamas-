using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SharedModels; // Kuryeye yeni çadırın adresini verdik

namespace ConsoleClient
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5211/api/") };
        }

        public async Task<List<ConversationResponseDto>> GetConversationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ConversationResponseDto>>("Conversations") ?? new List<ConversationResponseDto>();
        }

        public async Task CreateConversationAsync(string title)
        {
            var req = new CreateConversationRequestDto { Title = title };
            await _httpClient.PostAsJsonAsync("Conversations", req);
        }

        public async Task<List<MessageResponseDto>> GetMessagesAsync(int conversationId)
        {
            return await _httpClient.GetFromJsonAsync<List<MessageResponseDto>>($"Messages/{conversationId}") ?? new List<MessageResponseDto>();
        }

        public async Task SendMessageAsync(int conversationId, string sender, string content)
        {
            var req = new SendMessageDto { ConversationId = conversationId, Sender = sender, Content = content };
            await _httpClient.PostAsJsonAsync("Messages", req);
        }
    }
}