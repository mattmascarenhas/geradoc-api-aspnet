using FluentValidator;
using Geradoc.Shared.Interfaces.Comando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geradoc.Domain.Comandos.Endereco {
    public class AdicionarEnderecoComando : Notifiable, IComando {
        public string Rua { get; set; } 
        public string Numero { get; set; } 
        public string Complemento { get; set; } 
        public string Bairro { get; set; } 
        public string Cidade { get; set; } 
        public string Estado { get; set; } 
        public string Cep { get; set; }

        bool IComando.Validar() {
            return IsValid;
        }
    }
}
