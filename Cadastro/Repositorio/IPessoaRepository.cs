using System.Collections.Generic;
using Dominio.Entidades;

namespace Cadastro.Repositorio
{
    public interface IPessoaRepository
    {
        void Add(Pessoa pessoa);
        IEnumerable<Pessoa> GetAll();
        Pessoa Find(long id);
        void Remove(long id);
        void Update(Pessoa pessoa);
    }
}