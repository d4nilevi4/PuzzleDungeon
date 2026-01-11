using Leontitas;

namespace PuzzleDungeon.Gameplay.Input;

public sealed class UpdateMousePositionDeltaSystem : IPreExecuteSystem
{
    private readonly InputGroup _mousePositions;
    private readonly InputGroup _playerInputs;

    public UpdateMousePositionDeltaSystem(InputWorld input)
    {
        _mousePositions = input.GetGroup(InputMatcher.AllOf(InputMatcher.MousePositionDelta));
        _playerInputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.PlayerInputComponent));
    }
    
    public void PreExecute()
    {
        foreach (InputEntity playerInput in _playerInputs)
        foreach (InputEntity mousePosition in _mousePositions)
        {
            mousePosition.ChangeMousePositionDelta(playerInput.PlayerInput.Gameplay.MouseDelta.ReadValue<Vector2>());
        }
    }
}