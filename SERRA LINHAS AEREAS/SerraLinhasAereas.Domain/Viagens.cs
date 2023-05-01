using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain
{
    public class Viagens
    {
        public string CodigoReserva { get; set; }
        public DateTime DataCompra { get; set; }
        public float ValorTotal { get; set; }
        public Cliente ClienteViagens { get; set; }
        public bool IdaVolta { get; set; }
        public Passagens PassagemIda { get; set; }
        public Passagens PassagemVolta { get; set; }
        public string ResumoViagens { get; set; }

        public void ValidarDatasPassagens(DateTime passagemIda, DateTime passagemVolta)
        {
            var comparaDatas = DateTime.Compare(passagemIda, passagemVolta);
            if (comparaDatas > 0)
            {
                throw new Exception("A data de volta não pode ser menor que data de ida!");
            }
        }
        public static string GerarCodigoReserva()
        {
            var letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(letras, 6)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        public void GerarResumoViagens(bool idaVolta)
        {
            if (idaVolta == false)
            {
                ResumoViagens = $"Seu voo de {PassagemIda.Origem} a {PassagemIda.Destino} será dia {PassagemIda.DataOrigem.ToString("dd/MM/yyyy")} às {PassagemIda.DataOrigem.ToString("HH:mm")} ";
            }
            else
            {
                ValidarDatasPassagens(PassagemIda.DataOrigem,PassagemVolta.DataOrigem);
                ResumoViagens = $"Seu voo de {PassagemIda.Origem} a {PassagemIda.Destino} será dia {PassagemIda.DataOrigem.ToString("dd/MM/yyyy")} às {PassagemIda.DataOrigem.ToString("HH:mm")} e " +
                    $"Seu voo de volta {PassagemVolta.Origem} a {PassagemVolta.Destino} será dia {PassagemVolta.DataOrigem.ToString("dd/MM/yyyy")} às {PassagemVolta.DataOrigem.ToString("HH:mm")}";
            }
        }
        public Viagens(string codigoReserva, DateTime dataCompra, float valorTotal, int cpfCliente, bool idaVolta, int passagemIda, int passagemVolta, string resumoViagens)
        {
            ClienteViagens = new Cliente();
            PassagemIda = new Passagens();
            PassagemVolta = new Passagens();
            CodigoReserva = codigoReserva;
            DataCompra = dataCompra;
            ValorTotal = valorTotal;
            ClienteViagens.Cpf = cpfCliente;
            IdaVolta = idaVolta;
            PassagemIda.ID = passagemIda;
            PassagemVolta.ID = passagemVolta;
            ResumoViagens = resumoViagens;
        }

        public Viagens(string codigoReserva, DateTime dataCompra, float valorTotal, int cpfCliente, bool idaVolta, int passagemIda, string resumoViagens)
        {
            ClienteViagens = new Cliente();
            PassagemIda = new Passagens();
            PassagemVolta = new Passagens();
            CodigoReserva = codigoReserva;
            DataCompra = dataCompra;
            ValorTotal = valorTotal;
            ClienteViagens.Cpf = cpfCliente;
            IdaVolta = idaVolta;
            PassagemIda.ID = passagemIda;
            ResumoViagens = resumoViagens;
        }

        public Viagens()
        {
            CodigoReserva = GerarCodigoReserva();
        }

    }
}