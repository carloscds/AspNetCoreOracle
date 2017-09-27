using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploEF.Models
{
    [Table("PEDIDO")]
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
