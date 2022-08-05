using System;
using System.Collections.Generic;
using System.Linq;
using DemoPOO.Domains;
using DemoPOO.Interfaces.Repositories;

namespace DemoPOO.Repositories
{
    public class EventoRepository : IBaseRepository<Evento>
    {
        private static List<Evento> _eventos = new List<Evento>();
        public void Salvar(Evento item)
        {
            _eventos.Add(item);
        }

        public List<Evento> Listar()
        {
            return _eventos;
        }

        public Evento Obter(Guid id)
        {
            return _eventos.FirstOrDefault(x => x.Id == id);
        }

        public void Remover(Evento item)
        {
            _eventos.Remove(item);
        }

        public void AdicionarConvidado(Evento evento, Convidado convidado)
        {
            _eventos.Where(x => x.Id == evento.Id)
                    .FirstOrDefault()
                    .AdicionarConvidado(convidado);
        }
    }
}