namespace HexagonArchitecture.Services.Common.Attributes
{
    #region Using

    using System;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using JetBrains.Annotations;

    #endregion

    public enum MapType : byte
    {
        Any = 0,
        Expression = 1,
        Func = 2
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ProjectionAttribute : Attribute, ITypeAssociation
    {
        public Type EntityType { get; }

        public MapType MapType { get; }

        public ProjectionAttribute([NotNull] Type entityType, MapType mapType = MapType.Any)
        {
            if (entityType == null) throw new ArgumentNullException(nameof(entityType));
            EntityType = entityType;
            MapType = mapType;
        }
    }
}