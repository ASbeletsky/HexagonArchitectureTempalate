namespace HexagonArchitecture.Infrastructure.Interfaces
{
    #region Using

    using System;

    #endregion

    public interface ITypeAssociation
    {
        Type EntityType { get; }
    }
}