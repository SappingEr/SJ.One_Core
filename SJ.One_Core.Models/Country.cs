﻿using System.Collections.Generic;

namespace SJ.One_Core.Models
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public List<Region> Regions { get; set; }
    }
}
