using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class CalculateFinalInHandTileAnchorSystem : IExecuteSystem
{
    private readonly GameGroup _tiles;

    public CalculateFinalInHandTileAnchorSystem()
    {
        _tiles = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.InHandTileAnchorDeltas,
                GameMatcher.InHandTileAnchorPosition));
    }

    public void Execute()
    {
        foreach (GameEntity tile in _tiles)
        {
            Vector3 finalAnchor = Vector3.zero;
            
            foreach (AnchorDeltaPosition delta in tile.InHandTileAnchorDeltas)
            {
                finalAnchor += delta.DeltaPosition;
            }
            
            tile.ChangeInHandTileAnchorPosition(finalAnchor);
        }
    }
}