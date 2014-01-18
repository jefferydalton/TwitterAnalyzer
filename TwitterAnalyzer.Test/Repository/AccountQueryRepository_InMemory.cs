using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterAnalyzer.Infrastructure;
using TwitterAnalyzer.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TwitterAnalyzer.Test.Repository
{
    [TestClass]
    public class AccountQueryRepository_InMemory
    {
        AccountQueryRepository queryRepository = new AccountQueryRepositoryInMemory();
        ulong testAccountId = 1;


        [TestMethod]
        public void GetAccount_AccountIdEqControlId()
        {
            Assert.IsTrue(queryRepository.GetAccount(testAccountId).AccountId == testAccountId);
        }

        [TestMethod]
        public void GetSubscriptions_AllRecsIsSubscriptionEqTrue()
        {
            Assert.IsTrue(queryRepository.GetFollowers().Where(x => x.IFollow == false).Count() == 0);
        }

        [TestMethod]
        public void GetSubscribers_AllRecsIsSubscriberEqTrue()
        {
            Assert.IsTrue(queryRepository.GetFollowing().Where(x => x.IsFollower == false).Count() == 0);
        }
    }
}
