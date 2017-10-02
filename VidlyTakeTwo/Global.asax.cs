using AutoMapper;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VidlyTakeTwo.App_Start;

namespace VidlyTakeTwo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());//We added this. It's an AutoMapper thing
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
