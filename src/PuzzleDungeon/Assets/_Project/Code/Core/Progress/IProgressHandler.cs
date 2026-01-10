#nullable enable
namespace PuzzleDungeon.Core.Progress;

public interface IProgressHandler<TProgress> where TProgress : IProgress
{
    TProgress? LoadProgress();
    TProgress CreateNewProgress();
    void SaveProgress(TProgress progress);
}