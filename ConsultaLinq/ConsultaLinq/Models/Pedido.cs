using System;
using System.Collections.Generic;

namespace ConsultaLinq.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Valor { get; set; }
        public virtual ICollection<Produto> Produto { get; set; }
    }
}