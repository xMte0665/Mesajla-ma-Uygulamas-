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
                // DİKKAT: Buradaki 'Password=sifre' kısmını bilgisayarına PostgreSQL kurarken verdiğin kendi şifrenle değiştir! / bu kod sıkıntılı hiç değişmeden çalışması gerekiyor
                optionsBuilder.UseNpgsql("Host=localhost;Database=StajMesajDb;Username=postgres;Password=571632");
            }
        }

        // Tabloları Tanıtma
        public DbSet<Conversation> Conversations { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}