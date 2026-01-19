using Leontitas;
using PuzzleDungeon.Core.Systems;
using PuzzleDungeon.Gameplay.Destruction;
using PuzzleDungeon.Gameplay.Identification;
using PuzzleDungeon.Gameplay.InputHandling;
using PuzzleDungeon.Gameplay.Interactions;
using PuzzleDungeon.Gameplay.Tiles;
using PuzzleDungeon.Gameplay.Transformation;

namespace PuzzleDungeon.Gameplay;

public sealed class BattleFeature : CustomFeature
{
    public BattleFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<InputFeature>());
        
        Add(systemFactory.Create<IdentificationFeature>());
        
        Add(systemFactory.Create<InteractionsFeature>());
        
        Add(systemFactory.Create<TilesFeature>());
        
        Add(systemFactory.Create<TransformFeature>());
        
        Add(systemFactory.Create<DestructionFeature>());
    }
}