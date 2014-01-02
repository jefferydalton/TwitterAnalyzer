using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Interfaces;

namespace TwitterAnalyzer.Repository
{
    public class APIQueryInMemorycs : APIQuery
    {
        public List<Domain.APIRateLimit> GetAPIRateLimits()
        {
            return new List<Domain.APIRateLimit>();
        }
    }
}
