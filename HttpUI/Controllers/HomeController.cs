﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterAnalyzer.Domain;
using TwitterAnalyzer.Domain.Model;
using TwitterAnalyzer.Application;

namespace HttpUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoesNotFollowBack()
        {
            var acctAnalyzer = new AccountQueryService();
            var acctList = acctAnalyzer.GetAccountsThatDoNotFollowMeBack();            
            return View(acctList);
        }

        public ActionResult RateLimits()
        {
            var acctAnalyzer = new AccountQueryService();
            var rateLimts = APIQueryService.GetRateLimits(acctAnalyzer.RepositoryInformation());
            return View(rateLimts);
        }

    }
}