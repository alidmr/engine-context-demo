﻿using EngineContextDemo.Services;

namespace EngineContextDemo.Infrastructure;

public class MyEngine : IEngine
{
    public virtual IServiceProvider ServiceProvider { get; protected set; }

    protected virtual IServiceProvider GetServiceProvider(IServiceScope scope = null)
    {
        if (scope != null)
            return scope.ServiceProvider;

        var accessor = ServiceProvider?.GetService<IHttpContextAccessor>();
        var context = accessor?.HttpContext;
        return context?.RequestServices ?? ServiceProvider;
    }

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IEngine>(this);

        // todo: other application services
        //...

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ILocalizationService, LocalizationService>();
    }

    public void ConfigureRequestPipeline(WebApplication application)
    {
        ServiceProvider = application.Services;

        // todo: other application middleware
        //...

        if (application.Environment.IsDevelopment())
        {
            application.UseSwagger();
            application.UseSwaggerUI();
        }

        application.UseAuthorization();

        application.MapControllers();
    }

    public T Resolve<T>(IServiceScope scope = null) where T : class
    {
        return (T)Resolve(typeof(T), scope);
    }

    public object Resolve(Type type, IServiceScope scope = null)
    {
        return GetServiceProvider(scope)?.GetService(type);
    }

    public IEnumerable<T> ResolveAll<T>()
    {
        return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
    }

    public object ResolveUnregistered(Type type)
    {
        Exception innerException = null;
        foreach (var constructor in type.GetConstructors())
            try
            {
                //try to resolve constructor parameters
                var parameters = constructor.GetParameters().Select(parameter =>
                {
                    var service = Resolve(parameter.ParameterType) ?? throw new Exception("Unknown dependency");
                    return service;
                });

                //all is ok, so create instance
                return Activator.CreateInstance(type, parameters.ToArray());
            }
            catch (Exception ex)
            {
                innerException = ex;
            }

        throw new Exception("No constructor was found that had all the dependencies satisfied.", innerException);
    }
}
