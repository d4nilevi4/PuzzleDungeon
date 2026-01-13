using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class UpdateInHandTileAnchorsSystem : IExecuteSystem
{
    private const float TILE_SPACING = 1.5f;

    private readonly GameGroup _tiles;
    private readonly GameGroup _hands;

    public UpdateInHandTileAnchorsSystem(GameWorld world)
    {
        _tiles = world.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.GameBoardTileInHand,
                GameMatcher.GameBoardTileInHandOrderIndex,
                GameMatcher.LinkedHand,
                GameMatcher.InHandTileAnchor));

        _hands = world.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Id,
                GameMatcher.Hand,
                GameMatcher.HandPosition,
                GameMatcher.GameBoardTilesInHandCount));
    }

    public void Execute()
    {
        foreach (GameEntity hand in _hands)
        {
            int tilesCount = hand.GameBoardTilesInHandCount;
            Vector3 handCenter = hand.HandPosition;
            float totalWidth = (tilesCount - 1) * TILE_SPACING;
            float startOffset = -totalWidth / 2f;

            foreach (GameEntity tile in _tiles)
            {
                if (tile.LinkedHand != hand.Id)
                    continue;

                int orderIndex = tile.GameBoardTileInHandOrderIndex;
                float xOffset = startOffset + orderIndex * TILE_SPACING;
                Vector3 targetPosition = handCenter + new Vector3(xOffset, 0, 0);

                tile.InHandTileAnchorRef.Value = targetPosition;
            }
        }
    }
}