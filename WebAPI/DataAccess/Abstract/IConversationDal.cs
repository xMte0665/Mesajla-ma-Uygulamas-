using WebAPI.Entities.Concrete; // Conversation tablosunu tanıması için

namespace WebAPI.DataAccess.Abstract
{
    // IEntityRepository kalıbını alıyoruz ve içine "Conversation" tablosunu oturtuyoruz.
    public interface IConversationDal : IEntityRepository<Conversation>
    {
        // Standart Ekle/Sil işlemleri dışında, sadece Sohbet Odalarına özel 
        // ekstra bir SQL sorgusu yazmamız gerekirse buraya ekleyeceğiz. 
        // Şimdilik içi tamamen boş.
    }
}