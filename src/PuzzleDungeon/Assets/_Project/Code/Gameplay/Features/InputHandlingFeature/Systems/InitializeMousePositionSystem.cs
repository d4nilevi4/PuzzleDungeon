using Leontitas;

namespace PuzzleDungeon.Gameplay.InputHandling;

public sealed class InitializeMousePositionSystem : IInitializeSystem
{
    private readonly InputGroup _gameInputActions;

    public InitializeMousePositionSystem(InputWorld input)
    {
        _gameInputActions = input.GetGroup(InputMatcher.AllOf(InputMatcher.GameplayInputActions));
    }
    
    public void Initialize()
    {
        InputEntity mousePositionEntity = InputEntity.Create();

        foreach (InputEntity playerInput in _gameInputActions)
        {
            mousePositionEntity.AddMousePosition(playerInput.GameplayInputActions.MousePosition.ReadValue<Vector2>());
            mousePositionEntity.AddMousePositionDelta(playerInput.GameplayInputActions.MouseDelta.ReadValue<Vector2>());
        }
    }
}