using MvcLibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLibraryProject.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class, new()
    {
        DbLibraryEntities db = new DbLibraryEntities();

        public void Add(TEntity entity)
        {
            var addedEntity = db.Entry(entity);
            addedEntity.State = EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = db.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = db.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetList()
        {
            return db.Set<TEntity>().ToList();
        }
    }
}
