﻿namespace EngineContextDemo.Infrastructure;

public partial class Singleton<T> : BaseSingleton
{
    private static T _instance;

    public static T Instance
    {
        get => _instance;
        set
        {
            _instance = value;
            AllSingletons[typeof(T)] = value;
        }
    }
}
