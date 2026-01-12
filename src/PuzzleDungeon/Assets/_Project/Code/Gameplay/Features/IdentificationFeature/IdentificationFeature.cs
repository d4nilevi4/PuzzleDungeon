using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Identification;

public sealed class IdentificationFeature : CustomFeature
{
    public IdentificationFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<InitializeIdentificationSystem>());
        
        Add(systemFactory.Create<AssignEntityIdSystem>());
    }
}