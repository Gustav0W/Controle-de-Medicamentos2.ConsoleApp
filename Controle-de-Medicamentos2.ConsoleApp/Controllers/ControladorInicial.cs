using Microsoft.AspNetCore.Mvc;

namespace Controle_de_Medicamentos2.ConsoleApp.Controllers;

[Route("/")]
public class ControladorInicial : Controller
{
    [HttpGet]
    public IActionResult PaginaInicial()
    {
        return View();
    }
}