# 🚀 Staj Mesajlaşma Uygulaması

Bu proje, C# .NET kullanılarak geliştirilmiş, Client-Server mimarisine dayanan anlık bir grup mesajlaşma (Chat Room) uygulamasıdır.

## 🏗️ Mimari ve Teknolojiler

Proje iki ana bileşenden oluşmaktadır:

1. **Web API (Backend):** - **Mimari:** Katmanlı Mimari (Entities, DataAccess, Business, WebAPI) ve DTO (Data Transfer Object) pattern.
   - **Veritabanı:** PostgreSQL (Entity Framework Core kullanılarak Code-First yaklaşımıyla modellendi).
   - **Özellikler:** Dependency Injection (DI) kullanılarak servisler soyutlandı, Swagger ile API dökümantasyonu sağlandı.
2. **Console Client (Frontend/İstemci):** - **Özellikler:** API ile asenkron (HTTP) haberleşme. Odaya özel mesajların gerçek zamanlıya yakın akmasını sağlayan **Polling (Sürekli Yenileme)** mekanizması entegre edilmiştir.

## ⚙️ Nasıl Çalıştırılır?

### 1. Veritabanı Ayarları

WebAPI projesi içindeki `AppDbContext.cs` dosyasında bulunan PostgreSQL bağlantı cümlenizi kendi yerel veritabanı bilgilerinize göre güncelleyin. Ardından terminalde `WebAPI` dizinine girip tabloları oluşturun:
`dotnet ef database update`

### 2. API'yi Ayağa Kaldırma

Terminalden `WebAPI` dizinine girin ve motoru ateşleyin:
`dotnet run`
API ayağa kalktığında `http://localhost:5211/swagger` adresinden servisleri test edebilirsiniz.

### 3. İstemciyi (Client) Başlatma

Yeni bir terminal açın, `ConsoleClient` dizinine girin ve uygulamayı başlatın:
`dotnet run`
Kullanıcı adınızı girerek mevcut odalara katılabilir veya yeni oda kurarak eşzamanlı mesajlaşmayı test edebilirsiniz.
