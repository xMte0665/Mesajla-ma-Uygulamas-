using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Context;
using WebAPI.Entities.Concrete;

namespace WebAPI.DataAccess.Concrete
{
    // 1. Zemin olarak EfEntityRepositoryBase'i kullan, tablo olarak Message, tercüman olarak AppDbContext ver.
    // 2. IMessageDal sözleşmesini imzala.
    public class EfMessageDal : EfEntityRepositoryBase<Message, AppDbContext>, IMessageDal
    {
        // İçi boş, amelelik sıfır, güç maksimum.
    }
}