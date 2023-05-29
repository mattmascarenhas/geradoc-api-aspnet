using Geradoc.Domain.Entidades;
using Geradoc.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geradoc.Domain.Interfaces {
    public interface IClienteRespositorio {
        bool ChecarDocumento(string documento);
        bool ChecarEmail(string email);
        void Salvar(Cliente cliente);
        ClienteQuantidadeBlocos ObterQuantidadeBlocosCliente(string cpf);

    }
}
