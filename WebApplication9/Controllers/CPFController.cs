using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class CPFController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Cpf());
        }

        [HttpPost]
        public IActionResult Index(Cpf cpf)
        {
            if (ModelState.IsValid)
            {
                // Se o CPF for válido, faça algo
                return RedirectToAction("Sucesso");
            }
            return View(cpf);
        }

        public IActionResult Sucesso()
        {
            return View();
        }
    }
}
