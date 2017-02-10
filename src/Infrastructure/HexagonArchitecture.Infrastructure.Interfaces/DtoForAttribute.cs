using System;

namespace HexagonArchitecture.Infrastructure.Interfaces
{
    public class DtoForAttribute : Attribute, ITypeAssociation
    {
        public DtoForAttribute(Type entityType)
        {
            this.EntityType = entityType;
        }

        public Type EntityType { get; }
    }
}