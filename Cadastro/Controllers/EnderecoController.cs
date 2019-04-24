using Dados;
using System.Linq;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cadastro.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EnderecoController : Controller
    {
        public readonly ApplicationDbContext _contexto;
        public EnderecoController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Endereco endereco)
        {
            if (endereco == null)
            {
                return BadRequest();
            }
            else
            {
                _contexto.Enderecos.Add(endereco);
                _contexto.SaveChanges();
                return CreatedAtRoute("GetEndereco", new { id = endereco.Id }, endereco);
            }
        }

        [HttpGet]
        public IEnumerable<Endereco> GetAll()
        {
            return _contexto.Enderecos.ToList();
        }

        [HttpGet("{id}", Name = "GetEndereco")]
        public IActionResult Get(int id)
        {
            var endereco = _contexto.Enderecos.First(e => e.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(endereco);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Endereco endereco)
        {
            if (endereco == null || endereco.Id != id)
            {
                return BadRequest();
            }
            else
            {
                var _endereco = _contexto.Enderecos.First(e => e.Id == id);
                if (_endereco == null)
                {
                    return NotFound();
                }
                else
                {
                    _endereco.Rua = endereco.Rua;
                    _endereco.Numero = endereco.Numero;
                    _endereco.Bairro = endereco.Bairro;
                    _endereco.Estado = endereco.Estado;
                    _endereco.Pais = endereco.Pais;

                    _contexto.Enderecos.Update(_endereco);
                    _contexto.SaveChanges();
                    return new NoContentResult();
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var endereco = _contexto.Enderecos.First(e => e.Id == id);

            if(endereco == null)
            {
                return NotFound();
            }

            _contexto.Enderecos.Remove(endereco);
            _contexto.SaveChanges();
            return new NoContentResult();
        }
    }
}