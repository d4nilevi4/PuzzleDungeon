using Leontitas;

namespace PuzzleDungeon.Gameplay.Destruction;

public sealed class DestroyGameEventsCleanupSystem : ICleanupSystem
{
    private readonly GameGroup _gameEvents;

    public DestroyGameEventsCleanupSystem()
    {
        _gameEvents = GameWorld.GetGroup(GameMatcher.AllOf(GameMatcher.Event));
    }
    
    public void Cleanup()
    {
        foreach (GameEntity gameEvent in _gameEvents)
        {
            gameEvent.Destroy();
        }
    }
}