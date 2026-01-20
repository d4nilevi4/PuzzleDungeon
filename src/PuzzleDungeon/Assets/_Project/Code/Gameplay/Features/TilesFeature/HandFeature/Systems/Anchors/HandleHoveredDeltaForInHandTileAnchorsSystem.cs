using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class HandleHoveredDeltaForInHandTileAnchorsSystem : IExecuteSystem
{
    private readonly GameGroup _tiles;
    private readonly GameGroup _mainCameras;

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
        
        _mainCameras = GameWorld.GetGroup(GameMatcher.AllOf(GameMatcher.MainCamera));
    }
    
    public void Execute()
    {
        foreach (GameEntity tile in _tiles)
        foreach (GameEntity mainCamera in _mainCameras)
        {
            
            tile.InHandTileAnchorDeltas.Add(new AnchorDeltaPosition(
                deltaPosition: tile.InHandTileHoverDelta * mainCamera.MainCamera.transform.up
                #if DEBUG
                , debugName: nameof(HandleHoveredDeltaForInHandTileAnchorsSystem)
                #endif
                 ));
        }
    }
}