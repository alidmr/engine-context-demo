using EngineContextDemo.Helpers;
using EngineContextDemo.Infrastructure;
using EngineContextDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace EngineContextDemo.Controllers;

[Route("api/tests")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("get-user-name")]
    public string GetUserName()
    {
        var userService = EngineContext.Current.Resolve<IUserService>();

        var userName = userService.GetUserName();

        return userName;
    }

    [HttpGet("get-localized-value")]
    public string GetLocalizedValue(string language, string key)
    {
        var localizationService = EngineContext.Current.Resolve<ILocalizationService>();

        return localizationService.GetLocalizedValue(language, key);
    }

    [HttpGet("get-static-localized-value")]
    public string GetStaticLocalizedValue(string language, string key)
    {
        var result = key.OptimizeText(language);

        return result;
    }
}
