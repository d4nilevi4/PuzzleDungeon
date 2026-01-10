using System.Threading;
using Cysharp.Threading.Tasks;

namespace PuzzleDungeon.Core.SceneLoading
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(string sceneName, SceneLoadMode loadMode, CancellationToken cancellationToken);
    }
}