using System;
using System.Collections.Generic;
using System.Linq;
namespace HeistP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = new List<IRobber>
            {
                new Hacker {Name = "Tiffany", SkillLevel = 76, PercentageCut = 15 },
                new Muscle {Name = "Robert", SkillLevel = 75, PercentageCut = 15 },
                new LockSpecialist {Name = "Ryan", SkillLevel = 75, PercentageCut = 16},
                new Hacker {Name = "Wilson", SkillLevel = 75, PercentageCut = 14},
                new Muscle {Name = "Jim", SkillLevel = 50, PercentageCut = 10}
            };
            Console.WriteLine($"There are {rolodex.Count} robbers in the database");
            rolodex.ForEach((p) => Console.WriteLine($"{p.Name} gets a {p.PercentageCut}% cut, and has a skill level of {p.SkillLevel}"));


            while (true)
            {
                IRobber newRobber = CreateARobber();
                if(newRobber == null)
                {
                    break;
                }
                rolodex.Add(newRobber);
            }

            rolodex.ForEach((p) => Console.WriteLine($"{p.Name} gets a {p.PercentageCut}% cut, and has a skill level of {p.SkillLevel}"));

            Bank bank = new Bank()
            {
                AlarmScore = new Random().Next(0, 101),
                SecurityGuardScore = new Random().Next(0, 101),
                VaultScore = new Random().Next(0, 101),
                CashOnHand = new Random().Next(50000, 1000001)
            };
            
            bank.LogRecon();
        }

        static IRobber CreateARobber()
        {
            Console.Write("Create a new robber:");
            string robberName = Console.ReadLine();

            if(robberName == "")
            {
                return null;
            }

            var type = typeof(IRobber);
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany((s) => s.GetTypes()).Where((p) => type.IsAssignableFrom(p));
            Console.WriteLine($"Choose a specialty {string.Join(" ", types.Select((t) => t.Name)).Replace("IRobber ", "")}");
            string specialty = Console.ReadLine();
            Console.WriteLine("Enter the robber's skill level");
            int skill = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the robber's percentage of the cut");
            int percentCut = int.Parse(Console.ReadLine());

            if (specialty.ToLower() == "hacker")
            {
                return new Hacker { Name = robberName, SkillLevel = skill, PercentageCut = percentCut };
            }
            else if (specialty.ToLower() == "muscle")
            {
                return new Muscle { Name = robberName, SkillLevel = skill, PercentageCut = percentCut };
            }
            else if (specialty.ToLower() == "lockspecialist")
            {
                return new LockSpecialist { Name = robberName, SkillLevel = skill, PercentageCut = percentCut };
            }
            else
            {
                Console.WriteLine("Invalid Specialty, try again.");
                return CreateARobber();
            }
        }
    }
}
