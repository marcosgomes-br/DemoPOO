using System;
using System.Collections.Generic;
using DemoPOO.Classes;

namespace DemoPOO.Domains
{
    public class Convidado : Pessoa
    {
        public Convidado(string nome, string documento)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
        }

        public bool EfetuouCheckin { get; private set; } = false;

        public void EfetuarCheckin()
        {
            EfetuouCheckin = true;
        }
    }
}