using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var acctAnalyzer = new AccountAnalyzer();
            var acctList = acctAnalyzer.GetAccountsThatDoNotFollowMeBack();            
            return View(acctList);
        }

    }
}