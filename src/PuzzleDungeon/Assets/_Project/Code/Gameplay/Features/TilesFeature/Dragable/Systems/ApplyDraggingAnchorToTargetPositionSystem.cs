using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class ApplyDraggingAnchorToTargetPositionSystem : IExecuteSystem
{
    private readonly GameGroup _tiles;

    public ApplyDraggingAnchorToTargetPositionSystem()
    {
        _tiles = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.Dragging,
                GameMatcher.UpdateTargetPositionByDraggingTileAnchor,
                GameMatcher.DraggingTileAnchorPosition));
    }

    public void Execute()
    {
        foreach (GameEntity tile in _tiles)
        {
            tile.ReplaceTargetPosition(tile.DraggingTileAnchorPosition);
        }
    }
}