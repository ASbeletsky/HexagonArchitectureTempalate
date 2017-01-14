namespace HexagonArchitecture.Infrastructure.Interfaces
{
    #region Using

    using JetBrains.Annotations;

    #endregion

    [PublicAPI]
    public interface IMapper
    {
        TDest Map<TSource, TDest>(TSource src);

        TDest Map<TSource, TDest>(TSource src, TDest dest);
    }
}