namespace HexagonArchitecture.Domain.Interfaces.Data
{
    #region Using

    using System;
    using JetBrains.Annotations;

    #endregion

    public abstract class DataSourceBased
    {
        protected readonly IModifiableDataSource DataSource;

        protected DataSourceBased([NotNull] IModifiableDataSource dataSource)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            this.DataSource = dataSource;
        }
    }
}