using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PuzzleDungeon.Infrastructure;

public class LoadSceneState : IPayloadState<string>
{
    private readonly ISceneLoader _sceneLoader;

    public LoadSceneState(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
    
    public async UniTask Enter(string payload, CancellationToken cancellationToken)
    {
        Debug.Log($"LoadSceneState: Entering scene '{payload}'");
        // Curtain.Show();
        await _sceneLoader.LoadSceneAsync(payload, SceneLoadMode.Single, cancellationToken);
        // Curtain.Hide();
    }

    public UniTask Exit(CancellationToken cancellationToken)
    {
        return UniTask.CompletedTask;
    }
}