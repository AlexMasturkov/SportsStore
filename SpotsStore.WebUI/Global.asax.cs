using SportsStore.WebUI;
using SportsStore.WebUI.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;

namespace SpotsStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }   
    }
}
