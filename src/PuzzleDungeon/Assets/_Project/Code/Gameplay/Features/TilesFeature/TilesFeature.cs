using Leontitas;
using PuzzleDungeon.Core.Systems;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class TilesFeature : CustomFeature
{
    public TilesFeature(ISystemFactory systemFactory)
    {
        Add(systemFactory.Create<DraggableFeature>());
        
        Add(systemFactory.Create<HandFeature>());
    }
}