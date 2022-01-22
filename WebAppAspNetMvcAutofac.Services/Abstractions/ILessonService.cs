using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface ILessonService
    {
        List<Lesson> GetEntities();
        Lesson Create();
        void Create(Lesson model);
        void Delete(int id);
        Lesson Edit(int id);
        void Edit(Lesson model);        
    }
}
