using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Interactions;

public sealed class InteractionsFeature : CustomFeature
{
    public InteractionsFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<CheckMouseHoverSystem>());
    }
}