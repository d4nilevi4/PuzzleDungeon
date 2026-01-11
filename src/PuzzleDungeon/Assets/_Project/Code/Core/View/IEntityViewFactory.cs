namespace PuzzleDungeon.Core.View;

public interface IEntityViewFactory
{
    TView Create<TView>(TView viewPrefab) where TView : IEntityView;
}