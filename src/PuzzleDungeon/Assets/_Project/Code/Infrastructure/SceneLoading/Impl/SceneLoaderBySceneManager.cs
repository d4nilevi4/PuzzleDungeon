using System.ComponentModel;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace PuzzleDungeon.Infrastructure;

public class SceneLoaderBySceneManager : ISceneLoader
{
    public UniTask LoadSceneAsync(string sceneName, SceneLoadMode loadMode, CancellationToken cancellationToken)
    {
        switch (loadMode)
        {
            case SceneLoadMode.Single:
                return SceneManager
                    .LoadSceneAsync(sceneName, LoadSceneMode.Single)
                    .ToUniTask(cancellationToken: cancellationToken);
            case SceneLoadMode.Additive:
                return SceneManager
                    .LoadSceneAsync(sceneName, LoadSceneMode.Additive)
                    .ToUniTask(cancellationToken: cancellationToken);
            default:
                throw new InvalidEnumArgumentException(
                    argumentName: nameof(loadMode), 
                    invalidValue: (int)loadMode, 
                    enumClass: typeof(SceneLoadMode));
        }
    }
}