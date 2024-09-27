using EngineContextDemo.Infrastructure.Extensions;

namespace EngineContextDemo;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Uygulama servislerini yap�land�r
        builder.Services.ConfigureApplicationServices(builder);

        var app = builder.Build();

        // �stek pipeline'�n� yap�land�r
        app.ConfigureRequestPipeline();

        await app.RunAsync();
    }
}