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
        /// <summary>
        /// Exemplo Git
        /// </summary>
        /// <param name="args"></param>
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
                PedidoItem = new List<PedidoItem>()
                {
                    new PedidoItem() {
                        PedidoID = 1,
                        Produto = produtos[0],
                        Quantidade = 10,
                        Valor = 5
                    },
                    new PedidoItem() {
                        PedidoID = 1,
                        Produto = produtos[1],
                        Quantidade = 2,
                        Valor = 7
                    },
                }
            });

            pedidos.Add(new Pedido()
            {
                PedidoID = 2,
                Data = DateTime.Now.AddDays(-5),
                Cliente = clientes[1],

                PedidoItem = new List<PedidoItem>()
                {
                    new PedidoItem() {
                        PedidoID = 1,
                        Produto = produtos[1],
                        Quantidade = 10,
                        Valor = 5
                    }
                }
            });

            produtos[0].Pedido.Add(pedidos[0]);
            produtos[1].Pedido.Add(pedidos[0]);
            produtos[1].Pedido.Add(pedidos[1]);

            foreach(var p in pedidos)
            {
                Console.WriteLine("------------------");
                Console.WriteLine($"  Pedido: {p.PedidoID}");
                Console.WriteLine($" Cliente: {p.Cliente.Nome}");
                Console.WriteLine($"  Cidade: {p.Cliente.Cidade.Nome}");
                Console.WriteLine($"Produtos:");
                var total = 0M;
                foreach(var pro in p.PedidoItem)
                {
                    Console.WriteLine($"\t{pro.Produto.Nome}\t{pro.Quantidade}\t{pro.Valor}");
                    total += (pro.Quantidade * pro.Valor);
                }
                Console.WriteLine($"Total Pedido: {total.ToString("C")}");
            }


            var cli2 = from c in clientes
                       where c.Cidade.UF == "PR"
                       orderby c.Nome
                       select c;

            var cli21 = clientes
                .Where(c => c.Cidade.UF == "PR")
                .OrderByDescending(o => o.Nome)
                .Max(m => m.ClienteID);






        }
    }
}
