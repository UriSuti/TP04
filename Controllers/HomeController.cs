using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (Juego.finalizo)
        {
            Juego.IniciarNuevoJuego();
        }
        return View();
    }

    [HttpPost]
    public IActionResult AdivinarLetra(char letra)
    {
        if (!Juego.finalizo)
        {
            Juego.AdivinarLetra(letra);
        }
            
        return RedirectToAction("Index");
    }
}
