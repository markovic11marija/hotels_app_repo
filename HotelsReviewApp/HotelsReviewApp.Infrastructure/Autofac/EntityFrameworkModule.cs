using System;
using System.Linq;
using Autofac;
using HotelsReviewApp.Infrastructure.Data;
using HotelsReviewApp.Infrastructure.Data.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelsReviewApp.Infrastructure.Autofac
{
    public class EntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.RegisterGeneric(typeof(EntityFrameworkRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope(); 

            builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly)
                .Where(
                    type =>
                        ImplementsInterface(typeof(IRepository<>), type) ||
                        type.Name.EndsWith("Repository")
                ).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.Register(CreateDbContextOptions).As<DbContextOptions>().SingleInstance();

            builder.RegisterType<HotelsReviewDbContext>().AsSelf().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<DbContextUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }

        private static bool ImplementsInterface(Type interfaceType, Type concreteType)
        {
            return
                concreteType.GetInterfaces().Any(
                    t =>
                        (interfaceType.IsGenericTypeDefinition && t.IsGenericType
                            ? t.GetGenericTypeDefinition()
                            : t) == interfaceType);
        }

        private DbContextOptions CreateDbContextOptions(IComponentContext container)
        {
            var configuration = container.Resolve<IConfiguration>();

            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("HotelsReviewDbContext"),
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("HotelsReviewApp.Infrastructure.Data.Ef");
                });

            return optionsBuilder.Options;
        }
    }
}
