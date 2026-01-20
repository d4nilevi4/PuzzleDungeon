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
                GameMatcher.HandPosition,
                GameMatcher.GameBoardTilesInHandCount,
                GameMatcher.TileSpacing));
    }

    public void Execute()
    {
        foreach (GameEntity hand in _hands)
        {
            int tilesCount = hand.GameBoardTilesInHandCount;
            Vector3 handCenter = hand.HandPosition;
            float handTileSpacing = hand.TileSpacing;

            float totalWidth = (tilesCount - 1) * handTileSpacing;
            float startOffset = -totalWidth / 2f;

            foreach (GameEntity tile in _tiles)
            {
                if (tile.LinkedHand != hand.Id)
                    continue;

                int orderIndex = tile.GameBoardTileInHandOrderIndex;
                float xOffset = startOffset + orderIndex * handTileSpacing;
                Vector3 targetPosition = handCenter + new Vector3(xOffset, 0, 0);

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