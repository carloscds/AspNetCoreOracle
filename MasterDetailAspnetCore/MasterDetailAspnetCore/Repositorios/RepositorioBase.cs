using Devart.Data.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetailAspnetCore.Repositorios
{
    public class RepositorioBase
    {
        string strConn = "User ID=system;Password=cds123456;" +
                         "Server=cdsoracle.southcentralus.cloudapp.azure.com;" +
                         "Direct=True;Sid=xe;Port=1521";

        protected OracleConnection conexao;

        public RepositorioBase()
        {
            conexao = new OracleConnection(strConn);
        }
    }
}
