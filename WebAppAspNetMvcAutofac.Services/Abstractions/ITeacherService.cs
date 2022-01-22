using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface ITeacherService
    {
        List<Teacher> GetEntities();
        Teacher Create();
        void Create(Teacher model);
        void Delete(int id);
        Teacher Edit(int id);
        void Edit(Teacher model);
        TeacherImage GetImage(int id, HttpServerUtilityBase server);
    }
}
