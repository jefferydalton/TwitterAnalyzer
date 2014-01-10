using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAnalyzer.Domain
{
    public class APIRateLimit
    {
        internal APIRateLimit()
        { }

        public string Resource { get; internal set; }
        public int RemainingCalls { get; internal set; }
        public int Limit { get; internal set; }
        public DateTime NextReset { get; internal set; }
    }
}
