using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAnalyzer.Domain
{
    public class Account
    {
        internal Account()
        { }

        public ulong AccountId { get; internal set; }
        public string AccountName { get; internal set; }
        public bool IsFollower { get; internal set; }
        public bool IFollow { get; internal set; }
        public string AccountDescription { get; internal set; }
        public Uri ProfileImage { get; internal set; }

    }
}
