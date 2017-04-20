using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Data.Interfaces;
using vega.Data.Models;

namespace vega.Data.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VegaDbContext VegaDbContext
        {
            get { return Context as VegaDbContext; }
        }

        public VehicleRepository(VegaDbContext context) 
            : base(context)
        {
            
        }

        public Task<Vehicle> GetExtendedVehicle(int id) 
        {
            return VegaDbContext.Vehicles
                .Include(m => m.Make)
                .Include(m => m.Model)
                .Include(m => m.Features)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public Task<List<Vehicle>> GetExtendedVehicles() 
        {
            return VegaDbContext.Vehicles
                .Include(m => m.Make)
                .Include(m => m.Model)
                .Include(m => m.Features)
                .ToListAsync();
        }
    }
}