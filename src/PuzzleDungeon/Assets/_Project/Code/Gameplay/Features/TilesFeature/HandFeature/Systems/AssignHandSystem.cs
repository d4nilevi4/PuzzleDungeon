using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class AssignHandSystem : IExecuteSystem
{
    private readonly GameGroup _orphanTile;
    private readonly GameGroup _hands;

    public AssignHandSystem(GameWorld game)
    {
        _orphanTile = game.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.GameBoardTileInHand)
            .NoneOf(
                GameMatcher.LinkedHand,
                GameMatcher.GameBoardTileInHandOrderIndex));

        _hands = game.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Hand,
                GameMatcher.HandPosition,
                GameMatcher.GameBoardTilesInHandCount));
    }
    
    public void Execute()
    {
        foreach (GameEntity hand in _hands)
        foreach (GameEntity orphanTile in _orphanTile)
        {
            orphanTile.AddLinkedHand(hand.Id);
            orphanTile.AddGameBoardTileInHandOrderIndex(hand.GameBoardTilesInHandCount);
            
            hand.GameBoardTilesInHandCountRef.Value++;
        }
    }
}