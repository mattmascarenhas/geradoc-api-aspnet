using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geradoc.Domain.Queries {
    public class ClienteExibirLista {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cidade_Estado { get; set; } 
    }
}
