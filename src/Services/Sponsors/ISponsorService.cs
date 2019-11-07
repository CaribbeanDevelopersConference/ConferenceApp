using System.Collections.Generic;
using Refit;

namespace ConferenceApp.Services
{
    public interface ISponsorService
    {
        [Get("/sponsors/{id}")]
        SponsorDto Get(string id);

        [Get("/sponsors")]
        IEnumerable<SponsorDto> GetAll();
    }
}
