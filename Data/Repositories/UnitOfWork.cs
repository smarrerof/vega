using System.Threading.Tasks;
using vega.Data.Interfaces;

namespace vega.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaDbContext _context;


        public IVehicleRepository Vehicles { get; private set; }


        public UnitOfWork(VegaDbContext context)
        {
            _context = context;
            Vehicles = new VehicleRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        
    }
}