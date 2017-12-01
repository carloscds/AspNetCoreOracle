using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetailAspnetCore.Repositorios
{
    public class Config
    {
        public static string StringConexao { get; set; }

        public Config(string conexao)
        {
            StringConexao = conexao;
        }
    }
}
