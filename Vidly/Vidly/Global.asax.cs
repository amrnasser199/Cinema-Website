using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using vidly;
using System.Web.Http;
using AutoMapper;
using Vidly.App_Start;
using Unity;

namespace Vidly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

           //var config = new MapperConfiguration(c => {
            //    c.AddProfile<MappingProfile>();
            //});
            //IMapper mapper = config.CreateMapper();

            //AutoMapper.Mapper.Initialize(cfg =>

            //    cfg.AddProfile<MappingProfile>()
            //);
            //AutoMapper.Mapper.Initialize(m=>m.AddProfile<MappingProfile>());

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
