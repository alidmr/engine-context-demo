namespace EngineContextDemo.Services;

public class LocalizationService : ILocalizationService
{
    public string GetLocalizedValue(string language, string key)
    {
        string value;
        switch (language)
        {
            case "en-US":
                value = $"{key}: Test EN value";
                break;
            default:
                value = $"{key}: Test TR value";
                break;
        }

        return value;
    }
}
