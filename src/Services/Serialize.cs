using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConferenceApp.Services
{
    public static class Serialize
    {
        public static string ToJson(this List<SpeakerDto> self) => JsonConvert.SerializeObject(self, Converter.Settings);

        public static List<SpeakerDto> FromJson(string json) => JsonConvert.DeserializeObject<List<SpeakerDto>>(json, Converter.Settings);
    }
}