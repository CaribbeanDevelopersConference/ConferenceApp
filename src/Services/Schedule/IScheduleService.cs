using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceApp.Services
{
    public interface IScheduleService
    {
        Task<ScheduleDto> Get(string id);

        Task<IEnumerable<ScheduleDto>> GetAll();
    }
}
