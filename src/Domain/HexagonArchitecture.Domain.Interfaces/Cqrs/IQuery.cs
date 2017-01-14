using System.Threading.Tasks;
using JetBrains.Annotations;

namespace HexagonArchitecture.Domain.Interfaces.Cqrs
{
    #region Using

    #endregion

    [PublicAPI]
    public interface IQuery<out TOutput>
    {
        TOutput Ask();
    }

    [PublicAPI]
    public interface IQuery<in TSpecification, out TOutput>
    {
        TOutput Ask([NotNull] TSpecification spec);
    }

    [PublicAPI]
    public interface IAsyncQuery<TOutput>
        : IQuery<Task<TOutput>>
    {
    }


    [PublicAPI]
    public interface IAsyncQuery<in TSpecification, TOutput>
        : IQuery<TSpecification, Task<TOutput>>
    {
    }
}