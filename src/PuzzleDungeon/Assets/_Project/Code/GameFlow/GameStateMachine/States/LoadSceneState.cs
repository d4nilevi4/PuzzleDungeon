using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleDungeon.Core.GameStateMachine;
using PuzzleDungeon.Core.Logger;
using PuzzleDungeon.Core.SceneLoading;

namespace PuzzleDungeon.GameFlow.GameStateMachine;

public class LoadSceneState : IPayloadState<string>
{
    private readonly ISceneLoader _sceneLoader;
    private readonly ILogger _logger;

    public LoadSceneState(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
    
    public async UniTask Enter(string payload, CancellationToken cancellationToken)
    {
        // Curtain.Show();
        await _sceneLoader.LoadSceneAsync(payload, SceneLoadMode.Single, cancellationToken);
        // Curtain.Hide();
    }

    public UniTask Exit(CancellationToken cancellationToken)
    {
        return UniTask.CompletedTask;
    }
}