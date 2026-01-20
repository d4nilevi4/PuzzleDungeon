using Leontitas;
using UnityEngine;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class HandleEndDraggingForInHandTileSystem : IExecuteSystem
{
    private readonly GameGroup _inHandTiles;

    public HandleEndDraggingForInHandTileSystem()
    {
        _inHandTiles = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.GameBoardTileInHand,
                GameMatcher.UpdateTargetPositionByDraggingTileAnchor,
                GameMatcher.DraggingTileAnchorPosition)
            .NoneOf(
                GameMatcher.Dragging));
    }
    
    public void Execute()
    {
        foreach (GameEntity inHandTile in _inHandTiles)
        {
            inHandTile.IsUpdateTargetPositionByInHandTileAnchor = true;
            inHandTile.IsUpdateTargetPositionByDraggingTileAnchor = false;
            
            inHandTile.RemoveDraggingTileAnchorPosition();
        }
    }
}