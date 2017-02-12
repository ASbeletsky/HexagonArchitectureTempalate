namespace HexagonArchitecture.Domain.Common.Sqrs
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Specifications;
    using HexagonArchitecture.Infrastructure.Interfaces;

    #endregion

    public class CommandAndQueryFactory : ICommandFactory, IQueryFactory
    {
        private readonly IServiceProviderEx _serviceProvider;

        public CommandAndQueryFactory(IServiceProviderEx serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public TCommand GetCommand<TData, TCommand>() where TCommand : ICommandHandler<TData>
        {
            return (TCommand) _serviceProvider.GetService<ICommandHandler<TData>>();
        }

        public ICreateOrUpdateEntityCommand<TEntity> GetSaveCommand<TEntity>() where TEntity : class, IEntity
        {
            return _serviceProvider.GetService<ICreateOrUpdateEntityCommand<TEntity>>();
        }

        public ICreateOrUpdateEntityCommand<TDto, TEntity> GetSaveCommand<TDto, TEntity>()
            where TEntity : class, IEntity
            where TDto: IHasId
        {
            return _serviceProvider.GetService<ICreateOrUpdateEntityCommand<TDto, TEntity>>();
        }

        public IDeleteEntityCommand<TKey, TEntity> GetDeleteCommand<TKey, TEntity>()
            where TEntity : class, IEntity<TKey>
        {
            return _serviceProvider.GetService<IDeleteEntityCommand<TKey, TEntity>>();
        }


        public TQuery GetQuery<TResult, TQuery>() where TQuery : IQuery<TResult>
        {
            return (TQuery)_serviceProvider.GetService<IQuery<TResult>>();
        }

        public TQuery GetQuery<TData, TResult, TQuery>() where TQuery : IQuery<TData, TResult>
        {
            return (TQuery)_serviceProvider.GetService<IQuery<TData, TResult>>();
        }

        public IEntityQuery<TEntity> QueryEntity<TEntity>()
            where TEntity : class, IEntity
        {
            return _serviceProvider.GetService<IEntityQuery<TEntity>>();
        }
    }
}