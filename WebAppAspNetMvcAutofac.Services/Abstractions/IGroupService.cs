using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface IGroupService
    {
        List<Group> GetEntities();
        Group Create();
        void Create(Group model);
        void Delete(int id);
        Group Edit(int id);
        void Edit(Group model);
    }
}
