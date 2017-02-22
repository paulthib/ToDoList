using Autofac;
using Autofac.Integration.Mvc;
using DataAccessLayer;
using System;
using System.Web.Mvc;

namespace ToDoList.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our Data dependencies
            //builder.RegisterModule(new DataModule("MVCWithAutofacDB"));

            builder.RegisterType(typeof(TaskListManager))
                .As(typeof(ITaskListManager))
                .SingleInstance();

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}