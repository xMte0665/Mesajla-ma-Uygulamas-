using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Context;
using WebAPI.Entities.Concrete;

namespace WebAPI.DataAccess.Concrete
{
    // 1. EfEntityRepositoryBase'den miras al (Zemin)
    //    - TEntity olarak 'Conversation' veriyoruz.
    //    - TContext olarak 'AppDbContext' (Tercümanımız) veriyoruz.
    // 2. IConversationDal sözleşmesini imzala.
    public class EfConversationDal : EfEntityRepositoryBase<Conversation, AppDbContext>, IConversationDal
    {
        // İçi boş olmasına rağmen arka planda Add, Delete, Update, GetAll yeteneklerinin hepsine sahip!
    }
}