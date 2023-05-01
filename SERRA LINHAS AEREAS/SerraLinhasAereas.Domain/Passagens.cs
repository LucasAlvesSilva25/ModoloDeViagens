using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain
{
    public class Passagens
    {
        public int ID { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public float Valor { get; set; }
        public DateTime DataOrigem { get; set; }
        public DateTime DataDestino { get; set; }

        public Passagens()
        {
        }

        public Passagens(string origem, string destino, float valor, DateTime dataOrigem, DateTime dataDestino)
        {
            Origem = origem;
            Destino = destino;
            Valor = valor;
            DataOrigem = dataOrigem;
            DataDestino = dataDestino;
        }

        public Passagens(int iD, string origem, string destino, float valor, DateTime dataOrigem, DateTime dataDestino)
        {
            ID = iD;
            Origem = origem;
            Destino = destino;
            Valor = valor;
            DataOrigem = dataOrigem;
            DataDestino = dataDestino;
        }
    }
}
