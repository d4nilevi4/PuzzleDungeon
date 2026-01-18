using Leontitas;

namespace PuzzleDungeon.Gameplay.Transformation;

public sealed class UpdateViewRotationSystem : IExecuteSystem
{
    private readonly GameGroup _entity;

    public UpdateViewRotationSystem()
    {
        _entity = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Rotation,
                GameMatcher.EntityView));
    }
    
    public void Execute()
    {
        foreach (GameEntity entity in _entity)
        {
            entity.EntityView.Rotation = entity.Rotation;
        }
    }
}