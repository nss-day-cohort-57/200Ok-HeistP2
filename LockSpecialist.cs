using System;

namespace HeistP2
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public string Specialty
        {
            get
            {
                return "Lock Picker";
            }
        }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;

            Console.WriteLine($"{Name} is breaking in, and has lowered the Bank's vault score by {SkillLevel}");

            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has cracked the safe");
            }
        }
    }

}