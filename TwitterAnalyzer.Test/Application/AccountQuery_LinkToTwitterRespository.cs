﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterAnalyzer.Infrastructure;
using TwitterAnalyzer.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TwitterAnalyzer.Application;

namespace TwitterAnalyzer.Test.Application
{
    [TestClass]
    public class Accounts_LinkToTwitterRepository
    {

        private AccountQueryService accountApp = new AccountQueryService(new AccountQueryRepositoryLinqToTwitter());


        [TestMethod]
        public void AccountsThatDoNotFollowBack_ContainsItemsAndFollowRulesOk()
        {
            var response = accountApp.GetAccountsThatDoNotFollowMeBack();

            Assert.AreNotSame(0, response.Count);
            Assert.IsTrue(response[0].IFollow == true && response[0].IsFollower == false);
        }
    }
}
