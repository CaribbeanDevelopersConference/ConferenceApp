using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceApp.Services
{
    public interface ISpeakerService
    {
        Task<SpeakerDto> Get(string id);

        Task<IEnumerable<SpeakerDto>> GetAll();
    }
}
