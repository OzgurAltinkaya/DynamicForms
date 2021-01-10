using DynamicForms.Entity;
using System.Collections.Generic;

namespace DynamicForms.Business.Abstract
{
    public interface IFormService
    {
        IList<Form> Get();

        Form Get(int id);

        Form Create(Form form);

        Form Update(Form form);

        void Delete(int id);
    }
}