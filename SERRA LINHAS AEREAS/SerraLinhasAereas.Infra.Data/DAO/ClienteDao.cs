using SerraLinhasAereas.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Infra.Data.DAO
{
    public class ClienteDao
    {

        string _connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SERRA_LINHAS_AEREAS;User ID=sa;Password=123;";

        public void AdicionarCliente(Cliente cliente)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    var sql = @"INSERT INTO CLIENTE VALUES(@CPF,@NOME,@SOBRENOME,@NOMECOMPLETO,@CEP,@RUA,@BAIRRO,@NUMERO,@COMPLEMENTO)";

                    ConverterObjetoParaSql(cliente, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();

                }


            }

        }
        public Cliente BuscarClienteCpf(int Cpf)
        {
            Cliente cliente = new Cliente();
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    var sql = @"SELECT * FROM CLIENTE WHERE CPF = @CPF";

                    comando.Parameters.AddWithValue("@CPF", Cpf);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        cliente = ConverterDeSqlParaObjeto(leitor);
                        return cliente;
                    }
                }
            }
            return null;
        }
        public List<Cliente> BuscarTodosCliente()
        {
            List<Cliente> ListaCliente = new List<Cliente>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CLIENTE";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {

                        var clienteBuscado = ConverterDeSqlParaObjeto(leitor);

                        ListaCliente.Add(clienteBuscado);
                    }

                }

            }
            return ListaCliente;
        }
        public void AtualizarCliente(Cliente cliente)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    var sql = @"UPDATE CLIENTE SET CPF = @CPF, NOME = @NOME, SOBRENOME = @SOBRENOME, NOMECOMPLETO = @NOMECOMPLETO, CEP = @CEP, RUA = @RUA, BAIRRO = @BAIRRO,NUMERO = @NUMERO,COMPLEMENTO = @COMPLEMENTO WHERE CPF = @CPF_ATUALIZAR;";

                    comando.Parameters.AddWithValue("@CPF_ATUALIZAR", cliente.Cpf);

                    ConverterObjetoParaSql(cliente, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }

            }
        }
        public void DeletarCliente(int Cpf)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"DELETE FROM CLIENTE WHERE CPF = @CPF_DELETAR";

                    comando.Parameters.AddWithValue("@CPF_DELETAR", Cpf);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }

        }
        public Cliente ConverterDeSqlParaObjeto(SqlDataReader leitor)
        {

            var cpf = Convert.ToInt32(leitor["CPF"].ToString());
            var nome = leitor["NOME"].ToString();
            var sobrenome = leitor["SOBRENOME"].ToString();
            var nomeCompleto = leitor["NOMECOMPLETO"].ToString();

            Endereco endereco = new Endereco()
            {
                Cep = Convert.ToInt32(leitor["CEP"].ToString()),
                Rua = leitor["RUA"].ToString(),
                Bairro = leitor["BAIRRO"].ToString(),
                Numero = Convert.ToInt32(leitor["NUMERO"].ToString()),
                Complemento = leitor["COMPLEMENTO"].ToString(),
            };
            return new Cliente(cpf, nome, sobrenome, nomeCompleto, endereco);

        }
        public void ConverterObjetoParaSql(Cliente cliente, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@SOBRENOME", cliente.Sobrenome);
            comando.Parameters.AddWithValue("@NOMECOMPLETO", cliente.NomeCompleto);
            comando.Parameters.AddWithValue("@CEP", cliente.Endereco.Cep);
            comando.Parameters.AddWithValue("@RUA", cliente.Endereco.Rua);
            comando.Parameters.AddWithValue("@BAIRRO", cliente.Endereco.Bairro);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Endereco.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Endereco.Complemento);
        }
    }
}
