using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    [Table("PEDIDO")]
    public class Pedido
    {
        [Key]
        [Column("PEDIDOID")]
        public int PedidoID { get; set; }
        [Column("DATA")]
        public DateTime Data { get; set; }
        [Column("VALOR")]
        public decimal Valor { get; set; }
        [Column("CLIENTEID")]
        [ForeignKey("Cliente")]
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
