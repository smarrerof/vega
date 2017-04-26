using System;
using System.Threading.Tasks;

namespace vega.Core
{
    public interface IUnitOfWork
    {       
        Task<int> CompleteAsync();
    }
}