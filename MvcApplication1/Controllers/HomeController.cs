using BusinessLogic;
using Common;
using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        ArticlesBL al = new ArticlesBL();
        public ActionResult Index()
        {
            

            ViewBag.Recent = al.Get5MostRecentArticles();
            ViewBag.RecentNational = al.Get5MostRecentArticles("(National");
            ViewBag.RecentOverseas = al.Get5MostRecentArticles("Overseas");
            ViewBag.RecentSports = al.Get5MostRecentArticles("Sports");
            ViewBag.RecentOpinion = al.Get5MostRecentArticles("Opinion");
            ViewBag.RecentTravel = al.Get5MostRecentArticles("Travel");
            ViewBag.RecentOdd = al.Get5MostRecentArticles("Odd");

            return View();
        }
        public ActionResult RenderBreaking()
        {
            var a = al.GetBreakingNews();
            //ArticleModel am = new ArticleModel() { header = a.Header, category = a.category, content = a.content };
            //ViewData["breakingNews"] = am;

            ViewBag.Recent = al.Get5MostRecentArticles();
            return PartialView("_BreakingNews", ViewBag.Recent);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
