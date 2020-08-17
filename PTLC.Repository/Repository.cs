using System;
using System.Linq;
using System.Threading.Tasks;
using PTLC.Data;

namespace PTLC.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly EasyDbContext _easyDbContext;

        public Repository(EasyDbContext easyDbContext)
        {
            _easyDbContext = easyDbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _easyDbContext.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }
        
        public void AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _easyDbContext.Set<TEntity>().Add(entity);
                _easyDbContext.SaveChanges();

                
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public void UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _easyDbContext.Set<TEntity>().Update(entity);
                _easyDbContext.SaveChanges();

               
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }
        public void DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _easyDbContext.Set<TEntity>().Remove(entity);
                _easyDbContext.SaveChanges();


            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }
    }
}