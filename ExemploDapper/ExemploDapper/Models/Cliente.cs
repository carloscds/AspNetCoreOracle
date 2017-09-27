using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploEF.Models
{
    [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
        public Cliente()
        {
            Pedido = new List<Pedido>();
        }
    }
}
