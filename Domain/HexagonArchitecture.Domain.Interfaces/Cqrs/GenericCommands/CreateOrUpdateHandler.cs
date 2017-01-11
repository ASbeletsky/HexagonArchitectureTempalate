using HexagonArchitecture.Domain.Interfaces.Data;
using HexagonArchitecture.Domain.Interfaces.Ddd;
using JetBrains.Annotations;

namespace HexagonArchitecture.Domain.Interfaces.Cqrs.GenericCommands
{
    public class CreateOrUpdateHandler<TKey, TDto, TEntity> : UnitOfWorkBased, ICommandHandler<TDto, TKey>
        where TEntity : EntityBase<TKey>
    {
        private IMapper mapper;

        public CreateOrUpdateHandler([NotNull] IUnitOfWork unitOfWork, [NotNull] IMapper mapper)   : base(unitOfWork)
        {
            this.mapper = mapper;
        }

        public TKey Handle(TDto input)
        {
            var id = (input as IEntity)?.Id;
            var entity = id != null && !id.Equals(default(TKey)
                        ? mapper.Map(input, UnitOfWork.Find<TEntity>(id))
                        : mapper.Map<TEntity>(input);

            if (entity.IsNew)
            {
                UnitOfWork.Add(entity);
            }

            UnitOfWork.Commit();
            return entity.Id;
        }
    }
}