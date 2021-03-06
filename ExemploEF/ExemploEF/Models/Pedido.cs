﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploEF.Models
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

        [ForeignKey("Cliente")]
        [Column("CLIENTEID")]
        public int ClienteCodigo { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
