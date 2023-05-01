using System;

namespace SerraLinhasAereas.Domain
{
    public class Cliente
    {
        public int Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto { get; set; }
        public Endereco Endereco { get; set; }

        public Cliente(int cpf, string nome, string sobrenome, string nomeCompleto, Endereco endereco)
        {
            Cpf = cpf;
            Nome = nome;
            Sobrenome = sobrenome;
            NomeCompleto = nomeCompleto;
            Endereco = endereco;
        }
        
        public Cliente()
        {
        }
    }
}
