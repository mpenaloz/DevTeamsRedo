using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsRedo_UI
{
    public class Dev_TeamRepo : TeamRepo
    {
        private readonly List<Team> _teams = new List<Team>();
        private readonly List<Developer> _devs = new List<Developer>();

        public bool CreateTeam(Team teamToAdd)
        {
            _teams.Add(teamToAdd);
            return _teams.Contains(teamToAdd);
        }

        public Team GetTeamByID(int id)
        {
            foreach (var team in _teams)
            {
                if (team.TeamId == id)
                {
                    return team;
                }
            }
            return null;
        }

        public bool DeleteTeamByID(int id)
        {
            foreach (var team in _teams)
            {
                if (team.TeamId == id)
                {
                    _teams.Remove(team);
                    return true;
                }
            }
            return false;
        }

        public bool CreateDeveloper(Developer devToAdd)
        {
            _devs.Add(devToAdd);
            return _devs.Contains(devToAdd);
        }

        public bool AddDevToTeamByID(int devId, int teamId)
        {
            foreach (var team in _teams)
            {
                if (team.TeamId == teamId)
                {
                    foreach (var dev in _devs)
                    {
                        if (dev.DevId == devId)
                        {
                            team.Developers.Add(dev);
                            dev.Teams.Add(team);
                            return team.Developers.Contains(dev);
                        }
                    }
                    return false;
                }
            }
            return false;
        }

        public bool RemoveDevFromTeamByID(int devId, int teamId)
        {
            foreach (var team in _teams)
            {
                if (team.TeamId == teamId)
                {
                    foreach (var dev in _devs)
                    {
                        if (dev.DevId == devId)
                        {
                            team.Developers.Remove(dev);
                            dev.Teams.Remove(team);
                            return !team.Developers.Contains(dev);
                        }
                    }
                    return false;
                }
            }
            return false;

        }
    }
}
