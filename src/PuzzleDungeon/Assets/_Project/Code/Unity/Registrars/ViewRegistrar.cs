using Leontitas;
using PuzzleDungeon.Core;
using PuzzleDungeon.Unity.View;

namespace PuzzleDungeon.Gameplay
{
    public sealed class ViewRegistrar : GameEntityComponentRegistrar
    {
        public UnityEntityView View;
    
        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddEntityView(View);
        }
    }
}