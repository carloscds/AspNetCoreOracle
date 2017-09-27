using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using ExemploEF.Models;

namespace ExemploDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var conexao = new OracleConnection("data source=oracle; user id=system; password=cds123456;");

            //conexao.Execute("insert into cliente(nome) values(:nome)", new { nome = "Carlos "+DateTime.Now.ToString() });

            var cli = conexao.Query<Cliente, Pedido, Cliente>(@"select c.*, p.PedidoID, p.Data, p.Valor
                                                               from cliente c
                                                               left join pedido p on c.clienteid = p.clienteID",
                                                               (c, p) =>
                                                               {
                                                                   if (p != null)
                                                                   {
                                                                       p.Cliente = c;
                                                                       c.Pedido.Add(p);
                                                                   }
                                                                   return c;
                                                               },
                                                               splitOn: "PedidoID");
            foreach(var d in cli)
            {
                Console.WriteLine($"{d.Nome} - {d.Pedido.Count} pedidos");
            }
        }
    }
}
