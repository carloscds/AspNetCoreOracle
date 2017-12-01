using Devart.Data.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace MasterDetailAspnetCore.Repositorios
{
    public class RepositorioBase
    {
        protected OracleConnection conexao;

        public RepositorioBase()
        {
            conexao = new OracleConnection(Config.StringConexao);
        }
    }
}
