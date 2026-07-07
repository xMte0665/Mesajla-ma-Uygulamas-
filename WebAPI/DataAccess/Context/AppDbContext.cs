using Microsoft.EntityFrameworkCore;
using WebAPI.Entities.Concrete; // Tablolarımızı conversation ve messageyi tanıması için

namespace WebAPI.DataAccess.Context
{
    // DbContext den miras alıyoruz  microsoftun hazır veritabanı
    public class AppDbContext : DbContext
    {
        // PostgreSQL'e Bağlanma Ayarları
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)    //onconfirug bağlantı ayarları ile ilgili hazır metot
        {
            // Eğer başka bir yerden ayar gelmediyse, şu adresteki PostgreSQL'e bağlan
            if (!optionsBuilder.IsConfigured)
            {
                // Şifreyi koda yazmıyoruz, .env kasasından çekiyoruz
                var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        // Tabloları Tanıtma
        public DbSet<Conversation> Conversations { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}