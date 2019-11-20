using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace ConferenceApp.Services
{
    public interface ISponsorService
    {
        [Get("/sponsors/{id}")]
        Task<SponsorDto> Get(string id);

        [Get("/sponsors")]
        Task<IEnumerable<SponsorDto>> GetAll();
    }
}
