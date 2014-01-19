using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Domain.Model;
using TwitterAnalyzer.Domain;
using TwitterAnalyzer.Infrastructure;

namespace TwitterAnalyzer.Domain
{
    public class APIQueryService
    {
        public static List<APIRateLimit> GetRateLimits(APIQueryServiceRepository provider)
        {
            return provider.GetRateLimits();
        }
    }
}
