﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploEF.Models
{
    [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("CLIENTEID")]
        public int ClienteID { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
