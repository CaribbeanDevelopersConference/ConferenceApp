using Newtonsoft.Json;

namespace ConferenceApp.Services
{
    public class SessionDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}