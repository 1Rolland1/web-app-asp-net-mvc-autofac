using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface IDisciplineService
    {
        List<Discipline> GetEntities();
        Discipline Create();
        void Create(Discipline model);
        void Delete(int id);
        Discipline Edit(int id);
        void Edit(Discipline model);
    }
}
