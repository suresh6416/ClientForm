using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Unity.AspNet.WebApi;
using ClientRequest.App_Start;

[assembly: OwinStartup(typeof(ClientRequest.Startup))]

namespace ClientRequest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);


            app.UseWebApi(config);
            config.DependencyResolver = new UnityDependencyResolver(
                UnityConfig.GetConfiguredContainer());

            config.Routes.MapHttpRoute(
                         name: "DefaultApi",
                         routeTemplate: "api/{controller}/{id}",
                         defaults: new { id = RouteParameter.Optional }
                     );
            config.Routes.MapHttpRoute(
                          name: "DefaultApiWithParameter",
                          routeTemplate: "api/{controller}/{action}/{id}",
                          defaults: new { id = RouteParameter.Optional }
                      );
        }
    }
}
