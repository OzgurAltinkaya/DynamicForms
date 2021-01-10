using DynamicForms.Business.Abstract;
using DynamicForms.DataAccess;
using DynamicForms.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DynamicForms.Business.Concrete
{
    public class FormService : IFormService
    {
        private DynamicFormsContext db;
        private IAuthService authService;

        public FormService()
        {
            db = new DynamicFormsContext();
            authService = new AuthService();
        }

        public Form Create(Form form)
        {
            form.CreatedAt = DateTime.Now;
            form.CreatedBy = authService.GetUser().Id;
            form = db.Forms.Add(form);

            db.SaveChanges();

            return form;
        }
        
        public void Delete(int id)
        {
            var entity = db.Forms.Find(id);

            var fields = db.Fields.Where(x => x.FormId == id);

            foreach (var field in fields)
            {
                db.Fields.Remove(field);
            }

            db.Forms.Remove(entity);
            db.SaveChanges();
        }

        public IList<Form> Get()
        {
            return db.Forms.Include(x => x.User).ToList();
        }

        public Form Get(int id)
        {
            return db.Forms.Include(c => c.Fields).FirstOrDefault(x => x.Id == id);
        }

        public Form Update(Form form)
        {
            var entity = db.Forms.Find(form.Id);

            var fields = db.Fields.Where(x => x.FormId == form.Id);

            foreach (var field in fields)
            {
                db.Fields.Remove(field);
            }

            db.SaveChanges();

            entity.Name = form.Name;
            entity.Description = form.Description;
            entity.Fields = form.Fields;

            db.SaveChanges();

            return form;
        }
    }
}