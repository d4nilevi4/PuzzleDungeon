using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Transformation;

public sealed class MovementFeature : CustomFeature
{
    public MovementFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<UpdatePositionSystem>());
        
        Add(systemFactory.Create<UpdateViewPositionSystem>());
    }
}