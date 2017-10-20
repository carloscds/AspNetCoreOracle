using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExemploJS.Models;

namespace ExemploJS.Controllers
{
    public class HomeController : Controller
    {
        static string usuario;
        public IActionResult Index()
        {
            var lista = new List<Cliente>();
            lista.Add(new Cliente() { ID = 1, Nome = "Carlos", Cidade = "CPP" });
            lista.Add(new Cliente() { ID = 2, Nome = "Antonio", Cidade = "SP" });
            lista.Add(new Cliente() { ID = 3, Nome = "Maria", Cidade = "LDA" });
            ViewBag.Horario = DateTime.Now.ToString();
            return View(lista);
        }

        public JsonResult JSTeste()
        {
            return Json("Javascript from Server");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
