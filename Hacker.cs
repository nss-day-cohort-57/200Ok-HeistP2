using System;

namespace HeistP2
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;

            Console.WriteLine($"{Name} is wearing a long black trenchcoat and typing furiously, and has lowered the Bank's alarm score by {SkillLevel}");

            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has hacked the system");
            }
        }
    }

}