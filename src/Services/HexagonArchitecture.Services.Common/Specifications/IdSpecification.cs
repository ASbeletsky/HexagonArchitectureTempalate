namespace HexagonArchitecture.Services.Common.Specifications
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
    using JetBrains.Annotations;

    #endregion

    [PublicAPI]
    public class IdSpecification<TKey, T> : ExpressionSpecification<T> where T : IHasId
    {
        public IdSpecification(TKey id) : base(entity => entity.Id.Equals(id))
        {
            Id = id;
        }

        public TKey Id { get; private set; }
    }
}