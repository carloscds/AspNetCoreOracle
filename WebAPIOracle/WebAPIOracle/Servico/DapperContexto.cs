using Devart.Data.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIOracle.Servico
{
    public class DapperContexto
    {
        private string conexaoSQL;

        public DapperContexto(string conexao)
        {
            conexaoSQL = conexao;
        }

        public OracleConnection ConexaoOracle()
        {
            return new OracleConnection(conexaoSQL);
        }
    }
}
