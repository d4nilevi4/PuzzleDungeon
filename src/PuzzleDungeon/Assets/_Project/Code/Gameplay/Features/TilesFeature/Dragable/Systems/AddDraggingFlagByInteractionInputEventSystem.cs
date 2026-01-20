using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class AddDraggingFlagByInteractionInputEventSystem : IExecuteSystem
{
    private readonly GameGroup _draggables;
    private readonly InputGroup _interactionPerformedEvents;

    public AddDraggingFlagByInteractionInputEventSystem()
    {
        _interactionPerformedEvents = InputWorld.GetGroup(InputMatcher
            .AllOf(
                InputMatcher.InteractionPerformedEvent));

        _draggables = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Draggable,
                GameMatcher.Interactable,
                GameMatcher.Hovered
            ));
    }

    public void Execute()
    {
        foreach (InputEntity _ in _interactionPerformedEvents)
        foreach (GameEntity draggable in _draggables)
        {
            draggable.IsDragging = true;
        }
    }
}