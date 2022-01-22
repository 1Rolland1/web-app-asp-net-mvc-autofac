using Autofac;
using Autofac.Integration.Mvc;
using Common.Autofac.Modules;
using Common.Entity;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();


            builder.RegisterType<TimetableContext>().AsSelf().InstancePerHttpRequest();
            builder.RegisterModule(new ModuleRegisterBaseRepository<IDataContext, TimetableContext>());
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            builder.RegisterType<LessonService>().As<ILessonService>();
            builder.RegisterType<GroupService>().As<IGroupService>();
            builder.RegisterType<TeacherService>().As<ITeacherService>();
            builder.RegisterType<DisciplineService>().As<IDisciplineService>();            

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
