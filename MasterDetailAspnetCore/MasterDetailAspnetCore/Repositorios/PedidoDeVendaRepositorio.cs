using MasterDetailAspnetCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetailAspnetCore.Repositorios
{

    public class PedidoDeVendaRepositorio
    {
        public static List<PedidoDeVenda> pedidos = new List<PedidoDeVenda>();

        public Guid GerarPedido(Cliente cliente)
        {
            var pedido = new PedidoDeVenda { Cliente = cliente };
            pedidos.Add(pedido);
            return pedido.Id;
        }

        public PedidoDeVenda ObterPorId(Guid pedidoId)
        {
            return pedidos.Where(x => x.Id == pedidoId).FirstOrDefault();
        }

        public void AdicionarItem(Guid pedidoId, Produto produto, int quantidade, decimal valor)
        {
            var pedido = ObterPorId(pedidoId);

            pedido.Itens.Add(new PedidoDeVendaItem
            {
                PedidoDeVendaId = pedidoId,
                Produto  = produto,
                Quantidade = quantidade,
                Valor = valor
            });
        }
    }
}
