using Leontitas;

namespace PuzzleDungeon.Gameplay.Identification;

public sealed class InitializeIdentificationSystem : IInitializeSystem
{
    public void Initialize()
    {
        GameEntity.Create().AddNextId(0);
    }
}