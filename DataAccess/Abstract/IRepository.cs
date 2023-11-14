using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // IRepository interface tüm proje içerisinde ortak olarak kullanılacak veritabanı işlemleri için metod imzalarını bulundurmaktadır.
    //Dinamik olarak aldığı T Parametresi herhangi bir Entity nesnesini temsil etmektedir.
    //where şartı ile yanlış bir sınıf yazılmaması için önlem alınmıştır.
    public interface IRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
