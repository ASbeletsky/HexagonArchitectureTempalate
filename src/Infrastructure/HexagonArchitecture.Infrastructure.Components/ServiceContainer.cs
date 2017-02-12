using System.Reflection;
using HexagonArchitecture.Domain.Common.Specifications;
using HexagonArchitecture.Domain.Common.Sqrs;
using HexagonArchitecture.Domain.Interfaces.Cqrs;
using HexagonArchitecture.Domain.Common.Sqrs.GenericCommandHandlers;
using HexagonArchitecture.Domain.Common.Sqrs.GenericQueries;
using HexagonArchitecture.Domain.Core.Entities;
using HexagonArchitecture.Services.Dto;

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
            builder.RegisterType<InstanceAutoMapper>().As(typeof(IMapper), typeof(IProjector));
            builder.RegisterType<EfDataSource>().As(typeof(IQueryableDataSource), typeof(IModifiableDataSource));
            RegisterCommandsAndQueries(builder);
            builder.RegisterType<CommandAndQueryFactory>()
                .As(typeof(ICommandFactory), typeof(IQueryFactory))
                .WithParameter("serviceProvider", _container);


        }

        private void RegisterCommandsAndQueries(ContainerBuilder builder)
        {
            var domainCommonAssembly = Assembly.Load(new AssemblyName("HexagonArchitecture.Domain.Common"));
             builder.RegisterAssemblyTypes(domainCommonAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(domainCommonAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<,>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(domainCommonAssembly)
                .AsClosedTypesOf(typeof(IQuery<>))
                .AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(CreateOrUpdateHandler<>)).As(typeof(ICreateOrUpdateEntityCommand<>));
            builder.RegisterGeneric(typeof(CreateOrUpdateFromDtoHandler<,>)).As(typeof(ICreateOrUpdateEntityCommand<,>));
            builder.RegisterGeneric(typeof(DeleteHandler<,>)).As(typeof(IDeleteEntityCommand<,>));

            builder.RegisterType<GetByIdQuery<int, Post>>().As<IQuery<IdSpecification<int, Post>, Post>>();
            builder.RegisterType<GetByIdQuery<int, Post, PostDto>>().As<IQuery<IdSpecification<int, Post>, PostDto>>();
        }
    }
}