using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Services
{
    public interface IBaseDomainService<T> where T : class
    {
        void Create(T obj);
        void Delete(T obj);
        void Update(T obj);
        List<T> GetAll();
        T GetById(int id);
    }
}
