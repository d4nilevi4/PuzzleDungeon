using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class HandleHoveredDeltaForInHandTileAnchorsSystem : IExecuteSystem
{
    private readonly GameGroup _tiles;

    public HandleHoveredDeltaForInHandTileAnchorsSystem()
    {
        _tiles = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.GameBoardTileInHand,
                GameMatcher.LinkedHand,
                GameMatcher.Hovered,
                GameMatcher.InHandTileAnchorDeltas,
                GameMatcher.InHandTileHoverDelta));
    }
    
    public void Execute()
    {
        foreach (GameEntity tile in _tiles)
        {
            
            tile.InHandTileAnchorDeltas.Add(new AnchorDeltaPosition(
                deltaPosition: tile.InHandTileHoverDelta * Vector3.up
                #if DEBUG
                , debugName: nameof(HandleHoveredDeltaForInHandTileAnchorsSystem)
                #endif
                 ));
        }
    }
}