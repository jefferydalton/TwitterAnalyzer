using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterAnalyzer.Infrastructure;
using TwitterAnalyzer.Domain;

namespace TwitterAnalyzer.Test.Application
{
    [TestClass]
    public class APIUtility_LinkToTwitterRepository
    {
        APIQueryServiceRepository repositoryCtx = new AccountQueryRepositoryLinqToTwitter();

        
        [TestMethod]
        public void GetRateLimit_Returns4Item()
        {
            var response = repositoryCtx.GetRateLimits();
            Assert.AreEqual(4, response.Count);
        }

    }
}
