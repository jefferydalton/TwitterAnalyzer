﻿using System;
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
    public class APIUtility_InMemoryRepository
    {
        APIQueryServiceRepository repositoryCtx = new AccountQueryRepositoryInMemory();

        
        [TestMethod]
        public void GetRateLimit_Returns1Item()
        {
            var response = repositoryCtx.GetRateLimits();
            Assert.AreEqual(1, response.Count);
        }

        [TestMethod]
        public void GetRateLimit_RateLimitIsMaxInt()
        {
            var response = repositoryCtx.GetRateLimits();
            Assert.AreEqual(int.MaxValue, response[0].RemainingCalls);
        }
    }
}
