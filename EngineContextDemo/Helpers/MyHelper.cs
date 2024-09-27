using EngineContextDemo.Infrastructure;
using EngineContextDemo.Services;

namespace EngineContextDemo.Helpers;

public static class MyHelper
{
    public static string OptimizeText(this string text, string language)
    {
        var locService = EngineContext.Current.Resolve<ILocalizationService>();

        var value = locService.GetLocalizedValue(language, text);

        return value;
    }
}
