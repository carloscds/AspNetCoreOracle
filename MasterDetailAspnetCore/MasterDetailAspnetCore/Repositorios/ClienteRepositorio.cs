using MasterDetailAspnetCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetailAspnetCore.Repositorios
{
    public class ClienteRepositorio
    {
        public List<Cliente> ObterTodos()
        {
            return new List<Cliente>
            {
                new Cliente { Id = 1 , Nome = "Luciano"},
                new Cliente { Id = 2 , Nome = "Lucas"},
                new Cliente { Id = 3 , Nome = "Maria"},
            };
        }

        public Cliente ObterPorId(int clienteId)
        {
            return ObterTodos().Where(x => x.Id == clienteId).FirstOrDefault();
        }
    }
}
