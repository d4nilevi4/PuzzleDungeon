using Leontitas;

namespace PuzzleDungeon.Gameplay.InputHandling;

public sealed class UpdateMousePositionSystem : IPreExecuteSystem
{
    private readonly InputGroup _mousePositions;
    private readonly InputGroup _gameInputActions;

    public UpdateMousePositionSystem(InputWorld input)
    {
        _mousePositions = input.GetGroup(InputMatcher.AllOf(InputMatcher.MousePosition));
        _gameInputActions = input.GetGroup(InputMatcher.AllOf(InputMatcher.GameplayInputActions));
    }
    
    public void PreExecute()
    {
        foreach (InputEntity playerInput in _gameInputActions)
        foreach (InputEntity mousePosition in _mousePositions)
        {
            mousePosition.ChangeMousePosition(playerInput.GameplayInputActions.MousePosition.ReadValue<Vector2>());
        }
    }
}