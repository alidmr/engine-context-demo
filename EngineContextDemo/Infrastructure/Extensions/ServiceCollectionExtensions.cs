namespace EngineContextDemo.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddHttpContextAccessor();

        // EngineContext oluşturuluyor ve servisler yapılandırılıyor
        var engine = EngineContext.Create();

        engine.ConfigureServices(services, builder.Configuration);
    }
}
