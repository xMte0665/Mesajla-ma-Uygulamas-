using System;

namespace WebAPI.Entities.Abstract
{
    // Bütün tablolarda olacak ID ve Tarih özelliklerini buraya koyuyoruz.
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }

        // Oluşturulma tarihi 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}