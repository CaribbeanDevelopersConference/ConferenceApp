using System.Collections.Generic;

namespace ConferenceApp.Services
{
    public interface IScheduleService
    {
        ScheduleDto Get(string id);

        IEnumerable<ScheduleDto> GetAll();
    }
}
