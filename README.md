# 🚀 Staj Mesajlaşma Uygulaması

Bu proje, C# .NET kullanılarak geliştirilmiş, Client-Server mimarisine dayanan anlık bir grup mesajlaşma (Chat Room) uygulamasıdır.

## 🏗️ Mimari ve Teknolojiler

Proje iki ana bileşenden oluşmaktadır:

1. **Web API (Backend):** - **Mimari:** Katmanlı Mimari (Entities, DataAccess, Business, WebAPI) ve DTO pattern.
   - **Veritabanı:** PostgreSQL (Entity Framework Core ile Code-First).
   - **Özellikler:** Dependency Injection (DI) ve Swagger API dökümantasyonu.
   - **Güvenlik:** `DotNetEnv` kullanılarak veritabanı şifreleri koddan izole edildi ve `.env` dosyasıyla koruma altına alındı.

2. **Console Client (Frontend/İstemci):** - **Özellikler:** API ile asenkron (HTTP) haberleşme ve gerçek zamanlı mesaj akışı için **Polling (Sürekli Yenileme)** mekanizması.

---

## ⚙️ Nasıl Çalıştırılır?

### 1. Veritabanı ve Güvenlik Ayarları

Projede veritabanı şifreleri kod içerisine yazılmamıştır. Projeyi çalıştırmadan önce:

- `WebAPI` klasörü içindeki `.env.example` dosyasının adını **`.env`** olarak değiştirin.
- İçerisindeki `Password=BURAYA_KENDI_SIFRENI_YAZ` kısmına kendi yerel PostgreSQL şifrenizi yazıp kaydedin.
- Terminalde `WebAPI` dizinine girip veritabanı tablolarını oluşturun:
  `dotnet ef database update`

### 2. API'yi Ayağa Kaldırma

Terminalden `WebAPI` dizinine girin ve sunucuyu başlatın:
`dotnet run`

### 3. İstemciyi (Client) Başlatma

Yeni bir terminal açın, `ConsoleClient` dizinine girin ve uygulamayı başlatın:
`dotnet run`
