﻿using SJ.One_Core.Data.Paging;
using System.Collections.Generic;

namespace SJ.One_Core.Models.AdminViewModels
{
    public class UsersListVewModel
    {
        public IEnumerable<User> Users { get; set; }
        public PagingViewModel Paging { get; set; }
    }
        
   
}
