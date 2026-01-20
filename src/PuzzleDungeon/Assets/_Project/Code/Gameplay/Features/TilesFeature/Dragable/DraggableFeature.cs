using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class DraggableFeature : CustomFeature
{
    public DraggableFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<AddDraggingFlagByInteractionInputEventSystem>());
        Add(systemFactory.Create<RemoveDraggingFlagByInteractionInputEventSystem>());
        
        Add(systemFactory.Create<HandleStartDraggingForInHandTileSystem>());
        Add(systemFactory.Create<HandleEndDraggingForInHandTileSystem>());
        
        Add(systemFactory.Create<UpdateDraggingAnchorSystem>());
        
        Add(systemFactory.Create<ApplyDraggingAnchorToTargetPositionSystem>());
    }
}