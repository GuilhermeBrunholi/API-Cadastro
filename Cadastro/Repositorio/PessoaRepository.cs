using System.Collections.Generic;
using Dominio.Entidades;
using Dados;
using System.Linq;

namespace Cadastro.Repositorio
{
    public class PessoaRepository : IPessoaRepository
    {
        public readonly ApplicationDbContext _contexto;
        public PessoaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public void Add(Pessoa pessoa)
        {
            _contexto.Pessoas.Add(pessoa);
            _contexto.SaveChanges();
        }

        public Pessoa Find(long id)
        {
            return _contexto.Pessoas.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _contexto.Pessoas.ToList();
        }

        public void Remove(long id)
        {
            var pessoa = _contexto.Pessoas.First(p => p.Id == id);
            _contexto.Pessoas.Remove(pessoa);
            _contexto.SaveChanges();
        }

        public void Update(Pessoa pessoa)
        {
            _contexto.Pessoas.Update(pessoa);
            _contexto.SaveChanges();
        }
    }
}