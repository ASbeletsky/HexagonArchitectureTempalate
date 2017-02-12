using System;

namespace HexagonArchitecture.Domain.Common.Sqrs.GenericCommandHandlers
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using JetBrains.Annotations;

    #endregion

    /// <summary>
    /// Creates a new or updates existing entity from dto
    /// </summary>
    /// <typeparam name="TDto">DTO representation of entity</typeparam>
    /// <typeparam name="TEntity">Entity to add or update</typeparam>
    public class CreateOrUpdateFromDtoHandler<TDto, TEntity> : DataSourceBased, ICreateOrUpdateEntityCommand<TDto, TEntity>
        where TDto : IHasId
        where TEntity : class, IEntity
    {
        private IMapper _mapper;

        public CreateOrUpdateFromDtoHandler([NotNull] IModifiableDataSource dataSource, [NotNull] IMapper mapper) : base(dataSource)
        {
            this._mapper = mapper;
        }

        [Obsolete]
        public object Execute(TDto dto)
        {
            return this.Execute<object>(dto);
        }

        public TKey Execute<TKey>(TDto dto)
        {
            var id = (dto as IHasId)?.Id;
            bool isNewEntity = id == null || id.Equals(default(TKey));
            var entity = isNewEntity ? _mapper.Map<TDto, TEntity>(dto) : _mapper.Map(dto, DataSource.Find<TEntity>(id));
            DataSource.AddOrUpdate(entity);
            DataSource.SaveChanges();
            return (TKey) entity.Id;
        }
    }
}