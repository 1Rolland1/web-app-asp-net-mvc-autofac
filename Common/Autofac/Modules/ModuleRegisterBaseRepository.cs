using System.Linq;
using Autofac;
using Common.Entity;
using Common.Repository;

namespace Common.Autofac.Modules
{
    public class ModuleRegisterBaseRepository<TEntityModel, TContext> : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var typeContext = typeof(TContext);

            var types = typeof(TEntityModel).Assembly.GetTypes()
                .Where(t => typeof(IEntityBase).IsAssignableFrom(t) && typeof(TEntityModel).IsAssignableFrom(t))
                .ToList();

            types.ForEach(t =>
                builder.RegisterType(typeof(BaseRepository<,>).MakeGenericType(typeContext, t))
                    .As(typeof(IRepository<>).MakeGenericType(t))
            );
        }

    }
}
