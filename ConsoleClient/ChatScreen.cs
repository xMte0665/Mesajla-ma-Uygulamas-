using System;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class ChatScreen
    {
        private readonly ApiService _apiService;
        private readonly int _roomId;
        private readonly string _username;
        private bool _isChatting = true;
        private int _lastMessageCount = 0;

        public ChatScreen(ApiService apiService, int roomId, string username)
        {
            _apiService = apiService;
            _roomId = roomId;
            _username = username;
        }

        public async Task StartChatAsync()
        {
            Console.Clear();
            Console.WriteLine($"Odaya bağlandiniz. Çikmak için 'quit' yazin.\n");

            // Polling işlemini arka planda farklı bir thread'de başlatıyoruz.
            var pollTask = Task.Run(() => PollMessagesAsync());

            // Ön planda ise sürekli kullanıcının mesaj yazmasını bekliyoruz.
            while (_isChatting)
            {
                var input = Console.ReadLine();

                if (input == "quit")
                {
                    _isChatting = false;
                    break;
                }

                // Sadece gerçekten dolu bir mesaj yazılırsa ekranı temizle ve gönder!
                if (!string.IsNullOrWhiteSpace(input))
                {
                    // Yazdığın ham metni sil 
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    await _apiService.SendMessageAsync(_roomId, _username, input);
                }
            }
        }

        // POLLING MEKANİZMASI
        private async Task PollMessagesAsync()
        {
            while (_isChatting)
            {
                try
                {
                    var messages = await _apiService.GetMessagesAsync(_roomId);

                    // Sadece yeni bir mesaj eklendiyse ekranı güncelle
                    if (messages.Count > _lastMessageCount)
                    {
                        for (int i = _lastMessageCount; i < messages.Count; i++)
                        {
                            var msg = messages[i];
                            // Gönderen sen isen rengi ve başlığı farklı bas
                            if (msg.Sender == _username)
                                Console.WriteLine($"[Sen] {msg.CreatedAt:HH:mm}: {msg.Content}");
                            else
                                Console.WriteLine($"[{msg.Sender}] {msg.CreatedAt:HH:mm}: {msg.Content}");
                        }
                        _lastMessageCount = messages.Count; // Sayacı güncelle
                    }
                }
                catch
                {
                    // Eğer 1 saniyeliğine API çökerse konsol patlamasın diye sessizce yutuyoruz.
                }

                // 1 Saniye bekle ve tekrar istek at 
                await Task.Delay(1000);
            }
        }
    }
}