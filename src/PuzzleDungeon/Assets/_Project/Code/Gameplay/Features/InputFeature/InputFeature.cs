using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Input;

public sealed class InputFeature : CustomFeature
{
    public InputFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<InitializePlayerInputMapSystem>());
        
        Add(systemFactory.Create<InitializeMousePositionSystem>());

        Add(systemFactory.Create<UpdateMousePositionSystem>());
        Add(systemFactory.Create<UpdateMousePositionDeltaSystem>());
        
        Add(systemFactory.Create<DisposeInputMapTearDownSystem>());
    }
}