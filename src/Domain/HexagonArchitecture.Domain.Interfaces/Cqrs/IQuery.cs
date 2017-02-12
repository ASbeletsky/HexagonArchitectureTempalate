namespace HexagonArchitecture.Domain.Interfaces.Cqrs
{
    #region Using

    using System.Threading.Tasks;
    using JetBrains.Annotations;

    #endregion

    [PublicAPI]
    public interface IQuery<out TOutput>
    {
        TOutput Ask();
    }

    [PublicAPI]
    public interface IQuery<in TIn, out TOutput>
    {
        TOutput Ask(TIn data);
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