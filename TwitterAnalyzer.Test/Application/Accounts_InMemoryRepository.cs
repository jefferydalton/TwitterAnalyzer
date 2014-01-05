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
    public class Accounts_InMemoryRepository
    {

        private Accounts accountApp = new Accounts(new AccountQueryInMemory());

        [TestMethod]
        public void AccountsThatDoNotFollowBack_ReturnsEmptyList()
        {
            Assert.IsTrue(accountApp.GetAccountsThatDoNotFollowMeBack().Count == 0);
        }
    }
}
