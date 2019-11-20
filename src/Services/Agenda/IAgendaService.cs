using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceApp.Services
{
    public interface IAgendaService
    {
        Task<AgendaDto> Get(string id);

        Task<IEnumerable<AgendaDto>> GetAll();
    }
}