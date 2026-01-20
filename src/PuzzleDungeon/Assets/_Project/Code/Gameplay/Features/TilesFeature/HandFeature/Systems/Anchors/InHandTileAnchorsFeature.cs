using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class InHandTileAnchorsFeature : CustomFeature
{
    public InHandTileAnchorsFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<AddAnchorToInHandTileSystem>());
        
        // anchor position systems
        Add(systemFactory.Create<HandleHandDeltaForInHandTileAnchorsSystem>());
        Add(systemFactory.Create<CalculateFinalInHandTileAnchorSystem>());
        
        // apply anchor to target position
        Add(systemFactory.Create<ApplyInHandTileAnchorToTargetPositionSystem>());
        
        Add(systemFactory.Create<CleanupInHandTileAnchorDeltasSystem>());
    }
}