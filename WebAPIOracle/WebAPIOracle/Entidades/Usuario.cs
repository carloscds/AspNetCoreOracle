using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIOracle.Entidades
{
    [Dapper.Contrib.Extensions.Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("USUARIOID")]
        public int UsuarioID { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("LOGIN")]
        public string Login { get; set; }
        [Column("SENHA")]
        public string Senha { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }

    }
}
