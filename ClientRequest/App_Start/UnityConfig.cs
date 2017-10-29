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
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ModuleController>();
            container.RegisterType<JobNatureController>();
            container.RegisterType<ClientController>();
            container.RegisterType<RequestController>();

            // Register interface
            container.RegisterType<IModuleService, ModuleService>();
            container.RegisterType<IJobNatureService, JobNatureService>();
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<IRequestService, RequestService>();

            //This is done in Startup instead.
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return container;
        }
    }
}