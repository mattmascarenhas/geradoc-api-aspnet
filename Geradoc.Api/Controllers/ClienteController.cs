using Geradoc.Domain.Comandos.Cliente;
using Geradoc.Domain.Handlers;
using Geradoc.Domain.Interfaces;
using Geradoc.Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Geradoc.Api.Controllers {
    public class ClienteController : Controller {
        private readonly IClienteRespositorio _repositorio;
        private readonly ClienteHandler _handler;

        public ClienteController(IClienteRespositorio repositorio, ClienteHandler handler) {
            _repositorio = repositorio;
            _handler = handler;
        }

        //[HttpGet("/")]
        //public IActionResult Index() {
        //    return Ok("Hello WOrld");
        //}

        //listar os clientes
        [HttpGet("v1/clientes")]
        public IEnumerable<ClienteExibirLista> Get() {
            return _repositorio.Get();
        }
        [HttpGet("v1/clientesSemEndereco")]
        public IEnumerable<ClientesSemEndereco> GetAll() {
            return _repositorio.GetAll();
        }
        //inserir um cliente
        [HttpPost("v1/cliente")]
        public object Post([FromBody] AdicionarClienteComando comando) {
            var resultado = (ResultadoClienteInserido)_handler.Handle(comando);

            if (_handler.Invalid)
                return BadRequest(_handler.Notifications);

            return resultado;
        }
    }
}
