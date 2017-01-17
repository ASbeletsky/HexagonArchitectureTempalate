﻿namespace HexagonArchitecture.Services.Common.Sqrs.GenericCommands
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using JetBrains.Annotations;

    #endregion

    /// <summary>
    /// Creates a new or updates existing entity from its DTO
    /// </summary>
    /// <typeparam name="TKey">Entity identifier</typeparam>
    /// <typeparam name="TDto">DTO representation of entity</typeparam>
    /// <typeparam name="TEntity">Entity to add or update</typeparam>
    public class CreateOrUpdateHandler<TKey, TDto, TEntity> : DataSourceBased, ICommandHandler<TDto, TKey>
        where TEntity : EntityBase<TKey>
    {
        private IMapper _mapper;

        public CreateOrUpdateHandler([NotNull] IModifiableDataSource dataSource, [NotNull] IMapper mapper) : base(dataSource)
        {
            this._mapper = mapper;
        }

        public TKey Handle(TDto dto)
        {
            var id = (dto as IHasId)?.Id;
            bool isNewEntity = id != null && !id.Equals(default(TKey));
            var entity = isNewEntity ? _mapper.Map<TDto, TEntity>(dto) : _mapper.Map(dto, DataSource.Find<TEntity>(id));
            DataSource.AddOrUpdate(entity);
            DataSource.SaveChanges();
            return entity.Id;
        }
    }
}