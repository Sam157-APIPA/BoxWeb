using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Coach
    {
        public int CoachID { get; set; } // PK
        public string Name { get; set; }
        public string Surname { get; set; }
        public long PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string BirthsdayDate { get; set; }
        public int? ClubID { get; set; } //FK
        public Club? Club { get; set; } 
    }
}
