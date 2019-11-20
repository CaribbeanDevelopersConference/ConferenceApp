using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConferenceApp.Services
{
    public class SpeakerDto : DtoBase
    {
        [JsonProperty("id")]
        public new Guid Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("tagLine")]
        public string TagLine { get; set; }

        [JsonProperty("profilePicture")]
        public Uri ProfilePicture { get; set; }

        [JsonProperty("sessions")]
        public List<SessionDto> Sessions { get; set; }

        [JsonProperty("isTopSpeaker")]
        public bool IsTopSpeaker { get; set; }

        [JsonProperty("links")]
        public List<LinkDto> Links { get; set; }

        [JsonProperty("questionAnswers")]
        public List<object> QuestionAnswers { get; set; }

        [JsonProperty("categories")]
        public List<object> Categories { get; set; }
    }
}