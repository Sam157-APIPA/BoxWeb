using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Club
    {
        [Display(Name = "Id")]
        public int ClubID { get; set; } //PK
        public string ClubName { get; set; }
        public string? ImagePath { get; set; }
        [NotMapped]
        public List<Sportsman> Sportsmen { get; set; } = [];
        public List<Coach> Coaches { get; set; } = [];
    }
}
