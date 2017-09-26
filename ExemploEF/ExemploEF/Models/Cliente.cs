using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploEF.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Codigo{ get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
