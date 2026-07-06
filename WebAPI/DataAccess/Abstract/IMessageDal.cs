using WebAPI.Entities.Concrete; // Message tablosunu tanıması için

namespace WebAPI.DataAccess.Abstract
{
    // IEntityRepository kalıbını alıyoruz ve içine "Message" tablosunu oturtuyoruz.
    public interface IMessageDal : IEntityRepository<Message>
    {
        // Sadece Mesajlara özel ekstra operasyonlar olursa buraya yazılacak.
        // Şimdilik içi boş.
    }
}