using System.Collections.Generic;

namespace ConsultaLinq.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
        public Produto()
        {
            Pedido = new List<Pedido>();
        }
    }
}