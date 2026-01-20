using Leontitas;
using UnityEngine;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class HandleStartDraggingForInHandTileSystem : IExecuteSystem
{
    private readonly GameGroup _inHandTiles;

    public HandleStartDraggingForInHandTileSystem()
    {
        _inHandTiles = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.GameBoardTileInHand,
                GameMatcher.UpdateTargetPositionByInHandTileAnchor,
                GameMatcher.Dragging,
                GameMatcher.Position)
            .NoneOf(
                GameMatcher.DraggingTileAnchorPosition));
    }
    
    public void Execute()
    {
        foreach (GameEntity inHandTile in _inHandTiles)
        {
            inHandTile.IsUpdateTargetPositionByInHandTileAnchor = false;
            inHandTile.IsUpdateTargetPositionByDraggingTileAnchor = true;

            inHandTile.AddDraggingTileAnchorPosition(inHandTile.Position);
        }
    }
}