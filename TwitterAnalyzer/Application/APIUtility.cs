using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Domain;
using TwitterAnalyzer.Interfaces;
using TwitterAnalyzer.Repository;

namespace TwitterAnalyzer.Application
{
    public class APIUtility
    {
        public List<APIRateLimit> GetRateLimits(RepositoryInformation provider)
        {
            return provider.GetRateLimits();
        }
    }
}
