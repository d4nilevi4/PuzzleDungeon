using System.Threading;
using Cysharp.Threading.Tasks;

namespace PuzzleDungeon.Infrastructure;

public class BootstrapState : IState
{
    private readonly IGameStateMachine _gameStateMachine;

    public BootstrapState(
        IGameStateMachine gameStateMachine
    )
    {
        _gameStateMachine = gameStateMachine;
    }
    
    public UniTask Enter(CancellationToken cancellationToken)
    {
        return _gameStateMachine.Enter<LoadProgressState>(cancellationToken);
    }

    public UniTask Exit(CancellationToken cancellationToken)
    {
        return UniTask.CompletedTask;
    }
}