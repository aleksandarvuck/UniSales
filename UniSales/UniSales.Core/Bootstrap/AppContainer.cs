using Autofac;
using System;
using UniSales.Core.Contracts.Services.General;
using UniSales.Core.Services.General;

namespace UniSales.Core.Bootstrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //services - general
            //services - general
            builder.RegisterType<ConnectionService>().As<IConnectionService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            //builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<PhoneService>().As<IPhoneService>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}