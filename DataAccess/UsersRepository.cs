using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UsersRepository : ConnectionClass
    {
        public UsersRepository():base()
        { }

        public IQueryable<Author> GetUsers()
        {
            //return from u in Entity.Users
            //       select u;

            return Entity.Authors;
        }

        public Author GetUser(string username)
        {
            //var users = from u in Entity.Users
            //            where u.Username == username
            //            select u;

            //return users.First();


            return Entity.Authors.SingleOrDefault(x => x.Username == username);

        }
        public bool AuthenticateUser(string username, string password)
        {

            if (Entity.Authors.SingleOrDefault(x => x.Username == username && x.Password == password) == null)
                return false;
            else return true;
        }

        public IQueryable<Author> SearchUser(string keyword)
        {
            return Entity.Authors.Where(x => x.Name.StartsWith(keyword)
                                           || x.Surname == keyword);
        }

        public void AddUser(Author u)
        {
            Entity.Authors.Add(u);
            Entity.SaveChanges();
        }
        public void DeleteUser(Author u)
        {
            Entity.Authors.Remove(u);
            Entity.SaveChanges();
        }
    }
}
