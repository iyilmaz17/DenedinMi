using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    // IRepository den miras alınmış bu sınıf parametre olarak bir contex nesnesi ve entity almaktadır
    // where şartları ile Entity alanına hatalı nesnelerin yazılması engellenmiştir
    
    public class EfEntityRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        //GetAll metodu içerisinde bir lamda ile belirtilen ifade eğer bir şart yoksa verinin tamamanı getirmesi için yazılmıştır
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            // Using satırı metod çalıştıktan sonra garbage collector beklemeden belleketen silinerek performans sağlaması içindir.
            using (TContext context = new TContext())
            {
                // Bir if yapısı ile sorguya filtre eklenip eklenmeyeceği belirlenmiştir.
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        // Belli bir şarta göre tek değer dönderen metod
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        // Ekleme işlemi
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        // Güncelleme işlemi
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        // Silme işlemi
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
