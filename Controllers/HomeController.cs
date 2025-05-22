
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
        Juego juego = new Juego(); 
        HttpContext.Session.SetString("juegos", Objeto.ObjectToString(juego));
        ViewBag.Juego = juego;
        return View();
    }

    [HttpPost]
    public IActionResult AdivinarLetra(char letra)
    {

        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juegos"));
        if (juego is not null)
        {
            if (!juego.finalizo)
            {
                ViewBag.codigo = juego.AdivinarLetra(letra);
                HttpContext.Session.SetString("juegos", Objeto.ObjectToString(juego));
            }
        }
        
        ViewBag.Juego = juego;
        return View("Index");
    }

    [HttpPost]
    public IActionResult AdivinarPalabra(string palabra)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juegos"));
        if (juego is not null)
        {
            if (!juego.finalizo)
            {
                ViewBag.palabra = juego.AdivinarPalabra(palabra.ToLower());
                HttpContext.Session.SetString("juegos", Objeto.ObjectToString(juego));
            }
        }
        
        ViewBag.Juego = juego;
        return View("Index");
    }
}
