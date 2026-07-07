using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.Business.Abstract;
using WebAPI.Business.Concrete;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete;
using WebAPI.DataAccess.Context;

DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);  // web sunucusunu inşaya başla hazır metot

// API Controller'larını sisteme ekle build et hazır metot buda
builder.Services.AddControllers();

// Swagger (Test Ekranı) ui için gerekli ayarlar hazır metot bunlar da
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Veritabanı bağlantısını sisteme tanıtıyoruz  başı hazır sonrası zaten bizim clasımız
builder.Services.AddDbContext<AppDbContext>();

// DEPENDENCY INJECTION 
// Sistem çalışırken biri IConversationService isterse ona ConversationManager ver
builder.Services.AddScoped<IConversationService, ConversationManager>();  // addscoped hazır metot injectionlarda kullanılır
// Biri IConversationDal isterse ona EfConversationDal ver
builder.Services.AddScoped<IConversationDal, EfConversationDal>();

// Sistem çalışırken biri IMessageService isterse ona MessageManager ver
builder.Services.AddScoped<IMessageService, MessageManager>();
// Biri IMessageDal isterse ona EfMessageDal ver
builder.Services.AddScoped<IMessageDal, EfMessageDal>();


var app = builder.Build();

// Hata ayıklama ve Swagger ekranını tarayıcıda gösterme
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();   // authentation şuan kulllanmadık ama hazır şablon
app.MapControllers();     // controllersleri asıl eşleyen hazır metot

app.Run(); // çalıştırrrrrrrrrrr