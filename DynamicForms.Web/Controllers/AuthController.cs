using DynamicForms.Business.Abstract;
using DynamicForms.Web.Models;
using System.Web.Mvc;

namespace DynamicForms.Web.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService service;

        public AuthController()
        {
            service = new DynamicForms.Business.Concrete.AuthService();
        }

        // GET: Auth
        public ActionResult Index()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            //user işlemler

            if (service.Login(user.Username, user.Password))
            {
                return RedirectToAction("Index", "Home");
            }

            user.IsInvalid = true;

            return View(user);
        }
        public ActionResult Logout()
        {
            service.Logout();
            return RedirectToAction("Index");
        }
    }
}