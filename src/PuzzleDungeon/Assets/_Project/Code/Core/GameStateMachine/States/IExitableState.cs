using System.Threading;
using Cysharp.Threading.Tasks;

namespace PuzzleDungeon.Core.GameStateMachine;

public interface IExitableState
{
    UniTask Exit(CancellationToken cancellationToken);
}