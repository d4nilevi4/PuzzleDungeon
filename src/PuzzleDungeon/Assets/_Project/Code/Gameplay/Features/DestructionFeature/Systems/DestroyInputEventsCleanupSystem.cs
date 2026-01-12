using Leontitas;

namespace PuzzleDungeon.Gameplay.Destruction;

public sealed class DestroyInputEventsCleanupSystem : ICleanupSystem
{
    private readonly InputGroup _inputEvents;

    public DestroyInputEventsCleanupSystem(InputWorld input)
    {
        _inputEvents = input.GetGroup(InputMatcher.AllOf(InputMatcher.Event));
    }
    
    public void Cleanup()
    {
        foreach (InputEntity inputEvent in _inputEvents)
        {
            inputEvent.Destroy();
        }
    }
}