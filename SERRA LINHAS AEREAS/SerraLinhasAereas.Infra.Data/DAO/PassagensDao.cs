using SerraLinhasAereas.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Infra.Data.DAO
{
    public class PassagensDao
    {
        string _connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SERRA_LINHAS_AEREAS;User ID=sa;Password=123;";
        public void AdiconarPassagem(Passagens Adiconarpassagens)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    var sql = @"INSERT INTO PASSAGENS VALUES(@ORIGEM,@DESTINO,@VALOR,@DATA_ORIGEM,@DATA_DESTINO)";

                    ConverterObjetoParaSql(Adiconarpassagens, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();

                }


            }

        }
        public List<Passagens> BuscarTodasPassagens()
        {
            List<Passagens> listaPassagens = new List<Passagens>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM PASSAGENS";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {

                        var passagemBuscada = ConverterDeSqlParaObjeto(leitor);

                        listaPassagens.Add(passagemBuscada);
                    }

                }

            }
            return listaPassagens;
        }
        public List<Passagens> BuscarPassagemDataOrigem(DateTime dataPassagemOrigem)
        {
            List<Passagens> listaPassagensOrigem = new List<Passagens>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM PASSAGENS WHERE DATA_ORIGEM = @DATA_PASSAGEM";

                    comando.Parameters.AddWithValue("@DATA_PASSAGEM", dataPassagemOrigem);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {

                        var passagemBuscada = ConverterDeSqlParaObjeto(leitor);

                        listaPassagensOrigem.Add(passagemBuscada);
                    }

                }

            }
            return listaPassagensOrigem;
        }
        public List<Passagens> BuscarPassagemDataDestino(DateTime dataPassagemDestino)
        {
            List<Passagens> listaPassagensDataDestino = new List<Passagens>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM PASSAGENS WHERE DATA_DESTINO = @DATA_PASSAGEM";

                    comando.Parameters.AddWithValue("@DATA_PASSAGEM", dataPassagemDestino);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {

                        var passagemBuscada = ConverterDeSqlParaObjeto(leitor);

                        listaPassagensDataDestino.Add(passagemBuscada);
                    }

                }

            }
            return listaPassagensDataDestino;
        }
        public List<Passagens> BuscarPassagemOrigem(string origem)
        {
            List<Passagens> ListaPassagensOrigem = new List<Passagens>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM PASSAGENS WHERE ORIGEM LIKE @ORIGEM";

                    comando.Parameters.AddWithValue("@ORIGEM", $"%{origem}%");

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var passagemBuscada = ConverterDeSqlParaObjeto(leitor);

                        ListaPassagensOrigem.Add(passagemBuscada);
                    }
                }
                return ListaPassagensOrigem;

            }
        }
        public List<Passagens> BuscarPassagemDestino(string destino)
        {
            List<Passagens> ListaPassagensDestino = new List<Passagens>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM PASSAGENS WHERE DESTINO LIKE @ORIGEM";

                    comando.Parameters.AddWithValue("@ORIGEM", $"%{destino}%");

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var passagemBuscada = ConverterDeSqlParaObjeto(leitor);

                        ListaPassagensDestino.Add(passagemBuscada);
                    }
                }
                return ListaPassagensDestino;

            }
        }
        public Passagens BuscarPassagemID(int id)
        {
            Passagens passagens = new Passagens();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM PASSAGENS WHERE ID_PASSAGEM = @ID_PASSAGEM";

                    comando.Parameters.AddWithValue("@ID_PASSAGEM", id);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                     passagens = ConverterDeSqlParaObjeto(leitor);

                        return passagens;
                    }
                }
                return null;

            }
        }
        public void AtualizarPassagem(Passagens passagens)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE PASSAGENS SET ORIGEM = @ORIGEM, DESTINO = @DESTINO, VALOR = @VALOR, DATA_ORIGEM = @DATA_ORIGEM, DATA_DESTINO = @DATA_DESTINO WHERE ID_PASSAGEM = @ID";

                    comando.Parameters.AddWithValue("@ID",passagens.ID);

                    ConverterObjetoParaSql(passagens,comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();

                }


            }

        }
        public void DeletarPassagem(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"DELETE FROM PASSAGENS WHERE ID_PASSAGEM = @ID_PASSAGEM";

                    comando.Parameters.AddWithValue("@ID_PASSAGEM", id);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }

        }
        public Passagens ConverterDeSqlParaObjeto(SqlDataReader leitor)
        {
            var id = Convert.ToInt32(leitor["ID_PASSAGEM"].ToString());
            var origem = leitor["ORIGEM"].ToString();
            var destino = leitor["DESTINO"].ToString();
            var valor = float.Parse(leitor["VALOR"].ToString());
            var dataOrigem = DateTime.Parse(leitor["DATA_ORIGEM"].ToString());
            var dataDestino = DateTime.Parse(leitor["DATA_DESTINO"].ToString());


            return new Passagens(id, origem, destino, valor, dataOrigem, dataDestino);

        }
        public void ConverterObjetoParaSql(Passagens passagens, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@ORIGEM", passagens.Origem);
            comando.Parameters.AddWithValue("@DESTINO", passagens.Destino);
            comando.Parameters.AddWithValue("@VALOR", passagens.Valor);
            comando.Parameters.AddWithValue("@DATA_ORIGEM", passagens.DataOrigem);
            comando.Parameters.AddWithValue("@DATA_DESTINO", passagens.DataDestino);
        }
    }
}
