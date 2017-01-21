using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HexagonArchitecture.Domain.Interfaces.Data;
using HexagonArchitecture.Infrastructure.Data;
using HexagonArchitecture.Infrastructure.Interfaces;

namespace HexagonArchitecture.Infrastructure.Components
 {
     public static class ServiceProvider
     {
         private static IContainer _container;
         private static IServiceProvider _provider;

         private static void InitializeContainer()
         {
             var buider = new ContainerBuilder();
             buider.RegisterInstance(typeof(BlogsDbContext)).SingleInstance();
             buider.RegisterType<EfDataSource>()
                 .As(typeof(IQueryableDataSource), typeof(IModifiableDataSource))
                 .WithParameter(parameterName: "context", parameterValue: _container.Resolve<BlogsDbContext>());
             buider.RegisterType<StaticAutoMapper>().As(typeof(IMapper), typeof(IProjector));

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