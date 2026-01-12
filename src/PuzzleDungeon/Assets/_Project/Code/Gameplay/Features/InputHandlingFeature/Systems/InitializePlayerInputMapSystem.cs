using Leontitas;

namespace PuzzleDungeon.Gameplay.InputHandling;

public sealed class InitializePlayerInputMapSystem : IInitializeSystem
{
    public void Initialize()
    {
        InputEntity inputMap = InputEntity.Create();
        PlayerInput playerInput = new PlayerInput();
        
        playerInput.Enable();
        
        inputMap.AddPlayerInput(playerInput);
    }
}