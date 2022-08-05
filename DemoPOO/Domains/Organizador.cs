using System;
using DemoPOO.Classes;

namespace DemoPOO.Domains
{
    public class Organizador : Pessoa
    {
        public Organizador(string nome, string documento)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrEmpty(nome))
                throw new Exception("Nome é um campo obrigatório");
            if (string.IsNullOrEmpty(documento))
                throw new Exception("Documento é um campo obrigatório");
            
            Nome = nome;
            Documento = documento;
        }

        public bool EfetouPagamento { get; private set; } = false;

        public void EfetuarPagamento()
        {
            EfetouPagamento = true;
        }
    }
}