using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // sistemi yarat ve başlat
            var apiService = new ApiService();
            var menuManager = new MenuManager(apiService);

            await menuManager.StartAsync();
        }
    }
}