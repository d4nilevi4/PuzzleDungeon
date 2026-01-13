using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Transform;

public class TransformFeature : CustomFeature
{
    public TransformFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<MovementFeature>());
    }
}