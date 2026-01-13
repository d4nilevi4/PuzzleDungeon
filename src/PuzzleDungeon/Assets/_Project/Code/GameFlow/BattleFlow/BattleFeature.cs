using Leontitas;
using PuzzleDungeon.Core.Systems;
using PuzzleDungeon.Gameplay.Destruction;
using PuzzleDungeon.Gameplay.InputHandling;
using PuzzleDungeon.Gameplay.Transform;

namespace PuzzleDungeon.Gameplay;

public sealed class BattleFeature : CustomFeature
{
    public BattleFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<InputFeature>());
        
        Add(systemFactory.Create<TransformFeature>());
        
        Add(systemFactory.Create<DestructionFeature>());
    }
}