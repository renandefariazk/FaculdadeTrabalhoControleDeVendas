using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVendas.Models
{
    public class ClienteModel
    {
        public ClienteModel() { }  
        public int cli_cpf { get; set; }
        public string cli_nome { get; set; }
        public string cli_endereco { get; set; }
        public int cli_fone { get; set; }
    }
}
