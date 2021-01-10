using DynamicForms.Business.Abstract;
using DynamicForms.Business.Concrete;
using DynamicForms.Entity;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace DynamicForms.Web.Controllers
{
    public class HomeController : _BaseController
    {
        private IFormService formService;

        public HomeController()
        {
            formService = new FormService();
        }

        public ActionResult Index() => View();

        [Route("forms/{id}")]
        public ActionResult FormDetail(int id) => View(id);

        #region api

        public ActionResult GetData() => JsonContent(formService.Get());

        [Route("getDetail/{formId}")]
        public ActionResult GetData(int formId) => JsonContent(formService.Get(formId));

        [HttpPost]
        public ActionResult UpdateForm(Form form)
        {
            if (form.Id == 0)//ekle
            {
                form = formService.Create(form);
            }
            else //güncelle
            {
                formService.Update(form);
            }

            return JsonContent(form);
        }

        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            formService.Delete(id);
            return JsonContent(true);
        }

        public ContentResult JsonContent(object data)
            => Content(JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }),
                "application/json");

        #endregion api
    }
}