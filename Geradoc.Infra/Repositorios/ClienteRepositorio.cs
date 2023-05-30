using Dapper;
using Geradoc.Domain.Entidades;
using Geradoc.Domain.Interfaces;
using Geradoc.Domain.Queries;


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
        //query que retorna uma lista de clientes personalizada para o front
        public IEnumerable<ClienteExibirLista> Get() {
            return _conexaoBancoDeDados
                    .Conexao
                    .Query<ClienteExibirLista>("SELECT c.[Id], CONCAT(c.[PrimeiroNome], ' ', c.[Sobrenome]) AS [Nome]," +
                    " c.[Email], c.[CpfCnpj], c.[Telefone], CONCAT(e.[Cidade], '-', e.[Estado]) AS [Cidade_Estado] FROM [Clientes] c INNER JOIN [Enderecos]" +
                    " e ON c.[Id] = e.[ClienteId];");
            //    return _conexaoBancoDeDados
            //            .Conexao
            //            .Query<ClienteExibirLista>("SELECT [Id], CONCAT([PrimeiroNome], ' ', [Sobrenome]) AS [Nome], [Email], [CpfCnpj], [Telefone] FROM [Clientes]");
        }
        //query que retorna tudo referente a cliente
        public IEnumerable<ClientesSemEndereco> GetAll() {
            return _conexaoBancoDeDados
                    .Conexao
                    .Query<ClientesSemEndereco>("SELECT * FROM [Clientes]");
        }
        //query retorna um cliente com base no id passado
        public ClienteExibirLista Get(Guid id) {
            return _conexaoBancoDeDados
                    .Conexao
                    .Query<ClienteExibirLista>("SELECT c.[Id], CONCAT(c.[PrimeiroNome], ' ', c.[Sobrenome]) AS [Nome], " +
                    "c.[Email], c.[CpfCnpj], c.[Telefone], e.[Cidade], e.[Estado] FROM [Clientes] c " +
                    "INNER JOIN [Enderecos] e ON c.[Id] = e.[ClienteId] WHERE c.[Id] = @id  ", new {
                        id = id
                    })
                    .FirstOrDefault();
        }
        //query que retorna uma lista de blocos com os respectivos clientes
        public IEnumerable<BlocosClientes> GetBlocos() {
            return _conexaoBancoDeDados
                    .Conexao
                    .Query<BlocosClientes>("SELECT b.[Id] AS [BlocoId], CONCAT(c.[PrimeiroNome], ' ', c.[Sobrenome]) AS [Cliente], " +
                    "b.[Titulo] AS [TituloBloco] FROM [ClientesBlocos] cb INNER JOIN [Clientes] c ON cb.[ClienteId] = c.[Id] " +
                    "INNER JOIN [Blocos] b ON cb.[BlocoId] = b.[Id];");
        }
        //procedure que retorna os dados basicos de um cliente e a quantiedade de blocos
        public ClienteQuantidadeBlocos ObterQuantidadeBlocosCliente(string cpf) {
            return _conexaoBancoDeDados
                    .Conexao
                    .Query<ClienteQuantidadeBlocos>("spClienteBlocosQuantidade", new {
                        Cpf = cpf
                    }, commandType: System.Data.CommandType.StoredProcedure)
                    .FirstOrDefault();
        }
        //cria um novo cliente e um novo endereco
        public void Salvar(Cliente cliente) {
            _conexaoBancoDeDados.Conexao.Execute("spNovoCliente", new {
                Id = cliente.Id,
                PrimeiroNome = cliente.Nome.PrimeiroNome,
                Sobrenome = cliente.Nome.Sobrenome,
                CpfCnpj = cliente.CpfCnpj.ToString(),
                Rg = cliente.Rg.ToString(),
                Nacionalidade = cliente.Nacionalidade,
                EstadoCivil = cliente.EstadoCivil,
                OrgaoEmissor = cliente.OrgaoEmissor,
                Profissao = cliente.Profissao,
                Email = cliente.Email.ToString(),
                Telefone = cliente.Telefone
            }, commandType: System.Data.CommandType.StoredProcedure);

            if (cliente.Endereco != null) {
                _conexaoBancoDeDados.Conexao.Execute("spNovoEndereco", new {
                    Id = cliente.Endereco.Id,
                    ClienteId = cliente.Id,
                    Numero = cliente.Endereco.Numero,
                    Rua = cliente.Endereco.Rua,
                    Complemento = cliente.Endereco.Complemento,
                    Bairro = cliente.Endereco.Bairro,
                    Cidade = cliente.Endereco.Cidade,
                    Estado = cliente.Endereco.Estado,
                    Cep = cliente.Endereco.Cep
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
