using Leontitas;

namespace PuzzleDungeon.Gameplay.Input;

public sealed class UpdateMousePositionSystem : IPreExecuteSystem
{
    private readonly InputGroup _mousePositions;
    private readonly InputGroup _playerInputs;

    public UpdateMousePositionSystem(InputWorld input)
    {
        _mousePositions = input.GetGroup(InputMatcher.AllOf(InputMatcher.MousePosition));
        _playerInputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.PlayerInputComponent));
    }
    
    public void PreExecute()
    {
        foreach (InputEntity playerInput in _playerInputs)
        foreach (InputEntity mousePosition in _mousePositions)
        {
            mousePosition.ChangeMousePosition(playerInput.PlayerInput.Gameplay.MousePosition.ReadValue<Vector2>());
        }
    }
}