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
    public class AccountAnalyzer_InMemory
    {

        private AccountAnalyzer accountApp = new AccountAnalyzer(new AccountQueryInMemory());

        [TestMethod]
        public void AccountAnalyzer_IsInstantiated()
        {
            Assert.IsInstanceOfType(accountApp, typeof(AccountAnalyzer));
            Assert.IsInstanceOfType(accountApp.AccountQueryRepository(), typeof(AccountQueryInMemory));
        }

        [TestMethod]
        public void AccountsThatDoNotFollowBack_ReturnsEmptyList()
        {
            Assert.IsTrue(accountApp.GetFollowingThatAreNotFollowers().Count == 0);
        }
    }
}
