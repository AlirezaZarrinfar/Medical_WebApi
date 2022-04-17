﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_WebApi.Models.Hospital
{
    public class Patient
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NationalCode { get; set; }
        public DateTime BirthdayDate { get; set; }
        public List<Reception> Receptions { get; set; }
        public int ReceotionsCount { get; set; }

    }
}
