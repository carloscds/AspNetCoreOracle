using ExemploEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExemploEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Contexto();
            db.Database.Log = MostraLog;

            var cli = new Cliente() { Nome = "Carlos" };
            var pedido = new Pedido()
            {
                Data = DateTime.Now,
                Valor = 100,
                Cliente = cli
            };
            db.Cliente.Add(cli);
            db.Pedido.Add(pedido);
            db.SaveChanges();

            var valorPedido = db.Cliente
                .First()
                .Pedido
                .Where(w => w.Valor > 10)
                .Sum(w => w.Valor);





            //var c = db.Cliente.Where(w => w.Nome == "Carlos").FirstOrDefault();
            //c.Nome = "Carlos 2";
            //db.SaveChanges();



        }

        public static void MostraLog(string sql)
        {
            Console.WriteLine(sql);
        }
    }
}
