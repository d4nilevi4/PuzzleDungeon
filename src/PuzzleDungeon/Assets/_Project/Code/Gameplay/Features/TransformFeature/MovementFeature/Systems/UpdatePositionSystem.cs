using Leontitas;

namespace PuzzleDungeon.Gameplay.Transform;

public sealed class UpdatePositionSystem : IExecuteSystem
{
    private readonly GameGroup _movables;

    public UpdatePositionSystem()
    {
        _movables = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Position,
                GameMatcher.TargetPosition,
                GameMatcher.Movable));
    }
    
    public void Execute()
    {
        foreach (GameEntity movable in _movables)
        {
            movable.ChangePosition(movable.TargetPosition);
        }
    }
}