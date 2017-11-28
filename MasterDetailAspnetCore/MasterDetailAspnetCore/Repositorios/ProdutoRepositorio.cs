using MasterDetailAspnetCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetailAspnetCore.Repositorios
{
    public class ProdutoRepositorio
    {
        public List<Produto> ObterTodos()
        {
            return new List<Produto>
            {
                new Produto { Id = 1 , Descricao = "Computador"},
                new Produto { Id = 2, Descricao = "HD"},
                new Produto { Id = 3 , Descricao = "Teclado"},
            };
        }

        public Produto ObterPorId(int produtoId)
        {
            return ObterTodos().Where(x => x.Id == produtoId).FirstOrDefault();
        }
    }
}
