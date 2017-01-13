namespace HexagonArchitectureTempalate.Services.Common.Sqrs.GenericCommands
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Cqrs;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using JetBrains.Annotations;

    #endregion

    public class CreateOrUpdateHandler<TKey, TDto, TEntity> : UnitOfWorkBased, ICommandHandler<TDto, TKey>
        where TEntity : EntityBase<TKey>
    {
        private IMapper _mapper;

        public CreateOrUpdateHandler([NotNull] IUnitOfWork unitOfWork, [NotNull] IMapper mapper)   : base(unitOfWork)
        {
            this._mapper = mapper;
        }

        public TKey Handle(TDto input)
        {
            var id = (input as IEntity)?.Id;
            var entity = id != null && !id.Equals(default(TKey))
                        ? _mapper.Map(input, UnitOfWork.Find<TEntity>(id))
                        : _mapper.Map<TDto, TEntity>(input);

            if (entity.IsNew)
            {
                UnitOfWork.Add(entity);
            }

            UnitOfWork.Commit();
            return entity.Id;
        }
    }
}