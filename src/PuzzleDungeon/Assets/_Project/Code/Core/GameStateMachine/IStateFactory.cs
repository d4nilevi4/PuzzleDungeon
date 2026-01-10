namespace PuzzleDungeon.Core.GameStateMachine;

public interface IStateFactory
{
    T GetState<T>() where T : class, IExitableState;
}