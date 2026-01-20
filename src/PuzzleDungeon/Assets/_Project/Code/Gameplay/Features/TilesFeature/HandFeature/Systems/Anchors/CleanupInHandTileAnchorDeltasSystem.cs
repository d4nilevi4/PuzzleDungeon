using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class CleanupInHandTileAnchorDeltasSystem : ICleanupSystem
{
    private readonly GameGroup _tiles;

    public CleanupInHandTileAnchorDeltasSystem()
    {
        _tiles = GameWorld.GetGroup(GameMatcher.AllOf(GameMatcher.InHandTileAnchorDeltas));
    }

    public void Cleanup()
    {
        foreach (GameEntity tile in _tiles)
        {
            tile.InHandTileAnchorDeltas.Clear();
        }
    }
}