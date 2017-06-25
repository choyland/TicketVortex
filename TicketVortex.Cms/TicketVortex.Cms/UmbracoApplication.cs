using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace TicketVortex.Cms
{
    public class UmbracoApplication : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
           
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var builder = new ContainerBuilder();

            // Register all controllers found in this assembly
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(Umbraco.Web.UmbracoApplication).Assembly);
            builder.RegisterApiControllers(typeof(Umbraco.Web.UmbracoApplication).Assembly);

            // Add types to be resolved
            RegisterTypes(builder, applicationContext);

            // Configure Http and Controller Resolvers
            var container = builder.Build();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void RegisterTypes(ContainerBuilder builder, ApplicationContext context)
        {
            builder.RegisterInstance(context.Services.ContentService)
                .As<IContentService>();
        }
    }
}