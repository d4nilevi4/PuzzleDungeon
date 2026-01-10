using System.Threading;
using Cysharp.Threading.Tasks;

namespace PuzzleDungeon.Core.GameStateMachine;

public interface IPayloadState<in TPayload> : IExitableState
{
    UniTask Enter(TPayload payload, CancellationToken cancellationToken);
}