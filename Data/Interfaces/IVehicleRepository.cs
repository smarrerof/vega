using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Data.Models;

namespace vega.Data.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
         Task<Vehicle> GetExtendedVehicle(int id);
         Task<List<Vehicle>> GetExtendedVehicles();
    }
}