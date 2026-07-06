using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebAPI.Entities.Abstract; // IEntity sertifikasını tanıması için

namespace WebAPI.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new() // istenilen şartlar  
    {
        T? Get(Expression<Func<T, bool>> filter);  // istenilen id tablosuu çağırmak için  expression ve funclaerı hazır aldık 

        List<T> GetAll(Expression<Func<T, bool>>? filter = null);  // tüm tabloyu çağırmak için. buda hazır kalıp 

        void Add(T entity);  // add delete ve update metotları yazalım

        void Update(T entity);

        void Delete(T entity);

    }

}