using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace PuzzleDungeon.Infrastructure;

public interface IGameStateMachine
{
    [MustUseReturnValue]
    UniTask Enter<TState>(CancellationToken cancellationToken) where TState : class, IState;
    
    [MustUseReturnValue]
    UniTask Enter<TState, TPayload>(TPayload payload, CancellationToken cancellationToken) where TState : class, IPayloadState<TPayload>;
}