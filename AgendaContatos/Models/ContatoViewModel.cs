using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaContatos.Models
{
    public class ContatoViewModel
    {
        public int codigoContato { get; set; }
        public string Nome { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string telefone { get; set; }
        public Contato Contato { get; set; }
    }
}