using System.Collections.Generic;

namespace ConsultaLinq.Models
{
    public class Cidade
    {
        public int CidadeID { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
        public Cidade()
        {
            Cliente = new List<Cliente>();
        }
    }
}