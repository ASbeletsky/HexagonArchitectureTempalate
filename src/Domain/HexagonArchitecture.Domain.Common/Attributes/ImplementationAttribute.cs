using System;
using JetBrains.Annotations;

namespace HexagonArchitecture.Domain.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ImplementationAttribute : Attribute
    {
        public ImplementationAttribute([NotNull] Type implementation)
        {
            if (implementation == null) throw new ArgumentNullException(nameof(implementation));
            Implementation = implementation;
        }

        public Type Implementation { get; }
    }
}