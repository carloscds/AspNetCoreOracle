using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MasterDetailAspnetCore.Repositorios;
using MasterDetailAspnetCore.Entidades;

namespace MasterDetailAspnetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PedidoDeVenda()
        {
            ViewBag.Clientes = new SelectList(new ClienteRepositorio().ObterTodos(), "ClienteID", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult PedidoDeVenda(int clienteId)
        {
            var clienteRepo = new ClienteRepositorio();
            var pedidoRepo = new PedidoDeVendaRepositorio();

            var cliente = clienteRepo.ObterPorId(clienteId);
            var idGerado = pedidoRepo.GerarPedido(cliente);

            return RedirectToAction("PedidoDeVendaItens", new { pedidoId = idGerado });
        }

        public IActionResult PedidoDeVendaItens(Guid pedidoId)
        {

            var pedidoRepo = new PedidoDeVendaRepositorio();
            var produtoRepo = new ProdutoRepositorio();

            var pedido = pedidoRepo.ObterPorId(pedidoId);

            ViewBag.Produtos = new SelectList(produtoRepo.ObterTodos(), "Product_ID", "Product_Name");

            return View(pedido);
        }

        [HttpPost]
        public IActionResult PedidoDeVendaItens(Guid pedidoId, int produtoId, int quantidade, decimal valor)
        {
            var pedidoRepo = new PedidoDeVendaRepositorio();
            var produtoRepo = new ProdutoRepositorio();

            var produto = produtoRepo.ObterPorId(produtoId);
            pedidoRepo.AdicionarItem(pedidoId, produto, quantidade, valor);

            var pedido = pedidoRepo.ObterPorId(pedidoId);
            return Json(new
            {
                itens = pedido.Itens,
                total = pedido.Itens.Sum(x => x.Quantidade * x.Valor).ToString("N2")
            });
        }

        [HttpPost]
        public IActionResult BuscaPreco(int produtoId)
        {
            var produtoRepo = new ProdutoRepositorio();

            var produto = produtoRepo.ObterPorId(produtoId);
            return Json(produto.Unit_Price);
        }

        [HttpPost]
        public IActionResult GravarPedido(Guid Id)
        {
            var pedidoRepo = new PedidoDeVendaRepositorio();
            var pedido = pedidoRepo.ObterPorId(Id);
            return RedirectToAction("PedidoDeVenda");
        }
    }

}
