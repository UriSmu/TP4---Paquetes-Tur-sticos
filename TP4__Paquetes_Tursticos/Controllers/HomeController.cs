using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP4__Paquetes_Tursticos.Models;

namespace TP4__Paquetes_Tursticos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Paquetes = ORTWorld.Paquetes;
        return View();
    }

    public IActionResult SelectPaquete()
    {
         ViewBag.ListaDestinos = ORTWorld.ListaDestinos;
         ViewBag.ListaAereos = ORTWorld.ListaAereos;
         ViewBag.ListaHoteles = ORTWorld.ListaHoteles;
         ViewBag.ListaExcursiones = ORTWorld.ListaExcursiones;
         return View();
    }

    public IActionResult GuardarPaquete (int Destino, int Hotel, int Aereo, int Excursion)
    {
        bool a = false;
        bool b = false;
        if(!(Destino > 0 && Destino <= 10))
        {
            ViewBag.MensajeError = "El destino " + Destino + " no existe en nuestra web.";
            a = true;
        }
        else if(!(Hotel > 0 && Hotel <= 5))
        {
            ViewBag.MensajeError = "El hotel " + Hotel + " no existe en nuestra web.";
            a = true;
        }
        else if(!(Aereo > 0 && Aereo <= 5))
        {
            ViewBag.MensajeError = "El aéreo " + Aereo + " no existe en nuestra web.";
            a = true;
        }
        else if(!(Excursion > 0 && Excursion <= 5))
        {
            ViewBag.MensajeError = "La excursion " + Excursion + " no existe en nuestra web.";
            a = true;
        }
        else
        {
            Paquete paquete = new Paquete(ORTWorld.ListaHoteles[Hotel-1], ORTWorld.ListaAereos[Aereo-1], ORTWorld.ListaExcursiones[Excursion-1]);
            b = ORTWorld.IngresarPaquete(ORTWorld.ListaDestinos[Destino-1], paquete);
            if(!b) ViewBag.MensajeError = "El destino " + ORTWorld.ListaDestinos[Destino-1] + " (#" + Destino + ") ya tiene un paquete en nuestra web.";
        }

        if(a || !b)
        {
            ViewBag.ListaDestinos = ORTWorld.ListaDestinos;
            ViewBag.ListaAereos = ORTWorld.ListaAereos;
            ViewBag.ListaHoteles = ORTWorld.ListaHoteles;
            ViewBag.ListaExcursiones = ORTWorld.ListaExcursiones;
            return View("SelectPaquete");
        }

        ViewBag.Paquetes = ORTWorld.Paquetes;
        return View("Index");
    }
}
