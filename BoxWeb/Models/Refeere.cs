using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Refeere
    {
        public int RefeereID { get; set; } //PK
        public List<Tournament> Tournament { get; set; } = [];
        public string Name { get; set; }
        public string Surname { get; set; }
        public long PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string BirthsdayDate { get; set; }
    }
}
