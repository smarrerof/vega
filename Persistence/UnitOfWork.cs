using System.Threading.Tasks;
using vega.Core;
using vega.Persistence;

namespace vega.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaDbContext _context;
    
        public UnitOfWork(VegaDbContext context)
        {
            _context = context;            
        }               

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }        
    }
}