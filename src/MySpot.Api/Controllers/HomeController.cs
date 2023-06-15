using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySpot.Infrastructure;

namespace MySpot.Api.Controllers;

[Route("")]
public class HomeController : ControllerBase
{
    private readonly string _name;

    public HomeController(IOptions<AppOptions> appOptions)
    {
        _name = appOptions.Value.Name;
    }

    [HttpGet]
    public ActionResult<string> Get() => _name;
}
