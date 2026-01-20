using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class ApplyInHandTileAnchorToTargetPositionSystem : IExecuteSystem
{
    private readonly GameGroup _tiles;

    public ApplyInHandTileAnchorToTargetPositionSystem()
    {
        _tiles = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.GameBoardTileInHand,
                GameMatcher.InHandTileAnchorPosition));
    }

    public void Execute()
    {
        foreach (GameEntity tile in _tiles)
        {
            tile.ReplaceTargetPosition(tile.InHandTileAnchorPosition);
        }
    }
}