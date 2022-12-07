using FiapSmartCity.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FiapSmartCity.Repository
{
    public class CadastroPessoaRepository
    {
        public IList<CadastroPessoa> Listar()
        {
            IList<CadastroPessoa> lista = new List<CadastroPessoa>();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT ID, NOME, ENDERECO FROM PESSOA";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    CadastroPessoa cadastroPessoa = new CadastroPessoa();
                    cadastroPessoa.Id = Convert.ToInt32(dataReader["ID"]);
                    cadastroPessoa.Nome = dataReader["NOME"].ToString();
                    cadastroPessoa.Endereco = dataReader["ENDERECO"].ToString();

                    // Adiciona o modelo da lista
                    lista.Add(cadastroPessoa);
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return lista;
        }

        public CadastroPessoa Consultar(int id)
        {

            CadastroPessoa cadastroPessoa = new CadastroPessoa();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT ID, NOME, ENDERECO FROM PESSOA WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = id;
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    cadastroPessoa.Id = Convert.ToInt32(dataReader["ID"]);
                    cadastroPessoa.Nome = dataReader["NOME"].ToString();
                    cadastroPessoa.Endereco = dataReader["ENDERECO"].ToString();
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return cadastroPessoa;
        }

        public void Inserir(CadastroPessoa cadastroPessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO PESSOA (NOME, ENDERECO ) VALUES ( @nome, @endereco ) ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@nome", SqlDbType.Text);
                command.Parameters["@nome"].Value = cadastroPessoa.Nome;
                command.Parameters.Add("@endereco", SqlDbType.Text);
                command.Parameters["@endereco"].Value = Convert.ToString(cadastroPessoa.Endereco);

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Alterar(CadastroPessoa cadastroPessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE PESSOA SET NOME = @nome , ENDERECO = @endereco WHERE ID = @id";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@nome", SqlDbType.Text);
                command.Parameters.Add("@endereco", SqlDbType.Text);
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@nome"].Value = cadastroPessoa.Nome;
                command.Parameters["@endereco"].Value = Convert.ToString(cadastroPessoa.Endereco);
                command.Parameters["@id"].Value = cadastroPessoa.Id;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Excluir(int id)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "DELETE PESSOA WHERE ID = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}
    
