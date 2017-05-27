using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public enum RegistrationEnum { Success, UsernameExists, ErrorOccurred }
    public class UsersBL
    {
        

        UsersRepository ur = new UsersRepository();
        public Author GetUser(string username)
        {
            return ur.GetUser(username);
        }


        public IQueryable<Author> GetUsers()
        {

            return ur.GetUsers();
        }

        public IQueryable<Author> SearchUser(string keyword)
        {
            if (keyword == string.Empty)
                return GetUsers();
            else
                return ur.SearchUser(keyword);
        }

        public RegistrationEnum RegisterUser(Author u)
        {
            if (ur.GetUser(u.Username) == null)
            {
                try
                {
                    //using (TransactionScope ts = new TransactionScope())
                    //{
                    ur.AddUser(u);
                    // ts.Complete(); //actual confirmation of saving data to db
                    return RegistrationEnum.Success;
                    //}
                }
                catch
                {
                    //log errors
                    return RegistrationEnum.ErrorOccurred;
                }
            }
            else
            {
                return RegistrationEnum.UsernameExists;
            }

        }
        public bool DeleteUser(string username)
        {
            try
            {
                UsersRepository ur = new UsersRepository();
                if (ur.GetUser(username) != null)
                {
                    ur.DeleteUser(ur.GetUser(username));
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Login(string username, string password)
        {
            //is Author blocked?
            //if Author is blocked - return false;
            //if Author is not blocked, check for username and password
            //are the username and password ok?
            //if yes 1) reset no of attempts 2) return true
            //if false 1) increment no of attempts 2) is no of attempts >3
            //if yes block Author

            //return false;

            return ur.AuthenticateUser(username, password);
        }

    }
}
