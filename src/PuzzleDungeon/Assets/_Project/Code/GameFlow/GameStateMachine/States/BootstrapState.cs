using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleDungeon.Core.GameStateMachine;

namespace PuzzleDungeon.GameFlow.GameStateMachine;

public class BootstrapState : IState
{
    
    public UniTask Enter(CancellationToken cancellationToken)
    {
        // Initialize services, load configurations, etc. at startup.
        return UniTask.CompletedTask;
    }

    public UniTask Exit(CancellationToken cancellationToken)
    {
        return UniTask.CompletedTask;
    }
}