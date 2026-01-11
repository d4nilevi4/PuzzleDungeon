namespace PuzzleDungeon.Core.View;

public interface IEntityViewPool<TView> where TView : IEntityView
{
    TView Get();
    void Release(TView view);
}