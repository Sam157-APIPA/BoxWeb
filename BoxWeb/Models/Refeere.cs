﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Refeere
    {
        [Display(Name = "Id")]
        public int RefeereID { get; set; } //PK
        public List<Tournament> Tournament { get; set; } = [];
        public string Name { get; set; }
        public string Surname { get; set; }
        public long PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string BirthsdayDate { get; set; }
    }
}
