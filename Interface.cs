namespace HeistP2
{
    public interface IRobber
    {
        string Name { get; set; }
        string Specialty { get; }
        int SkillLevel { get; set; }
        int PercentageCut { get; set; }
        void PerformSkill(Bank bank);
    }
}