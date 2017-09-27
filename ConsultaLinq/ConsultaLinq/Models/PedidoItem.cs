namespace ConsultaLinq.Models
{
    public class PedidoItem
    {
        public int PedidoID { get; set; }
        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}