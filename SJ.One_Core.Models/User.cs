using Microsoft.AspNetCore.Identity;
using SJ.One_Core.Service.Attributes;
using System;
using System.Collections.Generic;

namespace SJ.One_Core.Models
{
    public class User : IdentityUser<int>
    {
        [FastSearch]
        public string FirstName { get; set; }
        [FastSearch]
        public string Surname { get; set; }        
        public string FullName => $"{FirstName} {Surname}";
        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public byte[] Avatar { get; set; }
        public int? LocalityId { get; set; }
        public Locality Locality { get; set; }
        public int? SportClubId { get; set; }
        public SportClub SportClub { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<StartNumber> StartNumbersUser { get; set; }
        public List<Race> MainJudgeRaces { get; set; }
        public List<User_Race> JudgeRaces { get; set; }
        public List<StartNumber> StartNumbersJudge { get; set; }
        public List<HandTiming> HandTimingsJudge { get; set; }
        public List<AutoTiming> AutoTimingsJudge { get; set; }
        public List<Protocol> Protocols { get; set; }
    }
}
