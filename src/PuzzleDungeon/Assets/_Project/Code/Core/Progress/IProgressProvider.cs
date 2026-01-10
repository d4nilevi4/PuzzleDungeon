namespace PuzzleDungeon.Core.Progress;

public interface IProgressProvider<out TProgress>
    where TProgress : IProgress
{
    TProgress Progress { get; }
}

public interface IProgressContainer<in TProgress>
    where TProgress : IProgress
{
    TProgress Progress { set; }
}