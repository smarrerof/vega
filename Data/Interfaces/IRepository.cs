using System.Threading.Tasks;

namespace vega.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}