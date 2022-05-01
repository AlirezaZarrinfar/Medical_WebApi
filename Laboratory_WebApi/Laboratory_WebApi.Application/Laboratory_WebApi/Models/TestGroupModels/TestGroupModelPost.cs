﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Models.TestGroupModels
{
    public class TestGroupModelPost
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public long ReceptionId { get; set; }
    }
}