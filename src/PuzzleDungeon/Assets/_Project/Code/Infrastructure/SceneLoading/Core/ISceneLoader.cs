using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace PuzzleDungeon.Infrastructure
{
    public interface ISceneLoader
    {
        [MustUseReturnValue]
        UniTask LoadSceneAsync(string sceneName, SceneLoadMode loadMode, CancellationToken cancellationToken);
    }
}