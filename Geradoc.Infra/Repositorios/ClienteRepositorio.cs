using Dapper;
using Geradoc.Domain.Entidades;
using Geradoc.Domain.Interfaces;
using Geradoc.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geradoc.Infra.Repositorios {
    public class ClienteRepositorio : IClienteRespositorio {
        private readonly GeradocData _conexaoBancoDeDados;
        public ClienteRepositorio(GeradocData conexaoBancoDeDados){
            _conexaoBancoDeDados = conexaoBancoDeDados;
        }
        //o cpf ou cnpj será checado se ja existe ou se é válido através de uma procedure
        public bool ChecarDocumento(string documento) {
            return _conexaoBancoDeDados
                    .Conexao
                    .Query<bool>("spChecarDocumento", new {
                        Documento = documento
                    }, commandType: System.Data.CommandType.StoredProcedure)
                    .FirstOrDefault();
        }
        //email será checado através de uma procedure
        public bool ChecarEmail(string email) {
            return _conexaoBancoDeDados
                     .Conexao
                     .Query<bool>("spChecarEmail", new {
                         Email = email
                     }, commandType: System.Data.CommandType.StoredProcedure)
                     .FirstOrDefault();
        }

        public IEnumerable<ClienteExibirLista> Get() {
            throw new NotImplementedException();
        }

        public ClienteExibirLista Get(Guid id) {
            throw new NotImplementedException();
        }

        public IEnumerable<BlocosClientes> GetBlocos() {
            throw new NotImplementedException();
        }

        public ClienteQuantidadeBlocos ObterQuantidadeBlocosCliente(string cpf) {
            throw new NotImplementedException();
        }

        public void Salvar(Cliente cliente) {
            throw new NotImplementedException();
        }
    }
}
