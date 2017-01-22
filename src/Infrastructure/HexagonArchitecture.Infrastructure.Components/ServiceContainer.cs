namespace HexagonArchitecture.Infrastructure.Components
{
    #region Using

    using Autofac;
    using Autofac.Core;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Infrastructure.Data;
    using HexagonArchitecture.Infrastructure.Interfaces;

    #endregion

    public class ServiceContainer : Module
    {
        public ServiceContainer(IComponentContext container)
        {
            _container = container;
        }
        private IComponentContext _container;

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogsDbContext>().AsSelf().SingleInstance();
            builder.RegisterType<StaticAutoMapper>().As(typeof(IMapper), typeof(IProjector));
            builder.RegisterType<EfDataSource>().As(typeof(IQueryableDataSource), typeof(IModifiableDataSource));
        }                      
    }
}