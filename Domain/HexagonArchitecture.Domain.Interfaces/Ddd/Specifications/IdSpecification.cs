namespace HexagonArchitecture.Domain.Interfaces.Ddd.Specifications
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using JetBrains.Annotations;

    #endregion

    [PublicAPI]
    public class IdSpecification<TKey, T> : ExpressionSpecification<T> where T : IEntity
    {
        public IdSpecification(TKey id) : base(entity => entity.Id.Equals(id))
        {
            Id = id;
        }

        public TKey Id { get; private set; }
    }
}