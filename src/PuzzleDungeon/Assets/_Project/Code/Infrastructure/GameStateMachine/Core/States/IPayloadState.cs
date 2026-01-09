using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace PuzzleDungeon.Infrastructure;

public interface IPayloadState<in TPayload> : IExitableState
{
    [MustUseReturnValue]
    UniTask Enter(TPayload payload, CancellationToken cancellationToken);
}