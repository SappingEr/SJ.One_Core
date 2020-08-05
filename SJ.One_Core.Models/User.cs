﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SJ.One_Core.Models
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public byte[] Avatar { get; set; }
        //public Locality Locality { get; set; }
        //public SportClub SportClub { get; set; }        
        public DateTime? DOB { get; set; }
        public DateTime RegistrationDate { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {Surname}";
        //public List<StartNumber> StartNumbersUser { get; set; } = new List<StartNumber>();
        //public List<Race> MainJudgeRaces { get; set; } = new List<Race>();
        //public List<Race> JudgeRaces { get; set; } = new List<Race>();
        //public List<StartNumber> StartNumbersJudge { get; set; } = new List<StartNumber>();
        //public List<HandTiming> HandTimingsJudge { get; set; } = new List<HandTiming>();
        //public List<AutoTiming> AutoTimingsJudge { get; set; } = new List<AutoTiming>();
        //public List<Protocol> Protocols { get; set; } = new List<Protocol>();
    }
}
