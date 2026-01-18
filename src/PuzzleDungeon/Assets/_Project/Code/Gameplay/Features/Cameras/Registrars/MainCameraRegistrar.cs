using Leontitas;
using PuzzleDungeon.Core;

namespace PuzzleDungeon.Gameplay.Cameras
{
    public sealed class MainCameraRegistrar : GameEntityComponentRegistrar
    {
        public UnityEngine.Camera Camera;
        
        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddMainCamera(Camera);
        }
    }
}