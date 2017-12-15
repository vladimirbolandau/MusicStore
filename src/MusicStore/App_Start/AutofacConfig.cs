using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using MusicStore.Business;
using MusicStore.Business.Providers;
using MusicStore.Repository;
using System.Reflection;

namespace MusicStore.App_Start
{
    public static class AutofacConfig
    {
        public static void SetUpContainer()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            SetupDependencies(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void SetupDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<NewReleasesService>().As<IReleasesService>();
            builder.RegisterType<JsonProvider>().As<IReleasesProvider>();
            builder.RegisterType<CacheRepository>().As<ICacheRepository>();
            builder.RegisterType<ReleasesRepository>().As<IReleasesRepository>();
            builder.RegisterType<JsonRepository>().As<IJsonRepository>();
            builder.RegisterType<XmlRepository>().As<IXmlRepository>();
        }
    }
}