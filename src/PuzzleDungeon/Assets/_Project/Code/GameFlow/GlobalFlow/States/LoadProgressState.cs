using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleDungeon.Core.GameStateMachine;
using PuzzleDungeon.Core.Progress;

namespace PuzzleDungeon.GameFlow.Global;

public class LoadProgressState<TProgress> : IState where TProgress : IProgress
{
    private readonly IProgressHandler<TProgress> _progressHandler;
    private readonly IProgressContainer<TProgress> _progressContainer;

    public LoadProgressState(
        IProgressHandler<TProgress> progressHandler,
        IProgressContainer<TProgress> progressContainer)
    {
        _progressHandler = progressHandler;
        _progressContainer = progressContainer;
    }

    public UniTask Enter(CancellationToken cancellationToken)
    {
        TProgress playerProgress = _progressHandler.LoadProgress() ?? 
                                   _progressHandler.CreateNewProgress();

        _progressContainer.Progress = playerProgress;

        return UniTask.CompletedTask;
    }

    public UniTask Exit(CancellationToken cancellationToken) =>
        UniTask.CompletedTask;
}