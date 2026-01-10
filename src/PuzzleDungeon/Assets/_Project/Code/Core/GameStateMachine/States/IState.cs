using System.Threading;
using Cysharp.Threading.Tasks;

namespace PuzzleDungeon.Core.GameStateMachine;

public interface IState : IExitableState
{
    UniTask Enter(CancellationToken cancellationToken);
}