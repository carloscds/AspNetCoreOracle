using ConsultaLinq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var cidades = new List<Cidade>();
            cidades.Add(new Cidade() {
                CidadeID = 1,
                Nome = "Cornelio",
                UF = "PR",
                CEP = "86300-000"
            });
            cidades.Add(new Cidade() {
                CidadeID = 2,
                Nome = "Londrina",
                UF = "PR",
                CEP = "86010-123"
            });

            var clientes = new List<Cliente>();
            clientes.Add(new Cliente() {
                ClienteID = 1,
                Nome = "Carlos",
                Cidade = cidades.Where(w=> w.CEP == "86300-000").FirstOrDefault()});
            clientes.Add(new Cliente()
            {
                ClienteID = 2,
                Nome = "Angelo",
                Cidade = cidades.Where(w => w.CEP == "86010-123").FirstOrDefault()
            });

            var produtos = new List<Produto>();
            produtos.Add(new Produto()
            {
                ProdutoID = 1,
                Nome = "Acucar",
                Valor = 15
            });
            produtos.Add(new Produto()
            {
                ProdutoID = 2,
                Nome = "Arroz",
                Valor = 12
            });

            var pedidos = new List<Pedido>();
            pedidos.Add(new Pedido()
            {
                PedidoID = 1,
                Data = DateTime.Now,
                Cliente = clientes[0],
                Produto = new List<Produto>()
                {
                    produtos[0],
                    produtos[1]
                }
            });

            pedidos.Add(new Pedido()
            {
                PedidoID = 2,
                Data = DateTime.Now.AddDays(-5),
                Cliente = clientes[1],
                Produto = new List<Produto>()
                {
                    produtos[1]
                }
            });


        }
    }
}
