using MilitaryElite.Core.Interfaces;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Core
{
    
    public class Engine : IEngine
    {
        private Dictionary<int, ISolider> soliders;
        public Engine()
        {
            soliders = new();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(ProcessInput(info));
                }
                catch (Exception ex)
                { 
                    
                }
            }
            
        }
        private string ProcessInput(string[] info)
        {

            string type = info[0];
            int id = int.Parse(info[1]);
            string firstName = info[2];
            string lastName = info[3];
            

            ISolider solider = null;

            switch (type)
            {
                case "Private":
                   solider = GetPrivate(id, firstName, lastName, decimal.Parse(info[4]));
                    break;
                case "LieutenantGeneral":
                    solider = GetLieutenantGeneral(id, firstName, lastName, decimal.Parse(info[4]),info);
                    break;
                case "Engineer":
                    solider = GetEngineer(id, firstName, lastName, decimal.Parse(info[4]), info);
                    break;
                case "Commando":
                    solider = GetCommando(id, firstName, lastName, decimal.Parse(info[4]), info);
                    break;
                case "Spy":
                    solider = GetSpy(id, firstName, lastName, int.Parse(info[4]));
                    break;
            }
            soliders.Add(id, solider);
            return solider.ToString();
        }
        private ISolider GetPrivate(int id, string firstName, string lastName, decimal salary)
        {
            return new Private(id, firstName, lastName, salary);
        }
        private ISolider GetLieutenantGeneral(int id, string firstName, string lastName, decimal salary,string[]info)
        {
            List<IPrivate> privates= new();
            for (int i = 5; i < info.Length; i++)
            {
                int soliderId = int.Parse(info[i]);
                IPrivate solider = (IPrivate)soliders[soliderId];
                privates.Add(solider);
            }
            return new LeutenantGeneral(id, firstName, lastName, salary, privates);
        }
        private ISolider GetEngineer(int id, string firstName, string lastName, decimal salary, string[] info)
        {
            bool isValidCorps = Enum.TryParse<Corps>(info[5], out Corps corps);
            if (!isValidCorps)
            {
                throw new Exception();
            }
            List<IRepair> repairs = new();
            for (int i = 6; i < info.Length; i += 2)
            {
                string partName = info[i];
                int workedHours = int.Parse(info[i + 1]);
                IRepair repair = new Repair(partName, workedHours);
                repairs.Add(repair);
            }
            return new Engineer(id, firstName, lastName, salary, corps, repairs);
        }
        private ISolider GetCommando(int id, string firstName, string lastName, decimal salary, string[] info)
        {
            bool isValidCorps = Enum.TryParse<Corps>(info[5], out Corps corps);
            if (!isValidCorps)
            {
                throw new Exception();
            }

            List<IMission> missions = new();

            for (int i = 6; i < info.Length; i += 2)
            {
                string missionName = info[i];
                string missionState =info[i + 1];
                bool isValidMissionState = Enum.TryParse<State>(missionState, out State state);

                if (!isValidMissionState)
                {
                    continue;
                }
                
                IMission mission = new Mission(missionName,state);

                missions.Add(mission);
            }

            return new Commando(id, firstName, lastName, salary, corps, missions);
        }
        private ISolider GetSpy(int id, string firstName, string lastName, int code)
        {
            return new Spy(id, firstName, lastName, code);
        }
    }
}
