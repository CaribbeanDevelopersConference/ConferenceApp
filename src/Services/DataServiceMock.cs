using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApp.Services
{
    public class DataServiceMock<T> : IDataService<T>
        where T : DtoBase
    {
        protected List<T> Items = new List<T>();

        public async Task<T> Get(string id) => Items.FirstOrDefault(x => x.Id == id);

        public async Task<IEnumerable<T>> GetAll() => Items;
    }
}