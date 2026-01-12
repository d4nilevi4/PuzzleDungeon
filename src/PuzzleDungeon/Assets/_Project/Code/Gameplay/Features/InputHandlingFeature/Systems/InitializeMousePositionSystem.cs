using Leontitas;

namespace PuzzleDungeon.Gameplay.InputHandling;

public sealed class InitializeMousePositionSystem : IInitializeSystem
{
    private readonly InputGroup _playerInputs;

    public InitializeMousePositionSystem(InputWorld input)
    {
        _playerInputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.PlayerInputComponent));
    }
    
    public void Initialize()
    {
        InputEntity mousePositionEntity = InputEntity.Create();

        foreach (InputEntity playerInput in _playerInputs)
        {
            mousePositionEntity.AddMousePosition(playerInput.PlayerInput.Gameplay.MousePosition.ReadValue<Vector2>());
            mousePositionEntity.AddMousePositionDelta(playerInput.PlayerInput.Gameplay.MouseDelta.ReadValue<Vector2>());
        }
    }
}