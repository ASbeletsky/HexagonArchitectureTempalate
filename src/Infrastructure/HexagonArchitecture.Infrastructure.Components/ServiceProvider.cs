using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace HexagonArchitecture.Infrastructure.Components
 {
     public static class ServiceProvider
     {
         private static IContainer _container;
         private static IServiceProvider _provider;

         private static void InitializeContainer()
         {
             var buider = new ContainerBuilder();


             _container = buider.Build();
         }

         public static IServiceProvider CurrentServiceProvider
         {
             get
             {
                 if (_provider != null) return _provider;
                 InitializeContainer();
                 _provider = new AutofacServiceProvider(_container);
                 return _provider;
             }
         }
     }
 }