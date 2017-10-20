using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExemploAula.Models;

namespace ExemploAula.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Mensagem = "Retornado pelo controler";
            return View();
        }

        public IActionResult Lista()
        {
            var produtos = new List<Produto>();
            produtos.Add(new Produto() { ID = 1, Nome = "Laranja", Preco = 2.5M });
            produtos.Add(new Produto() { ID = 2, Nome = "Maça", Preco = 1.5M });
            produtos.Add(new Produto() { ID = 3, Nome = "Banana", Preco = 5 });
            produtos.Add(new Produto() { ID = 4, Nome = "Morango", Preco = 7 });
            produtos.Add(new Produto() { ID = 5, Nome = "Jaboticaba", Preco = 4 });

            return View(produtos);
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
