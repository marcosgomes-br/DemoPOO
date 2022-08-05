using System;

namespace DemoPOO.Classes
{
    public abstract class Pessoa
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Documento { get; protected set; }
    }
}