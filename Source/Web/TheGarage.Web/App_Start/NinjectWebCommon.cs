[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TheGarage.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TheGarage.Web.App_Start.NinjectWebCommon), "Stop")]

namespace TheGarage.Web.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using Data;
    using Data.Common.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Infrastructure.Caching;
    using Services.Common.Administration;
    using Services.Administration;
    using Services.Logic;
    using Services.Logic.Contracts;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

               // ObjectFactory.Initialize(kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            RegisterDatabaseServices(kernel);
            RegisterServicesLayerServices(kernel);
        }

        private static void RegisterDatabaseServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<TheGarageDbContext>();
            kernel.Bind<ITheGarageDbContext>().To<TheGarageDbContext>();
            kernel.Bind(typeof(IDeletableEntityRepository<>)).To(typeof(DeletableEntityRepository<>));
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));
            kernel.Bind<ITheGarageData>().To<TheGarageData>();
        }
        private static void RegisterServicesLayerServices(IKernel kernel)
        {
            kernel.Bind<ICacheService>().To<InMemoryCache>();
            kernel.Bind<IMappingService>().To<MappingService>();
            kernel.Bind<IObjectFactory>().To<ObjectFactory>();

            // admin
            kernel.Bind<IUserAdministrationService>().To<UsersAdministrationService>();
            kernel.Bind<IUserRoleAdministrationService>().To<UserRoleAdministrationService>();
            kernel.Bind<IClientAdministrationService>().To<ClientsAdministrationService>();
            kernel.Bind<IGarageAdministrationService>().To<GaragesAdministrationService>();

            //moderatorx
        }
    }
}