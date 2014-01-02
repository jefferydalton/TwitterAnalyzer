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
        private APIQuery apiQueryProvider;

        public APIUtility(APIQuery queryProvider)
        {
            apiQueryProvider = queryProvider;
        }

        public APIUtility()
        {
            apiQueryProvider = new APIQueryLinkToTwitter();
        }

        public List<APIRateLimit> GetRateLimits()
        {
            return apiQueryProvider.GetAPIRateLimits();
        }
    }
}
