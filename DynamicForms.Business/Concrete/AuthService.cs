using DynamicForms.DataAccess;
using DynamicForms.Entity;
using System;
using System.Linq;
using System.Web.SessionState;

namespace DynamicForms.Business.Concrete
{
    public class AuthService : Abstract.IAuthService
    {
        private DynamicFormsContext db;
        private HttpSessionState session;
        private readonly string userSession = "user";

        public AuthService()
        {
            db = new DynamicFormsContext();
            session = System.Web.HttpContext.Current.Session;
        }

        public User GetUser()
        {
            return (User)session[userSession];
        }

        public void SetUser(User user)
        {
            session[userSession] = user;
        }

        public bool IsLogin()
        {
            return GetUser() != null;
        }

        public bool Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(q => q.Username == username && q.Password == password);

            if (user != null)
            {
                SetUser(user);
                return true;
            }

            return false;
        }

        public void Logout()
        {
            SetUser(null);
        }

      
    }
}