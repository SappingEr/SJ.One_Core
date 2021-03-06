﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models.AccountViewModels
{
    public class AvatarViewModel : BaseEntityViewModel
    {
        public bool Delete { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Avatar { get; set; }
    }
}
