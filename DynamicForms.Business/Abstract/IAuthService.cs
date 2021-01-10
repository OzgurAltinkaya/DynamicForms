using DynamicForms.Entity;

namespace DynamicForms.Business.Abstract
{
    public interface IAuthService
    {
        void SetUser(User user);

        User GetUser();

        bool Login(string userName,string password);

        void Logout();

        bool IsLogin();
    }
}