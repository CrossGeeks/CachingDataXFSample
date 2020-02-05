using System.Collections.Generic;
using System.Threading.Tasks;
using CachingDataSample.Models;

namespace CachingDataSample.Services
{
    public interface IApiManager
    {
        Task<IEnumerable<MakeUp>> GetMakeUpsAsync();
    }
}
