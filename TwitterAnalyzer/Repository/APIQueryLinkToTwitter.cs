using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Domain;
using TwitterAnalyzer.Interfaces;

namespace TwitterAnalyzer.Repository
{
    public class APIQueryLinkToTwitter : LinkToTwitterBase, APIQuery
    {
        public List<Domain.APIRateLimit> GetAPIRateLimits()
        {
            return  this.RateLimits()
                        .Select(x => new APIRateLimit()
                        {
                            Limit = x.Limit,
                            NextReset = FromUnixTime(x.Reset),
                            RemainingCalls = x.Remaining,
                            Resource = x.Resource
                        }).ToList();
        }

        private DateTime FromUnixTime(ulong unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

    }
}
