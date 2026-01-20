using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class HandFeature : CustomFeature
{
    public HandFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<AssignHandSystem>());
        
        Add(systemFactory.Create<InHandTileAnchorsFeature>());
    }
}