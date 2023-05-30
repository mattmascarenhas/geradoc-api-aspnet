using Geradoc.Domain.Objetos;
using Geradoc.Shared.Interfaces.Comando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geradoc.Domain.Comandos.Cliente {
    public class ResultadoClienteInserido {
        public ResultadoClienteInserido(){
            
        }
        public ResultadoClienteInserido(Guid id, string nome, string email) {
            Id = id;
            Nome = nome;
            Email = email;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
