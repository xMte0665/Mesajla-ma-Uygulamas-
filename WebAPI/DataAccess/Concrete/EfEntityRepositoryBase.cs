using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess.Abstract;
using WebAPI.Entities.Abstract;

namespace WebAPI.DataAccess.Concrete
{
    // TEntity: Üzerinde çalışılacak tablo meesage veya conversation
    // TContext: Çalışılacak Veritabanı Terccumanı sql ile aramızdaki köprü
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // using bloğu: İşlem biter bitmez Context'i hafızadan siler
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // sistemin hazır kodu metotları yazdırıp sistemde state edip addlicez 
                addedEntity.State = EntityState.Added; // Durumunu "Eklenecek" yap
                context.SaveChanges(); // Veritabanına kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted; // Durumunu "Silinecek" yap
                context.SaveChanges();
            }
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                // Veritabanından şarta uyan tabloyu getir yoksa null
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (TContext context = new TContext())
            {
                // Filtre yoksa hepsini listele, filtre varsa şartı sağlayanları listele
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified; // Durumunu "Güncellenecek" yap
                context.SaveChanges();
            }
        }
    }
}