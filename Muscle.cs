using System;

namespace HeistP2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public string Specialty
        {
            get
            {
                return "Muscle";
            }
        }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;

            Console.WriteLine($"{Name} is kicking tail, and has lowered the Bank's security guard score by {SkillLevel}");

            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has incapacitated the guards");
            }
        }
    }

}