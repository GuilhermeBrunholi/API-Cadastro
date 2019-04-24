
using System.Linq;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Cadastro.Repositorio;

namespace Cadastro.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _contexto;

        public PessoaController(IPessoaRepository contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return NotFound();
            }
            else
            {
                _contexto.Add(pessoa);
                
                return CreatedAtRoute("GetPessoa", new { id = pessoa.Id }, pessoa);
            }
        }

        [HttpGet]
        public IEnumerable<Pessoa> GetAll()
        {
            return _contexto.GetAll();
        }

        [HttpGet("{id}", Name = "GetPessoa")]
        public IActionResult Get(int id)
        {
            var pessoa = _contexto.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(pessoa);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            if (pessoa == null || pessoa.Id != id)
            {
                return BadRequest();
            }
            else
            {
                var _pessoa = _contexto.Find(id);
                if (_pessoa == null)
                {
                    return NotFound();
                }
                else
                {
                    _pessoa.Nome = pessoa.Nome;
                    _pessoa.Sobre = pessoa.Sobre;
                    _pessoa.Telefone = pessoa.Telefone;
                    _pessoa.Celular = pessoa.Celular;
                    _pessoa.Email = pessoa.Email;
                    _pessoa.Documento = pessoa.Documento;

                    _contexto.Update(_pessoa);
                    return new NoContentResult();
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pessoa = _contexto.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            else
            {
                _contexto.Remove(id);
                return new NoContentResult();
            }
        }
    }
}