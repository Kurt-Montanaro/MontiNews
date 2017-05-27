using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using MvcApplication1.Utilities;
using Common;
using MvcApplication1.Models;
using System.IO;

namespace MvcApplication1.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/

        public ActionResult Index()
        {
            ArticlesBL bl = new ArticlesBL();
            IQueryable<Article> myarticles = bl.GetArticles();

            return View(myarticles);
        }



        public ActionResult Search(string keyword)
        {

            ArticlesBL bl = new ArticlesBL();
            IQueryable<Article> myarticles = bl.SearchArticle(keyword);

            return View("Index", myarticles);
        }

        //Renders/Loads the Registration page

        public ActionResult UploadArticle()
        {
            return View();
        }



        //used when Article clicks on Submit button to create a new Article
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadArticle([Bind(Include = "header,subheader,category,username,imageUpload,content,timestamp")]ArticleModel u)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    try
                    {
                        ArticlesBL bl = new ArticlesBL();

                        HttpPostedFileBase file = u.imageUpload;
                        string image = file.FileName;
                        string path = Path.Combine(Server.MapPath("~\\Images\\"), image);
                        //if (!BlobManager.enabled)
                        //{
                            file.SaveAs(path);
                        //    using (MemoryStream mem = new MemoryStream())
                        //    {
                        //        file.InputStream.CopyTo(mem);
                        //        byte[] byteArr = mem.GetBuffer()
                        //    }
                        //}
                        //else
                        //{
                        //    BlobManager.Instance.UploadBlob(image,file);
                        //}
                        Article a = new Article();
                        a.Heading = u.header;
                        a.Sub = u.subheader;
                        a.Category = u.category;
                        a.Username = u.username;
                        a.Image = image;
                        a.ArticleContent = u.content;
                        a.Published = u.timestamp;
                        switch (bl.RegisterArticle(a))
                        {
                            case ArticleEnum.ArticleExists:
                                ViewBag.Message = "Article already exists";
                                break;

                            case ArticleEnum.ErrorOccurred:
                                ViewBag.Message = "Server Error 502 Occurred. Please try again later";
                                break;

                            case ArticleEnum.Success:
                                ViewBag.Message = "Article registered successfully. ";
                                break;
                        }
                        ModelState.Clear();
                        ModelState.Clear();
                    }
                    catch (Exception e)
                    {
                        ViewBag.Message = e + u.header + u.category + u.username;

                    }
                }
                else 
                {
                    ViewBag.Message = "Check your inputs";
                }

            }
            catch (Exception e)
            {

                ViewBag.Message = "Error occurred. Please try again later. \n " + e;
            }
            return View();
        }

        public ActionResult Details(string heading)
        {
            
                Article selectedArticle = new ArticlesBL().GetArticle(heading);

                ArticleModel model = new ArticleModel();
                model.header = selectedArticle.Heading;
                model.subheader = selectedArticle.Sub;
                model.category = selectedArticle.Category;
                model.username = selectedArticle.Username;
                model.imagename = selectedArticle.Image;
                model.content = selectedArticle.ArticleContent;

                return View(model);
            
        }
         [Authorize]
        public ActionResult Delete(string heading)
        {
            if (new ArticlesBL().DeleteArticle(heading) == true)
            {
                TempData["Message"] = "Artice deleted successfully";
            }
            else
            {
                TempData["Message"] = "Article  NOT deleted!";
            }

            return RedirectToAction("Index");
        }
        
    }
}
