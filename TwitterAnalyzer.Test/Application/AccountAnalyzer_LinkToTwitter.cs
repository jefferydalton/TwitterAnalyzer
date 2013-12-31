using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterAnalyzer.Repository;
using TwitterAnalyzer.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TwitterAnalyzer.Application;

namespace TwitterAnalyzer.Test.Application
{
    [TestClass]
    public class AccountAnalyzer_LinkToTwitter
    {

        private AccountAnalyzer accountApp = new AccountAnalyzer(new AccountQueryLinqToTwitter());

        [TestMethod]
        public void AccountAnalyzer_IsInstantiated()
        {
            Assert.IsInstanceOfType(accountApp, typeof(AccountAnalyzer));
            Assert.IsInstanceOfType(accountApp.AccountQueryRepository(), typeof(AccountQueryLinqToTwitter));
        }

        [TestMethod]
        public void AccountsThatDoNotFollowBack_ReturnsEmptyList()
        {
            var response = accountApp.GetAccountsThatDoNotFollowMeBack();

            Assert.AreNotSame(0, response.Count);
            Assert.IsTrue(response[0].IFollow == true && response[0].IsFollower == false);
        }
    }
}
