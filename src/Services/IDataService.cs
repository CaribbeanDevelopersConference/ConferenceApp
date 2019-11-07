using System.Collections.Generic;

namespace ConferenceApp.Services
{
    public interface IDataService<out T>
        where T : DtoBase
    {
        T Get(string id);

        IEnumerable<T> GetAll();
    }
}