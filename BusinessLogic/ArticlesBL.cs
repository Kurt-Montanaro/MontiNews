using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public enum ArticleEnum { Success, ArticleExists, ErrorOccurred }
    public class ArticlesBL
    {
        ArticlesRepository ar = new ArticlesRepository();
        public Article GetArticle(string heading)
        {
            return ar.GetArticle(heading);
        }


        public IQueryable<Article> GetArticles()
        {

            return ar.GetArticles();
        }

        public IQueryable<Article> SearchArticle(string keyword)
        {
            if (keyword == string.Empty)
                return GetArticles();
            else
                return ar.SearchArticle(keyword);
        }

        public bool DeleteArticle(string heading)
        {
            try
            {
                ArticlesRepository ur = new ArticlesRepository();
                if (ur.GetArticle(heading) != null)
                {
                    ur.DeleteArticle(ur.GetArticle(heading));
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public ArticleEnum RegisterArticle(Article u)
        {
            if (ar.GetArticle(u.Heading) == null)
            {
                try
                {
                    //using (TransactionScope ts = new TransactionScope())
                    //{
                    ar.AddArticle(u);
                    // ts.Complete(); //actual confirmation of saving data to db
                    return ArticleEnum.Success;
                    //}
                }
                catch
                {
                    //log errors
                    return ArticleEnum.ErrorOccurred;
                }
            }
            else
            {
                return ArticleEnum.ArticleExists;
            }

        }
        //public void UpdateImage([Bind(Include = "header,subheader,category,username,imageUpload,content,timestamp")]ArticleModel u)
        //{
        //    ar.UpdateImage(heading, path);

        //}
        public List<Article> GetBreakingNews()
        {
            var db = new MontiNewsEntities();
            List<Article> allArticles = db.Articles.OrderByDescending(a => a.ArticleID).ToList();
            return allArticles.Take(5).ToList();
        }
        public List<Article> Get5MostRecentArticles()
        {
            var db = new MontiNewsEntities();
            List<Article> allArticles = db.Articles.OrderByDescending(a => a.ArticleID).ToList();
            return allArticles.Take(5).ToList();
        }

        public List<Article> Get5MostRecentArticles(string category)
        {
            var db = new MontiNewsEntities();
            List<Article> allArticles = db.Articles.OrderByDescending(a => a.Category == category).ToList();
            return allArticles.Take(5).ToList();
        }

        public Article GetArticleByID(int articleId)
        {
            var db = new MontiNewsEntities();
            return db.Articles.SingleOrDefault(a => a.ArticleID == articleId);
        }

        public List<Article> GetArticlesByCategory(string category)
        {
            var db = new MontiNewsEntities();
            return db.Articles.Where(a => a.Category == category).ToList();
        }
        public List<Article> GetArticlesByAuthor(string username)
        {
            var db = new MontiNewsEntities();
            return db.Articles.Where(a => a.Username == username).ToList();
        }
    }
}
