using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Android.Runtime;
using MauiMYSQL.Models;
using MySqlConnector;

namespace MauiMYSQL.Models
{
    public class Livros : Conecta
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string autor { get; set; }
        public string ano_lancamento { get; set; }

        public List<Livros> listaLivros = new List<Livros>();

        public Livros() { }

        public bool Livros_Add(string nome, string autor, string ano_lancamento)
        {
            if (!Conexao())
            {
                return false;
            }


            StrQuery = "INSERT INTO livros (nome, autor, ano_lancamento) VALUES (@nome, @autor, @ano_lancamento)";
            Cmd = new MySqlCommand(StrQuery, Conn);
            Cmd.Parameters.AddWithValue("@nome", nome);
            Cmd.Parameters.AddWithValue("@autor", autor);
            Cmd.Parameters.AddWithValue("@ano_lancamento", ano_lancamento);
            try
            {
                Cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // retornar os livros cadastrados no banco de dados em uma lista

        public bool Livros_Consulta()
        {
            if (!Conexao())
            {
                return false;
            }

            StrQuery = "SELECT * FROM livros order by nome";
            MySqlCommand cmd = new MySqlCommand(StrQuery, Conn);
            cmd.CommandType = System.Data.CommandType.Text;
            Dr = cmd.ExecuteReader();
            listaLivros.Clear();
            while (Dr.Read())
            {
                    listaLivros.Add(new Livros { id = int.Parse(Dr["id"].ToString()), 
                                               nome = Dr["nome"].ToString(), 
                                               autor = Dr["autor"].ToString(), 
                                               ano_lancamento = Dr["ano_lancamento"].ToString()
                                             }
                                  );
            }

            return true;

        }










    }
}
