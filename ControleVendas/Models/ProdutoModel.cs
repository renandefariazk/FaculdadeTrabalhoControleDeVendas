using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVendas.Models
{
    public class ProdutoModel
    {
        public long? ProdutoModelId { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public Decimal PrecoUnit { get; set; }
        public int Quantidade { get; set; }
        public Decimal PrecoTotal { get; set; }

        public ProdutoModel()
        {

        }

    }
}
