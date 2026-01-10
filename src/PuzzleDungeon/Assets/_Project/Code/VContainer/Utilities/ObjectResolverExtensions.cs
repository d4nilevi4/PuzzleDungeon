using System;
using System.Diagnostics.Contracts;
using VContainer;

namespace PuzzleDungeon.VContainer.Utilities;

public static class ObjectResolverExtensions
{
    [Pure]
    public static T CreateInstance<T>(this IObjectResolver resolver)
    {
        return (T)CreateInstance(resolver, typeof(T));
    }
    
    [Pure]
    public static object CreateInstance(this IObjectResolver resolver, Type type)
    {
        var constructors = type.GetConstructors();
        
        if (constructors.Length == 0)
            throw new InvalidOperationException($"Type {type} has no public constructors");

        var constructor = constructors[0];
    
        var parameters = constructor.GetParameters();
        var args = new object[parameters.Length];
        
        for (int i = 0; i < parameters.Length; i++)
        {
            args[i] = resolver.Resolve(parameters[i].ParameterType);
        }
    
        return constructor.Invoke(args);
    }
}