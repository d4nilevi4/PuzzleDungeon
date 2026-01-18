using Leontitas;

namespace PuzzleDungeon.Gameplay.InputHandling;

public sealed class DisposeInputMapTearDownSystem : ITearDownSystem
{
    private readonly InputGroup _playerInputs;

    public DisposeInputMapTearDownSystem()
    {
        _playerInputs = InputWorld.GetGroup(InputMatcher.AllOf(InputMatcher.PlayerInput));
    }
    
    public void TearDown()
    {
        foreach (InputEntity playerInput in _playerInputs)
        {
            playerInput.PlayerInput.Disable();
            playerInput.PlayerInput.Dispose();
        }
    }
}