using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Transformation;

public class TransformFeature : CustomFeature
{
    public TransformFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<MovementFeature>());
        
        Add(systemFactory.Create<RotationFeature>());
    }
}