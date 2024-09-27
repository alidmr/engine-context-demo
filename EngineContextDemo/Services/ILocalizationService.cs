namespace EngineContextDemo.Services;

public interface ILocalizationService
{
    string GetLocalizedValue(string language, string key);
}
