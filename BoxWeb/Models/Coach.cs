using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Coach
    {
        [Display(Name = "Id")]
        public int CoachID { get; set; } // PK
        public string Name { get; set; }
        public string Surname { get; set; }
        //вызывается во view
        [Required(ErrorMessage = "Input phone number starting with 8")]
        [Range(80000000000, 89999999999, ErrorMessage = "Invalid phone number")]
        public long PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string BirthsdayDate { get; set; }
        public int? ClubID { get; set; } //FK
        public Club? Club { get; set; } 
    }
}
