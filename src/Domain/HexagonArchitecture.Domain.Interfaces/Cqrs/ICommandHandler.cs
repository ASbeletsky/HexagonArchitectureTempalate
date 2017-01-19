using System.Threading.Tasks;
using JetBrains.Annotations;

namespace HexagonArchitecture.Domain.Interfaces.Cqrs
{
    #region Using

    #endregion

    [PublicAPI]
    public interface ICommandHandler<in TInput>
    {
        void Execute(TInput input);
    }

    [PublicAPI]
    public interface ICommandHandler<in TInput, out TOutput>
    {
        TOutput Execute(TInput input);
    }

    [PublicAPI]
    public interface IAsyncCommandHandler<in TInput>
        : ICommandHandler<TInput, Task>
    {
    }

    [PublicAPI]
    public interface IAsyncCommandHandler<in TInput, TOutput>
        : ICommandHandler<TInput, Task<TOutput>>
    {
    }
}