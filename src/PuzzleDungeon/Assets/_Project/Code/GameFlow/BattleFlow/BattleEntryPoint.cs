using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleDungeon.Core.GameStateMachine;
using VContainer.Unity;

namespace PuzzleDungeon.GameFlow.Battle;

public class BattleEntryPoint : IAsyncStartable
{
    private readonly IGameStateMachine _gameStateMachine;

    public BattleEntryPoint(
        IGameStateMachine gameStateMachine
    )
    {
        _gameStateMachine = gameStateMachine;
    }
    
    public async UniTask StartAsync(CancellationToken cancellation)
    {
        // asynchronous initialization if needed
        
        await _gameStateMachine.Enter<BattleLoopState>(cancellation);
    }
}