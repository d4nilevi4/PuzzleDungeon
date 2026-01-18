using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class AddAnchorToInHandTileSystem : IExecuteSystem
{
    private readonly GameGroup _tiles;

    public AddAnchorToInHandTileSystem()
    {
        _tiles = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.GameBoardTile,
                GameMatcher.GameBoardTileInHand)
            .NoneOf(
                GameMatcher.InHandTileAnchor));
    }

    public void Execute()
    {
        foreach (GameEntity tile in _tiles)
        {
            tile.AddInHandTileAnchor(Vector3.zero);
        }
    }
}