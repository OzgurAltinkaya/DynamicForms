using DynamicForms.Business.Abstract;
using System.Web.Mvc;

namespace DynamicForms.Web.Controllers
{
    public class _BaseController : Controller
    {
        private IAuthService service;

        public _BaseController()
        {
            service = new DynamicForms.Business.Concrete.AuthService();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!service.IsLogin())
            {
                filterContext.Result = new RedirectResult(Url.Action("Index", "Auth"));
            }

            ViewBag.User = service.GetUser();
        }
    }
}