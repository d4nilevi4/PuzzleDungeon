using System.Threading;
using Cysharp.Threading.Tasks;

namespace PuzzleDungeon.Core.GameStateMachine;

public class CommonGameStateMachine : IGameStateMachine
{
    private readonly IStateFactory _stateFactory;
    private IExitableState _activeState;

    public CommonGameStateMachine(
        IStateFactory stateFactory)
    {
        _stateFactory = stateFactory;
    }

    public async UniTask Enter<TState>(CancellationToken cancellationToken) where TState : class, IState
    {
        TState state = await ChangeState<TState>(cancellationToken);
        await state.Enter(cancellationToken);
    }

    public async UniTask Enter<TState, TPayload>(TPayload payload, CancellationToken cancellationToken)
        where TState : class, IPayloadState<TPayload>
    {
        TState state = await ChangeState<TState>(cancellationToken);
        await state.Enter(payload, cancellationToken);
    }

    private async UniTask<TState> ChangeState<TState>(CancellationToken cancellationToken) where TState : class, IExitableState
    {
        if (_activeState != null)
            await _activeState.Exit(cancellationToken);

        TState state = _stateFactory.GetState<TState>();
        _activeState = state;

        return state;
    }
}