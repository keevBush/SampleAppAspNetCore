using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SampleAppAspNetCore.Models;

namespace SampleAppAspNetCore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var env = Environment.OSVersion;
        var data = new WebEnv
        {
            Name = env.ToString(),
            OsVersion = env.VersionString,
            Os = Enum.GetName (env.Platform)
        };
        return View(data);
    }

    public IActionResult Privacy()
    {
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
public class WebEnv
{
    public string? Os { get; set; }
    public string OsVersion { get;set;}
    public string Name { get;set;}
}