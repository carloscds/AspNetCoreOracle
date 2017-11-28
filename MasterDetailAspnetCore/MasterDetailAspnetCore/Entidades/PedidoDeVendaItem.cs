using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetailAspnetCore.Entidades
{
    public class PedidoDeVendaItem
    {
        public Guid Id { get; set; }
        public Guid PedidoDeVendaId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public PedidoDeVendaItem()
        {
            Id = Guid.NewGuid();
        }
    }
}
