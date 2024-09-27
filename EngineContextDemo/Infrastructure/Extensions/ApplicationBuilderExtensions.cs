namespace EngineContextDemo.Infrastructure.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ConfigureRequestPipeline(this WebApplication application)
    {
        EngineContext.Current.ConfigureRequestPipeline(application);
    }
}
