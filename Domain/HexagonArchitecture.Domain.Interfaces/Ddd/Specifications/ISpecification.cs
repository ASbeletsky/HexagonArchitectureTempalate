namespace HexagonArchitecture.Domain.Interfaces.Ddd.Specifications
{
    #region Using

    using JetBrains.Annotations;

    #endregion

    public interface ISpecification<T>
    {
        bool IsSatisfiedBy([NotNull]T o);
    }
}