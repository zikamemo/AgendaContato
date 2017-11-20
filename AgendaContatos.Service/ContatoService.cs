using AgendaContado.Dados;
using AgendaContatos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos.Service
{
    public class ContatoService
    {
        ContatoRepositorio _repositorio = new ContatoRepositorio();

        public List<Contato> ConsultaContato()
        {
            return _repositorio.ConsultaContato();
        }

        

        public int InserirContato(Contato contato)
        {
            return _repositorio.InserirContato(contato);
        }

        public void AlterarContato(Contato contato)
        {
            _repositorio.AlterarContato(contato);
        }

        public void ExcluirContato(int codigocontato)
        {
            _repositorio.ExcluirContato(codigocontato);
        }
    }
}
