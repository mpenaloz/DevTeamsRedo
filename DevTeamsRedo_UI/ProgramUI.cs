using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsRedo_UI
{
    public class ProgramUI
    {
        private readonly TeamRepo _teamRepo;

        public ProgramUI(TeamRepo teamRepo)
        {
            _teamRepo = teamRepo;
        }
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                System.Console.WriteLine("Hey, what would you like to do?" +
                    "\n1. Create a Developer" +
                    "\n2. Create a Team" +
                    "\n3. Add Developer To Team" +
                    "\n4. Remove Developer From Team" +
                    "\n5. Find a Team" +
                    "\n6. Delete a Team");
                string userResponse = System.Console.ReadLine();

                switch (userResponse)
                {
                    case "1":
                        var createDevRes = _teamRepo.CreateDeveloper(GetDevFromUser());
                        if (createDevRes)
                        {
                            System.Console.WriteLine("Your developer has been added!");
                            break;
                        }
                        System.Console.WriteLine("Could't create the developer.");
                        break;
                    case "2":
                        var createTeamRes = _teamRepo.CreateTeam(GetTeamFromUser());
                        if (createTeamRes)
                        {
                            System.Console.WriteLine("Your team has been added!");
                            break;
                        }
                        System.Console.WriteLine("Could't create the team.");
                        break;
                    case "3":
                        int addDevToTeamId = GetTeamIDFromUser();
                        int addDevToTeamDevId = GetDevIDFromUser();
                        var addDevToTeamRes = _teamRepo.AddDevToTeamByID(addDevToTeamDevId, addDevToTeamId);
                        if (addDevToTeamRes)
                        {
                            System.Console.WriteLine("Your dev has been added to the team!");
                            break;
                        }
                        System.Console.WriteLine("Could't add the dev to the team.");
                        break;
                    case "4":
                        var remDevFromTeamDevId = GetDevIDFromUser();
                        var remDevFromTeamTeamId = GetTeamIDFromUser();
                        var remDevFromTeamRes = _teamRepo.RemoveDevFromTeamByID(remDevFromTeamDevId, remDevFromTeamTeamId);
                        if (remDevFromTeamRes)
                        {
                            System.Console.WriteLine("Your dev has been removed from the team!");
                            break;
                        }
                        System.Console.WriteLine("Could't remove the dev from the team.");
                        break;
                    case "5":
                        var findTeamId = GetTeamIDFromUser();
                        var findTeamRes = _teamRepo.GetTeamByID(findTeamId);
                        if (!(findTeamRes == null))
                        {
                            System.Console.WriteLine($"Team Name: {findTeamRes.Name}");
                            System.Console.WriteLine($"Team ID: {findTeamRes.TeamId}");
                            System.Console.WriteLine($"Devs: {findTeamRes.Developers.Count}");
                            foreach (var dev in findTeamRes.Developers)
                            {
                                System.Console.WriteLine(dev.LastName);
                            }
                            break;
                        }
                        System.Console.WriteLine("Could't find the team.");
                        break;
                    case "6":
                        var deleteTeamID = GetTeamIDFromUser();
                        var deleteTeamRes = _teamRepo.DeleteTeamByID(deleteTeamID);
                        if (deleteTeamRes)
                        {
                            System.Console.WriteLine("Your team was deleted!");
                            break;
                        }
                        System.Console.WriteLine("Could't delete the team.");
                        break;
                    default:
                        System.Console.WriteLine("Hey, try giving me an actual number next time");
                        break;
                }
            }
        }

        private int GetTeamIDFromUser()
        {
            System.Console.WriteLine("What's the ID of the Team?");
            return int.Parse(System.Console.ReadLine());
        }

        private int GetDevIDFromUser()
        {
            System.Console.WriteLine("What's the ID of the Dev?");
            return int.Parse(System.Console.ReadLine());
        }

        private Team GetTeamFromUser()
        {
            System.Console.WriteLine("What's the team's name?");
            string teamName = System.Console.ReadLine();
            System.Console.WriteLine("What's the team's ID?");
            int teamId = int.Parse(Console.ReadLine());
            return new Team(teamId, teamName);
        }

        private Developer GetDevFromUser()
        {
            System.Console.WriteLine("What's the last name?");
            string devLastName = System.Console.ReadLine();
            System.Console.WriteLine("What's the ID?");
            int devId = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Do they have Pluralsight?(y/n)");
            string pluralsightOrNah = System.Console.ReadLine().ToLower();
            bool hasPluralsight = false;
            if (pluralsightOrNah == "y")
            {
                hasPluralsight = true;
            }
            return new Developer(devId, devLastName, hasPluralsight);
        }
    }

}

