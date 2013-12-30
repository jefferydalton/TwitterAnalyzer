using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAnalyzer.Domain
{
    public class Account
    {

        public ulong AccountId { get; internal set; }
        public string AccountName { get; internal set; }
        public bool IsFollower { get; internal set; }
        public bool IsFollowing { get; internal set; }
        public string AccountDescription { get; internal set; }

    }
}
