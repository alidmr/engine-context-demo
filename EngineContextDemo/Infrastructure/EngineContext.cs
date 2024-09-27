using System.Runtime.CompilerServices;

namespace EngineContextDemo.Infrastructure;

public static class EngineContext
{
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static IEngine Create()
    {
        //create NopEngine as engine
        return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new MyEngine());
    }

    public static void Replace(IEngine engine)
    {
        Singleton<IEngine>.Instance = engine;
    }

    public static IEngine Current
    {
        get
        {
            if (Singleton<IEngine>.Instance == null)
            {
                Create();
            }

            return Singleton<IEngine>.Instance;
        }
    }
}
