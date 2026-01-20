namespace PuzzleDungeon.Gameplay.Tiles;

public readonly struct AnchorDeltaPosition
{
    public Vector3 DeltaPosition { get; }
#if DEBUG
    public string DebugName { get; }
#endif
    public AnchorDeltaPosition(
        Vector3 deltaPosition
#if DEBUG
        , string debugName
#endif
    )
    {
        DeltaPosition = deltaPosition;
#if DEBUG
        DebugName = debugName;
#endif
    }
}