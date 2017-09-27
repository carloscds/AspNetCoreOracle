using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaLinq.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public Cidade Cidade { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
     }
}
