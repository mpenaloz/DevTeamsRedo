using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsRedo_UI
{
    public interface TeamRepo
    {
        bool CreateTeam(Team teamToAdd);

        Team GetTeamByID(int id);

        bool DeleteTeamByID(int id);

        bool CreateDeveloper(Developer devToAdd);
        bool AddDevToTeamByID(int devId, int teamId);


        bool RemoveDevFromTeamByID(int devId, int teamId);
    }
}
