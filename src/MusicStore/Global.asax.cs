using Autofac;
using Autofac.Integration.Mvc;
using MusicStore.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();

            // You can register controllers all at once using assembly scanning...
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // ...or you can register individual controlllers manually.
            builder.RegisterType<HomeController>().InstancePerRequest();
        }
    }
}
