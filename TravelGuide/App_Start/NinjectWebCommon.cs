[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TravelGuide.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TravelGuide.App_Start.NinjectWebCommon), "Stop")]

namespace TravelGuide.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Data;
    using Services.Contracts;
    using Services.Articles;
    using Ninject.Extensions.Factory;
    using Services.Factories;
    using Services.GalleryImages.Contracts;
    using Services.GalleryImages;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static IKernel Kernel { get; private set; }

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
            Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(Kernel);
                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ITravelGuideContext>().To<TravelGuideContext>().InRequestScope();

            kernel.Bind<IArticleService>().To<ArticleService>();
            kernel.Bind<IGalleryImageService>().To<GalleryImageService>();
            
            kernel.Bind<IArticleFactory>().ToFactory();
            kernel.Bind<IGalleryImageFactory>().ToFactory();
            kernel.Bind<IGalleryLikeFactory>().ToFactory();
            kernel.Bind<IGalleryCommentFactory>().ToFactory();
            kernel.Bind<IStoreItemFactory>().ToFactory();
        }        
    }
}
