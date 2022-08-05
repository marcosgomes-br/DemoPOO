using System;
using System.Collections.Generic;

namespace DemoPOO.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Salvar(T item);
        List<T> Listar();
        T Obter(Guid id);
        void Remover(T item);
    }
}