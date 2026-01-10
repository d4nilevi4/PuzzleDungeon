using System.Threading;
using Cysharp.Threading.Tasks;

namespace PuzzleDungeon.Core.GameStateMachine;

public interface IGameStateMachine
{
    UniTask Enter<TState>(CancellationToken cancellationToken) where TState : class, IState;
    UniTask Enter<TState, TPayload>(TPayload payload, CancellationToken cancellationToken) where TState : class, IPayloadState<TPayload>;
}