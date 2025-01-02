using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Fight
    {
        public int FightID { get; set; } //PK
        public Tournament? Tournament { get; set; }
        public int? TournamentID { get; set; } //FK
        public int DateOfFight { get; set; }
        public bool BattleResult {  get; set; }
    }
}
