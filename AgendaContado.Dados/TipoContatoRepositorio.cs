using AgendaContatos.Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContado.Dados
{
   public  class TipoContatoRepositorio 
    {
        private object codigoContato;

        public List<TipoContato> ConsultaTipoContatos()
        {
            List<TipoContato> retornoConsulta = new List<TipoContato>();

            string comandoSQL = "SELECT * FROM TipoContato;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContato;Uid=root;Pwd=;"); //Ponte
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                retornoConsulta.Add(new TipoContato
                {
                    codigoTipoContato = Convert.ToInt32(dr["codigoTipoContato"]),
                    descricao = dr["descricao"].ToString(),
                  
                });
            }

            return retornoConsulta;
        }

        

        public int InserirTipoContato(TipoContato tipoContato)
        {
            int codigoGerado = 0;

            string comandoSQL = "Insert into TipoContato ( descricao) values ( @descricao);";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContato;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

           
            comando.Parameters.AddWithValue("@descricao", tipoContato.descricao);

            conexao.Open();

            comando.ExecuteNonQuery();

            comando = new MySqlCommand("SELECT MAX(codigoTipoContato) from TipoContato", conexao);

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                codigoGerado = Convert.ToInt32(dr[0]);
            }

            return codigoGerado;
        }

        public void AlterarTipoContato(TipoContato tipoContato)
        {


            string comandoSQL = "Uptade TipoContato set  Descricao=@Descricao,  where codigoTipoContato=@codigoTipoContato;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContato;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@codigoTipoContato", tipoContato.codigoTipoContato);
           
            comando.Parameters.AddWithValue("@descricao", tipoContato.descricao);
           


            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void ExcluirTipoContato(int codigoTipoContato)
        {


            string comandoSQL = "Delete from TipoContato where codigoTipoContato=@codigoTipoContato;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContato;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);


            comando.Parameters.AddWithValue("@codigoTipoContato", codigoTipoContato);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }
    }
   
       }
        


