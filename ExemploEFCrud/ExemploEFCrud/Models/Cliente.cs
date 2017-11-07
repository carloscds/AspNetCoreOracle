using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExemploEFCrud.Models
{
    [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("CLIENTEID")]
        public int ClienteID { get; set; }
        [Column("NOME")]
        [Required(ErrorMessage ="Nao pode ser branco")]
        //[MaxLength(50)]
        public string Nome { get; set; }
        [NotMapped]
        public decimal Limite { get; set; }
    }
}