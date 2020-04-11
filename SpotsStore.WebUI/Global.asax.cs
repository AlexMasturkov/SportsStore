using SportsStore.Domain.Entities;
using SportsStore.WebUI;
using SportsStore.WebUI.Infrastructure;
using SpotsStore.WebUI.Binders;
using System.Web.Mvc;
using System.Web.Routing;

namespace SpotsStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
