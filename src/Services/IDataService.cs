using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceApp.Services
{
    public interface IDataService<T>
        where T : DtoBase
    {
        Task<T> Get(string id);

        Task<IEnumerable<T>> GetAll();
    }
}