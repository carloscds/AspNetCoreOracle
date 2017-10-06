using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Contexto();

            //// inclui um novo cliente
            //var novoCliente = new Cliente() { Nome = "Jose"};
            //db.Cliente.Add(novoCliente);
            //db.SaveChanges();

            //var cli = db.Cliente.Where(w => w.Nome == "Jose+")
            //    .FirstOrDefault();
            //if(cli != null)
            //{
            //    cli.Nome = "Jose da Silva";
            //    db.SaveChanges();
            //}

            var cli = db.Cliente.Where(w => w.Nome == "Jose da Silva++")
                .FirstOrDefault();
            if(cli != null)
            {
                var ped = new Pedido()
                {
                    Data = DateTime.Now,
                    Valor = 1000,
                    Cliente = cli
                };
                db.Pedido.Add(ped);
            }

            var consulta = db.Cliente;
            foreach(var c in consulta)
            {
                Console.WriteLine($"Cliente: {c.Nome} - Pedidos: {c.Pedido.Count}");
            }

        }
    }
}
