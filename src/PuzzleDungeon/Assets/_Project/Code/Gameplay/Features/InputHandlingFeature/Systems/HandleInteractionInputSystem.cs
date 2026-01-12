using Leontitas;

namespace PuzzleDungeon.Gameplay.InputHandling;

public sealed class HandleInteractionInputSystem : IPreExecuteSystem
{
    private readonly InputGroup _gameInputActions;

    public HandleInteractionInputSystem(InputWorld input)
    {
        _gameInputActions = input.GetGroup(InputMatcher.AllOf(InputMatcher.GameplayInputActions));
    }

    public void PreExecute()
    {
        foreach (InputEntity inputAction in _gameInputActions)
        {
            if (inputAction.GameplayInputActions.Interaction.WasPerformedThisFrame())
            {
                InputEntity.Create()
                    .SetInteractionPerformedEventFlag(true)
                    .SetEventFlag(true);
            }

            if (inputAction.GameplayInputActions.Interaction.WasPressedThisFrame())
            {
                InputEntity.Create()
                    .SetInteractionPressedEventFlag(true)
                    .SetEventFlag(true);
            }
        }
    }
}