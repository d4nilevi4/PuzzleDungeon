using System;

namespace PuzzleDungeon.Gameplay;

[Flags]
public enum CollisionLayers
{
    Interactable = 1 << 10,
}

public static class CollisionExtensions
{
    public static int AsMask(this CollisionLayers layers)
    {
        return (int)layers;
    }
}