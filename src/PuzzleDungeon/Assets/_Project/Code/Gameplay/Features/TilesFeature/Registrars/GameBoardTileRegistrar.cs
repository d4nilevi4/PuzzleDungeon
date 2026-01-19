using Leontitas;
using PuzzleDungeon.Core;
using UnityEngine;

namespace PuzzleDungeon.Gameplay.Tiles
{
    public class GameBoardTileRegistrar : GameEntityComponentRegistrar
    {
        public Collider InteractionCollider;
        
        public override void RegisterComponents(GameEntity entity)
        {
            entity
                .SetNeedIdFlag(true)
                .SetMovableFlag(true)
                .SetRotatableFlag(true)
                .SetRotateTowardsCameraFlag(true)
                .SetGameBoardTileFlag(true)
                .SetGameBoardTileInHandFlag(true)
                .AddGameBoardTileType(GameBoardTileType.None)
                .SetInteractableFlag(true)
                .AddInteractionCollider(InteractionCollider);
        }
    }
}