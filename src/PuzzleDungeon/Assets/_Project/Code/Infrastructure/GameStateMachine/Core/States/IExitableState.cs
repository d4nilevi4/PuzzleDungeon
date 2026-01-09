using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace PuzzleDungeon.Infrastructure;

public interface IExitableState
{
    [MustUseReturnValue]
    UniTask Exit(CancellationToken cancellationToken);
}