using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using BusinessLogic;
using MvcApplication1.Utilities;
using MvcApplication1.Models;
namespace MvcApplication1.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult Index()
        {
            UsersBL bl = new UsersBL();
            IQueryable<Author> myusers = bl.GetUsers();

            
            return View(myusers);
        }



        public ActionResult Search(string keyword)
        {

            UsersBL bl = new UsersBL();
            IQueryable<Author> myusers = bl.SearchUser(keyword);

            return View("Index", myusers);
        }

        //Renders/Loads the Registration page

        public ActionResult Registration()
        {
            return View();
        }

        


        //used when Author clicks on Submit button to create a new Author
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Author u)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    u.Password = new Encryption().HashString(u.Password);


                    UsersBL bl = new UsersBL();
                    switch (bl.RegisterUser(u))
                    {
                        case RegistrationEnum.UsernameExists:
                            ViewBag.Message = "Username already exists";
                            break;

                        case RegistrationEnum.ErrorOccurred:
                            ViewBag.Message = "Server Error 502 Occurred. Please try again later";
                            break;

                        case RegistrationEnum.Success:
                            ViewBag.Message = "Author registered successfully. Please proceed to login page";
                            break;
                    }
                    ModelState.Clear();
                }
                else 
                {
                    ViewBag.Message = "Check your inputs";
                }

            }
            catch (Exception e)
            {

                ViewBag.Message = "Error occurred. Please try again later. \n "+e;
            }
            return View();
        }

        public ActionResult Details(string username)
        {
            

            Author selectedAuthor = new UsersBL().GetUser(username);

            DetailsModel model = new DetailsModel();
            model.MyAuthor = selectedAuthor;
            ArticlesBL al = new ArticlesBL();

            ViewBag.ArticlesbyAuthor= al.GetArticlesByAuthor(username);
            return View(model);
        }

        public ActionResult Delete(string username)
        {
            if (new UsersBL().DeleteUser(username) == true)
            {
                TempData["Message"] = "User deleted successfully";
            }
            else
            {
                TempData["Message"] = "User NOT deleted!";
            }

            return RedirectToAction("Index");
        }
        


    }
}
