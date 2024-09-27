namespace EngineContextDemo.Infrastructure;

public partial class BaseSingleton
{
    static BaseSingleton()
    {
        AllSingletons = new Dictionary<Type, object>();
    }

    public static IDictionary<Type, object> AllSingletons { get; }
}
