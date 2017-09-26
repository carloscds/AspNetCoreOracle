﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploEF.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}