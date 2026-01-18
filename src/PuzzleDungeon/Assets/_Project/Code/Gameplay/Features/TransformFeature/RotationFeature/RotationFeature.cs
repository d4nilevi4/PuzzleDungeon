using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Transformation;

public sealed class RotationFeature : CustomFeature
{
    public RotationFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<RotateTowardsMainCameraSystem>());
        
        Add(systemFactory.Create<UpdateViewRotationSystem>());
    }
}