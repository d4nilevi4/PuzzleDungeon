using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace PuzzleDungeon.Infrastructure;

public interface IState : IExitableState
{
    [MustUseReturnValue]
    UniTask Enter(CancellationToken cancellationToken);
}