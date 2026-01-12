using Leontitas;
using PuzzleDungeon.Core.Systems;
using PuzzleDungeon.Gameplay.Destruction;
using PuzzleDungeon.Gameplay.InputHandling;

namespace PuzzleDungeon.Gameplay;

public sealed class BattleFeature : CustomFeature
{
    public BattleFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<InputFeature>());
        
        Add(systemFactory.Create<DestructionFeature>());
    }
}