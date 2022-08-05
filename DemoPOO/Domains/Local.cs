using System;

namespace DemoPOO.Domains
{
    public class Local
    {
        public Local(Guid id, string nome, string cidade, string estado, string logradouro)
        {
            Id = id;
            Nome = nome;
            Cidade = cidade;
            Estado = estado;
            Logradouro = logradouro;
        }
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Logradouro { get; private set; }
    }
}