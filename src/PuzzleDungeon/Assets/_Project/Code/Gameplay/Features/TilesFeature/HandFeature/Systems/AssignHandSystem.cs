using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class AssignHandSystem : IExecuteSystem
{
    private readonly GameGroup _orphanTile;
    private readonly GameGroup _hands;

    public AssignHandSystem()
    {
        _orphanTile = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.GameBoardTileInHand,
                GameMatcher.OrphanTile)
            .NoneOf(
                GameMatcher.LinkedHand,
                GameMatcher.GameBoardTileInHandOrderIndex));

        _hands = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Hand,
                GameMatcher.GameBoardTilesInHandCount));
    }
    
    public void Execute()
    {
        foreach (GameEntity hand in _hands)
        foreach (GameEntity orphanTile in _orphanTile)
        {
            orphanTile.AddLinkedHand(hand.Id);
            orphanTile.AddGameBoardTileInHandOrderIndex(hand.GameBoardTilesInHandCount);
            orphanTile.IsOrphanTile = false;
            
            hand.GameBoardTilesInHandCountRef.Value++;
        }
    }
}