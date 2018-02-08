using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(Demo.Startup))]

namespace Demo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            var configuration = new HttpConfiguration();
            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            configuration.MapHttpAttributeRoutes();

            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            // Register Web API controller in executing assembly.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL - Register the filter provider if you have custom filters that need DI.
            // Also hook the filters up to controllers.
            builder.RegisterWebApiFilterProvider(configuration);

            // Autofac will add middleware to IAppBuilder in the order registered.
            // The middleware will execute in the order added to IAppBuilder.
            // Create and assign a dependency resolver for Web API to use.
            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(configuration);

            app.UseWebApi(configuration);
        }

        //注入
        private void SetupResolveRules(ContainerBuilder builder)
        {
            //跨程序集注册
            var descriptorsBuiness = Assembly.Load("UserService");
            builder.RegisterAssemblyTypes(descriptorsBuiness)
                .Where(t => t.Name.EndsWith("Service") && !t.IsAbstract)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }

    }
}
