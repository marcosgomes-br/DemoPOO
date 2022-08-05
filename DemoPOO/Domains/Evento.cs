using System;
using System.Collections.Generic;

namespace DemoPOO.Domains
{
    public class Evento
    {
        public Evento(Guid id, DateTime data, string nome, Organizador organizador, int vagas, Local local)
        {
            if (vagas < 1)
                throw new Exception("Vagas precisa ser maior que 1");
            if (data < DateTime.Now)
                throw new Exception("A data do evento não pode ser no passsado");
            Id = id;
            Data = data;
            Nome = nome;
            Organizador = organizador;
            Vagas = vagas;
            Local = local;
        }
        public Guid Id { get; private set; }
        public DateTime Data { get; private  set; }
        public string Nome { get; private set; }
        public Organizador Organizador { get; private set; }
        public int Vagas { get; private set; }
        public List<Convidado> Convidados { get; private set; } = new List<Convidado>();
        public Local Local { get; private set; }

        public void AdicionarConvidado(Convidado convidado)
        {
            Convidados.Add(convidado);
        }
    }
}