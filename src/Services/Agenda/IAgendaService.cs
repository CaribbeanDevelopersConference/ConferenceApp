using System.Collections.Generic;

namespace ConferenceApp.Services
{
    public interface IAgendaService
    {
        AgendaDto Get(string id);

        IEnumerable<AgendaDto> GetAll();
    }
}