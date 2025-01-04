using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Tournament
    {
        [Display(Name = "Id")]
        public int TournamentID { get; set; } //PK
        public Refeere? Refeere { get; set; }
        public int? RefeereID { get; set; }  //FK
        public List<Fight> Fight { get; set; } = [];
        public string Name {  get; set; }
        public string Adress { get; set; }
        public int Year { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
    }
}
