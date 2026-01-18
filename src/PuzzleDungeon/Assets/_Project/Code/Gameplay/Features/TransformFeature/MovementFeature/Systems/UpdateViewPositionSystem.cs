using Leontitas;

namespace PuzzleDungeon.Gameplay.Transformation;

public sealed class UpdateViewPositionSystem : IExecuteSystem
{
    private readonly GameGroup _entity;

    public UpdateViewPositionSystem()
    {
        _entity = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Position,
                GameMatcher.EntityView));
    }
    
    public void Execute()
    {
        foreach (GameEntity entity in _entity)
        {
            entity.EntityView.Position = entity.Position;
        }
    }
}