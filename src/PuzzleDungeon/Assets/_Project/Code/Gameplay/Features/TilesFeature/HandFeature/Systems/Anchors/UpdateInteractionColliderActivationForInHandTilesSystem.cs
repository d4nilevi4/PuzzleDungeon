using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class UpdateInteractionColliderActivationForInHandTilesSystem : IExecuteSystem
{
    private readonly GameGroup _tiles;
    private readonly GameGroup _hands;

    public UpdateInteractionColliderActivationForInHandTilesSystem()
    {
        _tiles = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.GameBoardTileInHand,
                GameMatcher.InteractionCollider,
                GameMatcher.GameBoardTileInHandOrderIndex,
                GameMatcher.LinkedHand));

        _hands = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Id,
                GameMatcher.Hand,
                GameMatcher.GameBoardTilesInHandCount));
    }

    public void Execute()
    {
        foreach (GameEntity hand in _hands)
        foreach (GameEntity tile in _tiles)
        {
            if(tile.LinkedHand != hand.Id)
                continue;
            
            bool shouldBeActive = 
                tile.GameBoardTileInHandOrderIndex == hand.GameBoardTilesInHandCount - 1;

            tile.InteractionCollider.enabled = shouldBeActive;
        }
    }
}