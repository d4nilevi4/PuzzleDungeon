using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Destruction;

public sealed class DestructionFeature : CustomFeature
{
    public DestructionFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<DestroyGameEventsCleanupSystem>());
        Add(systemFactory.Create<DestroyInputEventsCleanupSystem>());
    }
}