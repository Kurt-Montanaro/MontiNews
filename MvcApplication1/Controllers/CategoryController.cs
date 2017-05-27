using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        ArticlesBL al = new ArticlesBL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category(string category)
        {
            ViewBag.Category = al.GetArticlesByCategory(category);
            return View();
        }
    }
}
