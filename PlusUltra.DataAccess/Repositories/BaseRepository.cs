using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlusUltraDB.Entities;
using System.Data.Entity;

namespace PlusUltra.DataAccess.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected PlusUltraDbContext Context;

        protected DbSet<T> DBSet
        {
            get
            {
                return Context.Set<T>();
            }
        }

        public BaseRepository() => Context = new PlusUltraDbContext();

        public List<T> GetAll() => Context.Set<T>().ToList();
        public T GetById(int id) => Context.Set<T>().Find(id);

        public void Create(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }
        public void Update(T item, Func<T, bool> findByIDPredecate)
        {
            var local = Context.Set<T>()
                         .Local
                         .FirstOrDefault(findByIDPredecate);// (f => f.ID == item.ID);
            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void PromoteOrDemote(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }
        public bool DeleteByID(int id)
        {
            bool isDeleted = false;
            T dbItem = Context.Set<T>().Find(id);
            if (dbItem != null)
            {
                Context.Set<T>().Remove(dbItem);
                int recordsChanged = Context.SaveChanges();
                isDeleted = recordsChanged > 0;
            }
            return isDeleted;
        }
    }
}
