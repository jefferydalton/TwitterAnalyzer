using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterAnalyzer.Interfaces;
using TwitterAnalyzer.Repository;

namespace TwitterAnalyzer.Test.Repository
{
    [TestClass]
    public class AccountQuery_LinqToTwitter
    {
            AccountQuery queryRepository = new AccountQueryLinqToTwitter();
            ulong testAccountId = 18153336;

            [TestMethod]
            public void GetAccount_AccountIdEqControlId()
            {
                Assert.IsTrue(queryRepository.GetAccount(testAccountId).AccountId == testAccountId);
            }

            [TestMethod]
            public void GetAccount_MutualFollowing()
            {
                var account = queryRepository.GetAccount(683213);
                Assert.IsTrue(account.IsFollower == true && account.IsFollowing == true);
            }

            [TestMethod]
            public void GetAccount_OnlyIFollow()
            {
                var account = queryRepository.GetAccount(18153336);
                Assert.IsTrue(account.IsFollower == true && account.IsFollowing == true);
            }

            [TestMethod]
            public void DumpRateLimits()
            {
                var response = ((AccountQueryLinqToTwitter)queryRepository).RateLimits();
                Assert.IsFalse(response.Count == 0);
            }

            [TestMethod]
            public void GetFollowers_ReturnsNonZeroCollection()
            {
                Assert.IsFalse(queryRepository.GetFollowers().Count == 0);               
            }

            [TestMethod]
            public void GetFollowing_ReturnsNonZeroCollection()
            {
                Assert.IsFalse(queryRepository.GetFollowing().Count == 0);
            }

    }
}
