using AgendaContatos.Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContado.Dados
{
    public class ContatoRepositorio
    {
        private object retornoConsulta;

        public int codigoContato { get; private set; }
        
        public string nome { get; private set; }
        public string endereco { get; private set; }
        public string bairro { get; private set; }
        public string cidade { get; private set; }
        public string estado { get; private set; }
        public string telefone { get; private set; }

        public List<Contato> ConsultaContato()
        {
            List<Contato> retornoConsulta = new List<Contato>();

            string comandoSQL = "SELECT * FROM Contato;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContato;Uid=root;Pwd=;"); //Ponte
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                retornoConsulta.Add(new Contato
                {
                    codigoContato = Convert.ToInt32(dr["codigoContato"]),
                   
                    nome = dr["nome"].ToString(),
                    endereco = dr["endereco"].ToString(),
                    bairro = dr["bairro"].ToString(),
                    cidade = dr["cidade"].ToString(),
                    estado = dr["estado"].ToString(),
                    telefone = dr["telefone"].ToString(),
                    

                });
            }
            conexao.Close();
            return retornoConsulta;
        }



        public int InserirContato(Contato contato)
        {
            int codigoGerado = 0;


            string comandoSQL = "Insert Contato set nome=@nome, endereco=@endereco, bairro=@bairro, cidade=@cidade, estado=@estado, telefone=@telefone, codigoContato=@codigoContato;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContato;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@codigoContato", contato.codigoContato);
            comando.Parameters.AddWithValue("@nome", contato.nome);
            comando.Parameters.AddWithValue("@endereco", contato.endereco);
            comando.Parameters.AddWithValue("@bairro", contato.bairro);
            comando.Parameters.AddWithValue("@cidade", contato.cidade);
            comando.Parameters.AddWithValue("@estado", contato.estado);
            comando.Parameters.AddWithValue("@telefone", contato.telefone);
            comando.Parameters.AddWithValue("@codigoTipoContato", contato.TipoContato.codigoTipoContato);


            conexao.Open();

            comando.ExecuteNonQuery();

            comando = new MySqlCommand("SELECT MAX(codigoContato) from Contato", conexao);

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                codigoGerado = Convert.ToInt32(dr[0]);
            }
            conexao.Close();
            return codigoGerado;
        }

        public void AlterarContato(Contato contato)
        {


            string comandoSQL = "Uptade Contato set nome=@nome, endereco=@endereco, bairro=@bairro, cidade=@cidade, estado=@estado, telefone=@telefone codigoContato=@codigoContato  ;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContato;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);


            comando.Parameters.AddWithValue("@codigoContato", contato.codigoContato);
            comando.Parameters.AddWithValue("@nome", contato.nome);
            comando.Parameters.AddWithValue("@endereco", contato.endereco);
            comando.Parameters.AddWithValue("@bairro", contato.bairro);
            comando.Parameters.AddWithValue("@cidade", contato.cidade);
            comando.Parameters.AddWithValue("@estado", contato.estado);
            comando.Parameters.AddWithValue("@telefone", contato.telefone);
            comando.Parameters.AddWithValue("@codigoContato", contato.TipoContato.codigoTipoContato);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void ExcluirContato(int codigoContato)
        {


            string comandoSQL = "Delete from Contato where codigoContato=@codigoContato;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContato;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);


            comando.Parameters.AddWithValue("@codigoContato", codigoContato);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

    }
}
