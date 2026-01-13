using Leontitas;

namespace PuzzleDungeon.Gameplay.Transform;

public sealed class UpdateViewPositionSystem : IExecuteSystem
{
    private readonly GameGroup _entity;

    public UpdateViewPositionSystem(GameWorld game)
    {
        _entity = game.GetGroup(GameMatcher
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