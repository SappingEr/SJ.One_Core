﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models
{
    public class SportClub : BaseEntity
    {
        public string Name { get; set; }
        public int LocalityId { get; set; }
        public Locality Locality { get; set; }
        public ICollection<User> SportClubUsers { get; set; }
    }
}
