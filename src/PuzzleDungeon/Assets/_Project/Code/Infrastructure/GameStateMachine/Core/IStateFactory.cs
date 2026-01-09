namespace PuzzleDungeon.Infrastructure;

public interface IStateFactory
{
    T GetState<T>() where T : class, IExitableState;
}