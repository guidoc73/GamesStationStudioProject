using System;
using System.Collections.Generic;

public static class DependencyManager
{
    private static readonly Dictionary<Type, object> Objects = new Dictionary<Type, object>();

    public static T GetOrInstantiate<T>(Func<T> factoryMethod)
    {
        if (!Objects.ContainsKey(typeof(T)))
            Objects.Add(typeof(T), factoryMethod());
        return (T)Objects[typeof(T)];
    }

    public static T Get<T>()
    {
        return (T)Objects[typeof(T)];
    }

    public static void Set<T>(T value)
    {
        Objects[typeof(T)] = value;
    }

    public static void ClearAll()
    {
        Objects.Clear();
    }

    public static void Clear<T>()
    {
        Objects.Remove(typeof(T));
    }
}
