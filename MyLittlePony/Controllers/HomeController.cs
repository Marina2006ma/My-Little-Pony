using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyLittlePony.Models;
using MyLittlePony.Services;
namespace MyLittlePony.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPonyService _ponyService;
    public HomeController(ILogger<HomeController> logger, IPonyService ponyService)
    {
        _logger = logger;
        _ponyService = ponyService;
    }

    public IActionResult Index(string tipo)
    {
        var ponys = _ponyService.GetPonyDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(ponys);
    }

    public IActionResult Details(int Numero)
    {
        var pony = _ponyService.GetDetailedPony(Numero);
        return View(pony);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id
        ?? HttpContext.TraceIdentifier
        });
    }
}