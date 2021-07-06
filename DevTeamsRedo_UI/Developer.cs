using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsRedo_UI
{
    public class Developer
    {
        public Developer(int devId, string lastName, bool hasPluralsight)
        {
            DevId = devId;
            LastName = lastName;
            HasPluralsight = hasPluralsight;
        }

        public int DevId { get; set; }
        public string LastName { get; set; }
        public bool HasPluralsight { get; set; }

        public List<Team> Teams { get; set; } = new List<Team>();
    }
}
