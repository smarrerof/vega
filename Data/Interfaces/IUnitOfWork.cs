using System;
using System.Threading.Tasks;

namespace vega.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleRepository Vehicles { get; }

        
        int Complete();
        Task<int> CompleteAsync();
    }
}