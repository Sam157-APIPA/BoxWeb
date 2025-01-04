using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sportsman
    {
        [Display(Name = "Id")]
        public int SportsmanID { get; set; } // PK
        public string Name { get; set; }
        public string Surname { get; set; }
        public long PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string BirthsdayDate { get; set; }
        public int? ClubID { get; set; } //FK
        public Club? Club { get; set; } 
        public string WeightCategory { get; set; }
        public string Achivments { get; set; }
        public int AgeGroup {  get; set; }
       
    }
}
