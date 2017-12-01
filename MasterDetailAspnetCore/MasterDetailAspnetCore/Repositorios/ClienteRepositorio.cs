using MasterDetailAspnetCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MasterDetailAspnetCore.Repositorios
{
    public class ClienteRepositorio : RepositorioBase
    {
        public List<Cliente> ObterTodos()
        {
            return conexao.Query<Cliente>("select * from CLIENTE").ToList();
        }

        public Cliente ObterPorId(int clienteId)
        {
            return conexao.Query<Cliente>(
                "select * from CLIENTE where ClienteID = :ID",
                new Dictionary<string,object>() { { ":ID", clienteId} })
                .FirstOrDefault();
        }
    }
}
