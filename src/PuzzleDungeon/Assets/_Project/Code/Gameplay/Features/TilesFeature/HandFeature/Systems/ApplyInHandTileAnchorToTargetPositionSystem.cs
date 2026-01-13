using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class ApplyInHandTileAnchorToTargetPositionSystem : IExecuteSystem
{
    private readonly GameGroup _tiles;

    public ApplyInHandTileAnchorToTargetPositionSystem(GameWorld world)
    {
        _tiles = world.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.GameBoardTileInHand,
                GameMatcher.InHandTileAnchor));
    }

    public void Execute()
    {
        foreach (GameEntity tile in _tiles)
        {
            tile.ReplaceTargetPosition(tile.InHandTileAnchor);
        }
    }
}