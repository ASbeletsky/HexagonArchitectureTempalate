using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace HexagonArchitecture.Infrastructure.Interfaces
{
    #region Using

    #endregion

    public static class ServiceProvider
    {
        private static IServiceProviderEx _provider;

        public static IServiceProviderEx Current
        {
            get
            {
                if (_provider != null) return _provider;
                _provider = new AutofacServiceProviderEx();
                return _provider;
            }
        }
    }

    internal class AutofacServiceProviderEx : IServiceProviderEx
    {
        private IContainer _container;
        private readonly AutofacServiceProvider _autofac;

        public AutofacServiceProviderEx()
        {
            InitializeContainer();
            this._autofac = new AutofacServiceProvider(_container);
        }

        public object GetService(Type serviceType)
        {
            return this._autofac.GetService(serviceType);
        }

        public TService GetService<TService>()
        {
            return (TService) this.GetService(typeof(TService));
        }

        private void InitializeContainer()
        {
            var builder = new ContainerBuilder();
            var containerAssembly = Assembly.Load(new AssemblyName("HexagonArchitecture.Infrastructure.Components"));;
            builder.RegisterAssemblyModules(containerAssembly);
            _container = builder.Build();
        }
    }
}