using Leontitas;

namespace PuzzleDungeon.Core.Systems;

public interface ISystemFactory
{
    ISystem Create<TSystem>() where TSystem : ISystem;
}