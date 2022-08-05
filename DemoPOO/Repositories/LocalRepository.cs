using System;
using System.Collections.Generic;
using System.Linq;
using DemoPOO.Domains;
using DemoPOO.Interfaces.Repositories;

namespace DemoPOO.Repositories
{
    public class LocalRepository : IBaseRepository<Local>
    {
        private static List<Local> _locais = new List<Local>();
        public void Salvar(Local item)
        {
            _locais.Add(item);
        }

        public List<Local> Listar()
        {
            return _locais;
        }

        public Local Obter(Guid id)
        {
            return _locais.FirstOrDefault(x => x.Id == id);
        }

        public void Remover(Local item)
        {
            _locais.Remove(item);
        }
    }
}