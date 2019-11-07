using System.Collections.Generic;

namespace ConferenceApp.Services
{
    public interface ISpeakerService
    {
        SpeakerDto Get(string id);

        IEnumerable<SpeakerDto> GetAll();
    }
}
