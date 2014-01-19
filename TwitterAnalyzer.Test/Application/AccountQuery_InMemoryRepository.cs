using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterAnalyzer.Infrastructure;
using TwitterAnalyzer.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TwitterAnalyzer.Test.Application
{
    [TestClass]
    public class AccountQuery_InMemoryRepository
    {

        private AccountQueryService accountApp = new AccountQueryService(new AccountQueryRepositoryInMemory());

        [TestMethod]
        public void AccountsThatDoNotFollowBack_ReturnsEmptyList()
        {
            Assert.IsTrue(accountApp.GetAccountsThatDoNotFollowMeBack().Count == 0);
        }
    }
}
