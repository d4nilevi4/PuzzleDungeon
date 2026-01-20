using Leontitas;
using PuzzleDungeon.Core;

namespace PuzzleDungeon.Gameplay.Tiles
{
    public class HandRegistrar : GameEntityComponentRegistrar
    {
        public override void RegisterComponents(GameEntity entity)
        {
            entity
                .SetHandFlag(true)
                .SetNeedIdFlag(true)
                .AddGameBoardTilesInHandCount(0)
                .AddTileThickness(0.1f);
        }
    }
}