using System;
using System.Collections.Generic;

namespace ConferenceApp.Services
{
    public class AgendaServiceMock : DataServiceMock<AgendaDto>, IAgendaService
    {
        public AgendaServiceMock()
        {
            Items = new List<AgendaDto>
            {
                new AgendaDto
                {
                    Id = "1"
                },
                new AgendaDto
                {
                    Id = "2"
                },
                new AgendaDto
                {
                    Id = "3"
                },
                new AgendaDto
                {
                    Id = "4"
                },
            };
        }
    }
}
