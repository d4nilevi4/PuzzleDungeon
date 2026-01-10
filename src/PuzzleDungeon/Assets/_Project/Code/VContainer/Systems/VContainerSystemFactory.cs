using Leontitas;
using PuzzleDungeon.Core.Systems;
using PuzzleDungeon.VContainer.Utilities;
using VContainer;

namespace PuzzleDungeon.VContainer.Systems;

public class VContainerSystemFactory : ISystemFactory
{
    private readonly IObjectResolver _objectResolver;

    public VContainerSystemFactory(
        IObjectResolver objectResolver
    )
    {
        _objectResolver = objectResolver;
    }
    
    public ISystem Create<TSystem>() where TSystem : ISystem
    {
        return _objectResolver.CreateInstance<TSystem>();
    }
}