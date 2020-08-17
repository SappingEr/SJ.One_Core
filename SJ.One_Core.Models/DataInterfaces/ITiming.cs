﻿using System;

namespace SJ.One_Core.Models.Interfaces
{
    interface ITiming
    {
        int Id { get; set; }

        int Lap { get; set; }

        TimeSpan? LapTime { get; set; }

        TimeSpan? TotalTime { get; set; }

        DateTime? TimeStamp { get; set; }
    }
}
