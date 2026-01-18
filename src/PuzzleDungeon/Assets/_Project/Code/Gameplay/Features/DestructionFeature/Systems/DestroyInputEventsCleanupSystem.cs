using Leontitas;

namespace PuzzleDungeon.Gameplay.Destruction;

public sealed class DestroyInputEventsCleanupSystem : ICleanupSystem
{
    private readonly InputGroup _inputEvents;

    public DestroyInputEventsCleanupSystem()
    {
        _inputEvents = InputWorld.GetGroup(InputMatcher.AllOf(InputMatcher.Event));
    }
    
    public void Cleanup()
    {
        foreach (InputEntity inputEvent in _inputEvents)
        {
            inputEvent.Destroy();
        }
    }
}