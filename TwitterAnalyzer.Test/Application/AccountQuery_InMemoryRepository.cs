using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterAnalyzer.Repository;
using TwitterAnalyzer.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TwitterAnalyzer.Domain;

namespace TwitterAnalyzer.Test.Application
{
    [TestClass]
    public class AccountQuery_InMemoryRepository
    {

        private AccountQuery accountApp = new AccountQuery(new AccountQueryRepositoryInMemory());

        [TestMethod]
        public void AccountsThatDoNotFollowBack_ReturnsEmptyList()
        {
            Assert.IsTrue(accountApp.GetAccountsThatDoNotFollowMeBack().Count == 0);
        }
    }
}
