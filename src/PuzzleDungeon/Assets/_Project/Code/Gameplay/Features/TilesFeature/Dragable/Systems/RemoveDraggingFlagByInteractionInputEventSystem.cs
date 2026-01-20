using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class RemoveDraggingFlagByInteractionInputEventSystem : IExecuteSystem
{
    private readonly GameGroup _draggables;
    private readonly InputGroup _interactionCompletedEvents;

    public RemoveDraggingFlagByInteractionInputEventSystem()
    {
        _interactionCompletedEvents = InputWorld.GetGroup(InputMatcher
            .AllOf(
                InputMatcher.InteractionCompletedEvent));
        
        _draggables = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Dragging,
                GameMatcher.Interactable));
    }

    public void Execute()
    {
        foreach (InputEntity _ in _interactionCompletedEvents)
        foreach (GameEntity draggable in _draggables)
        {
            draggable.IsDragging = false;
        }
    }
}