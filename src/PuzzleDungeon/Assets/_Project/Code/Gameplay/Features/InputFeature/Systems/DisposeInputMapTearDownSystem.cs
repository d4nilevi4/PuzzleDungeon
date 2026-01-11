using Leontitas;

namespace PuzzleDungeon.Gameplay.Input;

public sealed class DisposeInputMapTearDownSystem : ITearDownSystem
{
    private readonly InputGroup _playerInputs;

    public DisposeInputMapTearDownSystem(InputWorld input)
    {
        _playerInputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.PlayerInputComponent));
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