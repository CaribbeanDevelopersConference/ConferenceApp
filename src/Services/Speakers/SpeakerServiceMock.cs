﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceApp.Services.Speakers
{
    public class SpeakerServiceMock : DataServiceMock<SpeakerDto>, ISpeakerService
    {
        public SpeakerServiceMock()
        {
            Items = new List<SpeakerDto>
            {
                new SpeakerDto
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Scott",
                    LastName = "Hanselman",
                    FullName = "Scott Hansleman",
                    Title = "Program Manager",
                    Company = "Microsoft",
                    Bio = "Scott is a web developer who has been blogging at https://hanselman.com for over a decade. He works in Open Source on ASP.NET and the Azure Cloud for Microsoft out of his home office in Portland, Oregon. ... He's written a number of books and spoken in person to almost a half million developers worldwide.",
                    ProfilePicture = new Uri("https://sec.ch9.ms/ch9/e039/6174a763-27c7-4968-ae08-84592ef9e039/HanselmanDemosandNETCodeRC_960.jpg"),
                    Sessions = new List<SessionDto>
                    {
                        new SessionDto{ Id = 1, Name = "Normally Sugared" }
                    },
                    Links = new List<LinkDto>
                    {
                        new LinkDto
                        {
                            Title = "Scott Hansleman",
                            LinkType = "Blog",
                            Url = new Uri("https://www.hanselman.com/blog/")
                        }
                    }
                },
                new SpeakerDto
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jessica",
                    LastName = "Deen",
                    FullName = "Jessica Deen",
                    Title = "Senior Developer Advocate",
                    Company = "Microsoft",
                    Bio = "",
                    ProfilePicture = new Uri("https://avatars1.githubusercontent.com/u/7676214?s=460&v=4"),
                    Sessions = new List<SessionDto>
                    {
                        new SessionDto{ Id = 1, Name = "League of Extraordinary Advocates" }
                    },
                    Links = new List<LinkDto>
                    {
                        new LinkDto
                        {
                            Title = "Jessica Deen",
                            LinkType = "You Tube",
                            Url = new Uri("https://www.youtube.com/channel/UC-RjyheFSQPAv-MyY0STSIQ")
                        }
                    }
                },
                new SpeakerDto
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Grace",
                    LastName = "Jansen",
                    FullName = "Grace Jansen",
                    Title = "Developer Advocate",
                    Company = "IBM",
                    Bio = "",
                    ProfilePicture = new Uri("https://pbs.twimg.com/profile_images/990816600059236352/93n1QNVv_400x400.jpg"),
                },
                new SpeakerDto
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Rob",
                    LastName = "Hedgpeth",
                    FullName = "Rob Hedgpeth",
                    Title = "Senior Developer Advocate",
                    Company = "Couchbase",
                    Bio = "",
                    ProfilePicture = new Uri("https://pbs.twimg.com/profile_images/1120054434460045314/QoDJ8EZp_400x400.jpg"),
                },
                new SpeakerDto
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mofizur",
                    LastName = "Rahman",
                    FullName = "Mofizur Rahman",
                    Title = "Developer Advocate",
                    Company = "IBM",
                    Bio = "",
                    ProfilePicture = new Uri("https://sec.ch9.ms/ch9/e039/6174a763-27c7-4968-ae08-84592ef9e039/HanselmanDemosandNETCodeRC_960.jpg"),
                }
            };
        }
    }
}
