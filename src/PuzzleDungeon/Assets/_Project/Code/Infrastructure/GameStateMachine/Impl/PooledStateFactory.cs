using System;
using System.Collections.Generic;
using PuzzleDungeon.Infrastructure;
using VContainer;

public class PooledStateFactory : IStateFactory
{
    private readonly IObjectResolver _resolver;
    
    private readonly Dictionary<Type, IExitableState> _statesCache = new();

    public PooledStateFactory(IObjectResolver resolver)
    {
        _resolver = resolver;
    }
    
    public T GetState<T>() where T : class, IExitableState
    {
        if (_statesCache.TryGetValue(typeof(T), out IExitableState cachedState))
        {
            return (T)cachedState;
        }
        
        T state = _resolver.CreateInstance<T>();
        _statesCache[typeof(T)] = state;
        return state;
    }
}