using MasterDetailAspnetCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MasterDetailAspnetCore.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase
    {
        public List<Produto> ObterTodos()
        {
            return conexao.Query<Produto>("select PRODUCT_ID,PRODUCT_NAME,UNIT_PRICE from PRODUCTS").ToList();
        }

        public Produto ObterPorId(int produtoId)
        {
            return conexao.Query<Produto>(
             "select PRODUCT_ID,PRODUCT_NAME,UNIT_PRICE from PRODUCTS where PRODUCT_ID = :ID",
             new Dictionary<string, object>() { { ":ID", produtoId} })
             .FirstOrDefault();
        }
    }
}
