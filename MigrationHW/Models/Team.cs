using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationHW.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Team_Title { get; set; }
        public List<Player> Players { get; set; }
    }
}
