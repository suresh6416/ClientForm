using ClientRequest.Controllers;
using ClientRequest.Services.Contracts;
using ClientRequest.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Injection;

namespace ClientRequest.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer GetConfiguredContainer()
        {

            var container = new UnityContainer();
            // Register controller
            container.RegisterType<AccountController>();
            container.RegisterType<ModuleController>();

            // Register interface
            container.RegisterType<IModuleService, ModuleService>();

            //This is done in Startup instead.
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return container;
        }
    }
}