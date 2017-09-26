using ExemploEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Contexto();

            var cli = new Cliente() { Nome = "Carlos 2" };
            var pedido = new Pedido() { Data = DateTime.Now, Valor = 200, Cliente = cli };
            db.Cliente.Add(cli);
            db.Pedido.Add(pedido);
            db.SaveChanges();
        }
    }
}
