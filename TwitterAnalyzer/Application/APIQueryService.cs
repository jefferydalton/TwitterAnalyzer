using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Application;
using TwitterAnalyzer.Domain.Model;
using TwitterAnalyzer.Domain;
using TwitterAnalyzer.Infrastructure;

namespace TwitterAnalyzer.Application
{
    public class APIQueryService
    {
        public static List<APIRateLimit> GetRateLimits(APIRateLimitRepository provider)
        {
            return provider.GetRateLimits();
        }
    }
}
