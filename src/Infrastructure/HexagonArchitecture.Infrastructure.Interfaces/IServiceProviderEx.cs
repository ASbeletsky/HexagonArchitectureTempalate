using System;

namespace HexagonArchitecture.Infrastructure.Interfaces
{
    public interface IServiceProviderEx : IServiceProvider
    {
        TService GetService<TService>();
    }
}