using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArticlesRepository : ConnectionClass
    {
        public ArticlesRepository()
            : base()
        { }

        public IQueryable<Article> GetArticles()
        {
            //return from u in Entity.Articles
            //       select u;

            return Entity.Articles;
        }

        public Article GetArticle(string heading)
        {
            //var users = from u in Entity.Articles
            //            where u.Articlename == username
            //            select u;

            //return users.First();


            return Entity.Articles.SingleOrDefault(x => x.Heading == heading);

        }
        public bool AuthenticateArticle(string heading, string username)
        {

            if (Entity.Articles.SingleOrDefault(x => x.Heading == heading && x.Username == username) == null)
                return false;
            else return true;
        }

        public IQueryable<Article> SearchArticle(string keyword)
        {
            return Entity.Articles.Where(x => x.Heading.StartsWith(keyword)
                                           || x.Sub == keyword);
        }

        public void AddArticle(Article u)
        {
            Entity.Articles.Add(u);
            Entity.SaveChanges();
        }
        public void DeleteArticle(Article u)
        {
            Entity.Articles.Remove(u);
            Entity.SaveChanges();
        }
        public void UpdateArticle(string heading, string path)
        {
            Article u = GetArticle(heading);
            u.Image = path;
            Entity.SaveChanges();
        }
    }
}
