using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeistP2
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public bool IsSecure { get{ return (AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0); }}

        
        public void LogRecon()
        {
            Dictionary<string, int> _securityList = new Dictionary<string, int>
            {
                {"alarm", AlarmScore},
                {"vault", VaultScore},
                {"guard system", SecurityGuardScore}
            };
            
            Console.WriteLine($"The {_securityList.OrderBy(Key => Key.Value).ToList()[2].Key} is the most secure.");
            Console.WriteLine($"The {_securityList.OrderBy(Key => Key.Value).ToList()[0].Key} is the least secure.");
        }
    }
}
