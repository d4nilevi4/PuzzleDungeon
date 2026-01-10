using PuzzleDungeon.Core.Progress;
using PuzzleDungeon.Gameplay.Progress;

namespace PuzzleDungeon.Unity.Progress;

public class PlayerProgressProvider :
    IProgressProvider<PlayerProgress>,
    IProgressContainer<PlayerProgress>
{
    public PlayerProgress Progress { get; set; }
}