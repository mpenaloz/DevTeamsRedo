using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsRedo_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var myTeamRepo = new Dev_TeamRepo();
            ProgramUI ui = new ProgramUI(myTeamRepo);
            ui.Run();



        }
    }
}
