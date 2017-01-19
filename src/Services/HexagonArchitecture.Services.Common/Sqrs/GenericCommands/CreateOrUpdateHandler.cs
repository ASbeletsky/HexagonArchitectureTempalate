#region Using

using HexagonArchitecture.Domain.Interfaces.Cqrs;
using HexagonArchitecture.Domain.Interfaces.Data;
using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
using HexagonArchitecture.Infrastructure.Interfaces;
using JetBrains.Annotations;

#endregion

namespace HexagonArchitecture.Services.Common.Sqrs.GenericCommands
{
    /// <summary>
    /// Creates a new or updates existing entity from dto
    /// </summary>
    /// <typeparam name="TKey">Entity identifier</typeparam>
    /// <typeparam name="TEntity">Entity to add or update</typeparam>
    public class CreateOrUpdateHandler<TKey, TEntity> : DataSourceBased, ICreateOrUpdateEntityCommand<TEntity>
        where TEntity : class, IHasId
    {
        private IMapper _mapper;

        public CreateOrUpdateHandler([NotNull] IModifiableDataSource dataSource, [NotNull] IMapper mapper) : base(dataSource)
        {
            this._mapper = mapper;
        }

        public object Execute(TEntity entity)
        {
            DataSource.AddOrUpdate(entity);
            DataSource.SaveChanges();
            return entity.Id;
        }
    }
}