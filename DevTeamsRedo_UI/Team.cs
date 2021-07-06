using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsRedo_UI
{
    public class Team
    {   
        public Team(int teamId, string name)
        {
            TeamId = teamId;
            Name = name;
        }

        public int TeamId { get; set; }
        public string Name { get; set; }
        public List<Developer> Developers { get; set; } = new List<Developer>();
    }
}
