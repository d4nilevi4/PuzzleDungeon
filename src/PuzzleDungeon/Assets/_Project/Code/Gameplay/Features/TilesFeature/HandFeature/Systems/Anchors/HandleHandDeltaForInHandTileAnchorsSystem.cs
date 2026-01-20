using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class HandleHandDeltaForInHandTileAnchorsSystem : IExecuteSystem
{
    private readonly GameGroup _tiles;
    private readonly GameGroup _hands;

    public HandleHandDeltaForInHandTileAnchorsSystem()
    {
        _tiles = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.GameBoardTileInHand,
                GameMatcher.GameBoardTileInHandOrderIndex,
                GameMatcher.LinkedHand,
                GameMatcher.InHandTileAnchorDeltas));

        _hands = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Id,
                GameMatcher.Hand,
                GameMatcher.Position,
                GameMatcher.GameBoardTilesInHandCount,
                GameMatcher.TileThickness));
    }

    public void Execute()
    {
        foreach (GameEntity hand in _hands)
        {
            Vector3 handCenter = hand.Position;
            float handTileThickness = hand.TileThickness;
            float startYOffset = handTileThickness / 2 + handCenter.y;

            foreach (GameEntity tile in _tiles)
            {
                if (tile.LinkedHand != hand.Id)
                    continue;

                int orderIndex = tile.GameBoardTileInHandOrderIndex;
                float yOffset = startYOffset + orderIndex * handTileThickness;
                Vector3 targetPosition = handCenter + new Vector3(0, yOffset, 0);

                tile.InHandTileAnchorDeltas.Add(
                    new AnchorDeltaPosition(targetPosition
#if DEBUG
                        , nameof(HandleHandDeltaForInHandTileAnchorsSystem)
#endif
                    ));
            }
        }
    }
}