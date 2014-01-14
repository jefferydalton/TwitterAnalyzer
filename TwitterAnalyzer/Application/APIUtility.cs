using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Domain;
using TwitterAnalyzer.Interfaces;
using TwitterAnalyzer.Repository;

namespace TwitterAnalyzer.Domain
{
    public class APIUtility
    {
        public static List<APIRateLimit> GetRateLimits(RepositoryInformation provider)
        {
            return provider.GetRateLimits();
        }
    }
}
