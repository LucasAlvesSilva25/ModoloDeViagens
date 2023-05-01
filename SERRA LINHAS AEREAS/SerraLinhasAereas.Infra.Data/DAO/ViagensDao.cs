using SerraLinhasAereas.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Infra.Data.DAO
{
    public class ViagensDao
    {
        string _connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SERRA_LINHAS_AEREAS;User ID=sa;Password=123;";
        public void MarcarViagem(Viagens viagens)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    var sql = @"INSERT INTO VIAGENS VALUES(@CODIGO_RESERVA,@DATA_COMPRA,@VALOR_TOTAL,@CPF_CLIENTE,@IDAEVOLTA,@ID_PASSAGEMIDA,@ID_PASSAGEMVOLTA,@RESUMO_VIAGEM)";

                    ConverterObjetoParaSql(viagens, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Viagens> BuscarTodasViagensCliente(int cpf)
        {
            List<Viagens> ListaViagens = new List<Viagens>();
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    var sql = @"SELECT * FROM VIAGENS WHERE CPF_CLIENTE = @CPF_CLIENTE";

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpf);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var viagensBuscada = ConverterDeSqlParaObjeto(leitor);
                        ListaViagens.Add(viagensBuscada);
                    }
                    return ListaViagens;
                }
            }
            return null;
        }
        public void RemarcarViagem(Viagens viagens)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    var sql = @"UPDATE VIAGENS SET CODIGO_RESERVA = @CODIGO_RESERVA, DATA_COMPRA = @DATA_COMPRA, VALOR_TOTAL = @VALOR_TOTAL,  CPF_CLIENTE = @CPF_CLIENTE, IDAEVOLTA = @IDAEVOLTA, ID_PASSAGEMIDA = @ID_PASSAGEMIDA, ID_PASSAGEMVOLTA = @ID_PASSAGEMVOLTA, RESUMO_VIAGEM = @RESUMO_VIAGEM WHERE CODIGO_RESERVA = @CODIGO";

                    comando.Parameters.AddWithValue("@CODIGO", viagens.CodigoReserva);

                    ConverterObjetoParaSql(viagens, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }

            }
        }
        public Viagens BuscarPassagemId(int idPassagem)
        {
            //var viagem = new Viagens();
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    var sql = @"SELECT * FROM VIAGENS WHERE ID_PASSAGEMIDA = @ID OR ID_PASSAGEMVOLTA = @ID ";

                    comando.Parameters.AddWithValue("@ID", idPassagem);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var viagem = ConverterDeSqlParaObjeto(leitor);
                        return viagem;
                    }
                }
            }
            return null;
        }
        public Viagens ConverterDeSqlParaObjeto(SqlDataReader leitor)
        {
            Viagens viagens;

            var CodigoReserva = leitor["CODIGO_RESERVA"].ToString();
            var DataCompra = Convert.ToDateTime(leitor["DATA_COMPRA"].ToString());
            var ValorTotal = float.Parse(leitor["VALOR_TOTAL"].ToString());
            var ClienteCpf = Convert.ToInt32(leitor["CPF_CLIENTE"].ToString());
            var IdaVolta = Convert.ToBoolean(leitor["IDAEVOLTA"].ToString());
            var PassagemIdaId = Convert.ToInt32(leitor["ID_PASSAGEMIDA"].ToString());          
            var resumoViagem = leitor["RESUMO_VIAGEM"].ToString();

            if (IdaVolta == true)
            {
                var PassagemVoltaId = Convert.ToInt32(leitor["ID_PASSAGEMVOLTA"].ToString());
                return viagens = new Viagens(CodigoReserva, DataCompra, ValorTotal, ClienteCpf, IdaVolta, PassagemIdaId, PassagemVoltaId, resumoViagem);
            }
            else
            {
                return viagens = new Viagens(CodigoReserva, DataCompra, ValorTotal, ClienteCpf, IdaVolta, PassagemIdaId, resumoViagem);
            }
        }
        public void ConverterObjetoParaSql(Viagens viagens, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@CODIGO_RESERVA", viagens.CodigoReserva);
            comando.Parameters.AddWithValue("@DATA_COMPRA", viagens.DataCompra);
            comando.Parameters.AddWithValue("@VALOR_TOTAL", viagens.ValorTotal);
            comando.Parameters.AddWithValue("@CPF_CLIENTE", viagens.ClienteViagens.Cpf);
            comando.Parameters.AddWithValue("@IDAEVOLTA", viagens.IdaVolta);
            comando.Parameters.AddWithValue("@ID_PASSAGEMIDA", viagens.PassagemIda.ID);
            if (viagens.IdaVolta == false)
            {
                comando.Parameters.AddWithValue("@ID_PASSAGEMVOLTA", DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@ID_PASSAGEMVOLTA", viagens.PassagemVolta.ID);
            }
            comando.Parameters.AddWithValue("@RESUMO_VIAGEM", viagens.ResumoViagens);
        }

    }
}
