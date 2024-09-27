namespace EngineContextDemo.Infrastructure;

public interface IEngine
{
    void ConfigureServices(IServiceCollection services, IConfiguration configuration);

    void ConfigureRequestPipeline(WebApplication application);

    T Resolve<T>(IServiceScope scope = null) where T : class;

    object Resolve(Type type, IServiceScope scope = null);

    IEnumerable<T> ResolveAll<T>();

    object ResolveUnregistered(Type type);
}
