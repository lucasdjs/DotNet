using Aula_DEvinhouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula_DEvinhouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private static int _idIndice = 1;
       private static List<Clientes> _clientes = new();

        [HttpGet]
        public List<Clientes> Get([FromQuery] int? idade)
        {
            if (idade.HasValue) { 

                return _clientes.Where(c => c.Idade == idade).ToList();
            
            }
           return _clientes;
        }

        [HttpPost]
        public Clientes Post([FromBody] Clientes body) {
            body.Id = _idIndice;
            _idIndice++;
            _clientes.Add(body);
            return body;
            
        }
        
        [HttpPut("{idCliente}")]
        public Clientes Put([FromBody] Clientes body, [FromRoute] int idCliente) 
        {
           
                var cliente = _clientes.FirstOrDefault(c => c.Id == idCliente);
                cliente.Nome = body.Nome;
                cliente.Idade = body.Idade;

                return cliente;
     
        }

        [HttpDelete("{idCliente}")]
        public List<Clientes> Delete([FromRoute] int idCliente) { 
        var cliente = _clientes.FirstOrDefault(c => c.Id == idCliente);
            _clientes.Remove(cliente);

            return _clientes;
        }

        [HttpGet("{idCliente}")]

        public Clientes GetById([FromRoute] int idCliente)
        {
            return _clientes.FirstOrDefault(c => c.Id == idCliente);

        }
        
    }
}