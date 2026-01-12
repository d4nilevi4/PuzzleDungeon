using Leontitas;

namespace PuzzleDungeon.Gameplay.InputHandling;

public sealed class InitializePlayerInputMapSystem : IInitializeSystem
{
    public void Initialize()
    {
        PlayerInput playerInput = new PlayerInput();
        playerInput.Enable();
        
        InputEntity.Create()
            .AddPlayerInput(playerInput)
            .AddGameplayInputActions(playerInput.Gameplay);
    }
}