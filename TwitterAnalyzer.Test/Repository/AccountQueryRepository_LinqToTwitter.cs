using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterAnalyzer.Domain;
using TwitterAnalyzer.Infrastructure;

namespace TwitterAnalyzer.Test.Repository
{
    [TestClass]
    public class AccountQueryRepository_LinqToTwitter
    {
        AccountQueryRepository queryRepository = new AccountQueryRepositoryLinqToTwitter();
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
            Assert.IsTrue(account.IsFollower == true && account.IFollow == true);
        }

        [TestMethod]
        public void GetAccount_OnlyIFollow()
        {
            var account = queryRepository.GetAccount(9505092);
            Assert.IsTrue(account.IsFollower == false && account.IFollow == true);
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
