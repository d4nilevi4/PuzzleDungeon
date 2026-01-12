using Leontitas;

namespace PuzzleDungeon.Gameplay.InputHandling;

public sealed class UpdateMousePositionDeltaSystem : IPreExecuteSystem
{
    private readonly InputGroup _mousePositions;
    private readonly InputGroup _gameInputActions;

    public UpdateMousePositionDeltaSystem(InputWorld input)
    {
        _mousePositions = input.GetGroup(InputMatcher.AllOf(InputMatcher.MousePositionDelta));
        _gameInputActions = input.GetGroup(InputMatcher.AllOf(InputMatcher.GameplayInputActions));
    }
    
    public void PreExecute()
    {
        foreach (InputEntity playerInput in _gameInputActions)
        foreach (InputEntity mousePosition in _mousePositions)
        {
            mousePosition.ChangeMousePositionDelta(playerInput.GameplayInputActions.MouseDelta.ReadValue<Vector2>());
        }
    }
}