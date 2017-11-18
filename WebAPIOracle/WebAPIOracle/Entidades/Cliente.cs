using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIOracle.Entidades
{
    [Dapper.Contrib.Extensions.Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("CLIENTEID")]
        public int ClienteID { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
    }

}
