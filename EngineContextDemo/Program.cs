using EngineContextDemo.Infrastructure.Extensions;

namespace EngineContextDemo;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Uygulama servislerini yapýlandýr
        builder.Services.ConfigureApplicationServices(builder);

        var app = builder.Build();

        // Ýstek pipeline'ýný yapýlandýr
        app.ConfigureRequestPipeline();

        await app.RunAsync();
    }
}