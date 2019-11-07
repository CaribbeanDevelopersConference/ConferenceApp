using System.Collections.Generic;
using System.Linq;

namespace ConferenceApp.Services
{
    public class DataServiceMock<T> : IDataService<T>
        where T : DtoBase
    {
        protected List<T> Items = new List<T>();

        public T Get(string id) => Items.FirstOrDefault(x => x.Id == id);

        public IEnumerable<T> GetAll() => Items;
    }
}