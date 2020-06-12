using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ExamService.Application.Main.Product.Services;
using ExamService.Application.Main.User.Services;
using ExamService.DataAccess.Main.Product;
using ExamService.DataAccess.Main.UnitOfWork;
using ExamService.DataAccess.Main.User;
using ExamService.Domain.Main.Product.Aggregates;
using ExamService.Domain.Main.User.Aggregates;
using ExamService.Infrastructure.Main.Adapter;
using ExamService.Infrastructure.Main.Validator;
using ExamService.Infrastructure.Seed.Adapter;
using ExamService.Infrastructure.Seed.Validator;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace ExamService.Services.Main.App_Start
{
    public class DependencyInjectionConfig
    {
        public static HttpConfiguration Configuration { get; private set; }
        public static IContainer Container { get; private set; }

        public static void RegisterDependencies()
        {
            ConfigureInterfaces();
            ConfigureFactories();
        }

        static void ConfigureInterfaces()
        {
            Configuration = new HttpConfiguration();

            Configuration.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });

            Configuration.Formatters.Clear();
            Configuration.Formatters.Add(new JsonMediaTypeFormatter());
            Configuration.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

            var builder = new ContainerBuilder();

            //builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerRequest();
            builder.RegisterType<ProductApplicationService>().As<IProductApplicationService>().InstancePerRequest();

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<UserApplicationService>().As<IUserApplicationService>().InstancePerRequest();

            // Registro de la Unidad de Trabajo
            builder.Register(c => new MainUnitOfWork()).As<MainUnitOfWork>().InstancePerLifetimeScope();

            // Poner Autofac como el resolvedor de dependencias
            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

        static void ConfigureFactories()
        {
            try
            {
                EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
                TypeAdapterFactory.SetCurrent(new AutomapperTypeAdapterFactory());
            }
            catch (Exception exception)
            {
                var aramis = exception.Message;
            }
        }
    }
}