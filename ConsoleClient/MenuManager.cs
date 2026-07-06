using System;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class MenuManager
    {
        private readonly ApiService _apiService;
        public string CurrentUser { get; private set; } = string.Empty;

        public MenuManager(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task StartAsync()
        {
            Console.Clear();
            Console.Write("Kullanici Adinizi Girin: ");
            CurrentUser = Console.ReadLine() ?? "Anonim";

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"--- HOŞ GELDİN {CurrentUser.ToUpper()} ---");
                Console.WriteLine("1. Sohbet Odalarini Listele ve Katil");
                Console.WriteLine("2. Yeni Sohbet Odasi Kur");
                Console.WriteLine("3. Çikiş");
                Console.Write("\nSeçiminiz: ");
                var choice = Console.ReadLine();

                if (choice == "1") await ListAndJoinRoomAsync();
                else if (choice == "2") await CreateRoomAsync();
                else if (choice == "3") break;
            }
        }

        private async Task ListAndJoinRoomAsync()
        {
            var rooms = await _apiService.GetConversationsAsync();
            Console.WriteLine("\n--- AKTİF ODALAR ---");
            foreach (var room in rooms)
            {
                Console.WriteLine($"[{room.Id}] {room.Title}");
            }
            Console.Write("\nKatilmak istediğiniz odanin ID'sini yazin (İptal için enter): ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out int roomId))
            {
                var chatScreen = new ChatScreen(_apiService, roomId, CurrentUser);
                await chatScreen.StartChatAsync();
            }
        }

        private async Task CreateRoomAsync()
        {
            Console.Write("Yeni Odanin Adi: ");
            var title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                await _apiService.CreateConversationAsync(title);
                Console.WriteLine("Oda başariyla kuruldu! Devam etmek için bir tuşa basin...");
            }
            Console.ReadKey();
        }
    }
}