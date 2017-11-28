using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetailAspnetCore.Entidades
{
    public class PedidoDeVenda
    {
        public Guid Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<PedidoDeVendaItem> Itens { get; set; }
        public PedidoDeVenda()
        {
            Id = Guid.NewGuid();
            Itens = new List<PedidoDeVendaItem>();
        }

    }
}
