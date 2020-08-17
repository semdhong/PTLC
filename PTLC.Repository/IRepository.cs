using System.Linq;
using System.Threading.Tasks;

namespace PTLC.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();
       
        void AddAsync(TEntity entity);

       void UpdateAsync(TEntity entity);
    }
}