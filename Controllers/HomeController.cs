
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
        if (!Juego.finalizo)
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
            ViewBag.codigo = Juego.AdivinarLetra(letra);
        }
            
        return View("Index");
    }

    [HttpPost]
    public IActionResult AdivinarPalabra(string palabra)
    {
        if (!Juego.finalizo)
        {
            ViewBag.palabra = Juego.AdivinarPalabra(palabra);
        }
        return View("Index");
    }
}
