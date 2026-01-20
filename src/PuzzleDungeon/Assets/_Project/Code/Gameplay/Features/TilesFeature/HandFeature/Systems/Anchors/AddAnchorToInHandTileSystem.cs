using System.Collections.Generic;
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
                GameMatcher.InHandTileAnchorPosition,
                GameMatcher.InHandTileAnchorDeltas));
    }

    public void Execute()
    {
        foreach (GameEntity tile in _tiles)
        {
            tile.AddInHandTileAnchorPosition(Vector3.zero);
            tile.AddInHandTileAnchorDeltas(new List<AnchorDeltaPosition>(4));
        }
    }
}