using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SF
    {
        public int ID {  get; set; }
        public Fight fight { get; set; }
        public int FightID { get; set; }
        public Sportsman sportsman { get; set; }
        public int SportsmanID { get; set; }
    }
}
