using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterAnalyzer.Application;

namespace TwitterAnalyzer.Test.Application
{
    [TestClass]
    public class APIUtility_LinkToTwitter
    {

        private APIUtility apiUtilityCtx = new APIUtility();


        [TestMethod]
        public void GetRateLimits_ReturnsAtLeastOneItem()
        {
            Assert.AreNotEqual(0, apiUtilityCtx.GetRateLimits().Count);
        }

        [TestMethod]
        public void GetRateLimits_ContainsRateLimitAPI()
        {
            var rateLimits = apiUtilityCtx.GetRateLimits();

            Assert.IsTrue(rateLimits.Where(x => x.Resource == "/application/rate_limit_status").Count() == 1);
        }
    }
}
