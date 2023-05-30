using FluentValidator;
using Geradoc.Domain.Comandos.Cliente;
using Geradoc.Domain.Entidades;
using Geradoc.Domain.Interfaces;
using Geradoc.Domain.Objetos;

namespace Geradoc.Domain.Handlers {
    public class ClienteHandler : Notifiable {
        private readonly IClienteRespositorio _repositorio;
        public ClienteHandler(IClienteRespositorio repositorio) {
            if (repositorio == null) {
                throw new ArgumentNullException(nameof(repositorio), "O repositório de clientes não pode ser nulo.");
                // ou adicione a lógica apropriada para lidar com a situação
            }
            _repositorio = repositorio;
        }
        public ResultadoClienteInserido Handle(AdicionarClienteComando comando) {
            //verificar cpf
            if (_repositorio.ChecarDocumento(comando.CpfCnpj))
                AddNotification("CpfCnpj", "Esse Cpf/Cnpj já está em uso!");
            if (_repositorio.ChecarEmail(comando.Email))
                AddNotification("Email", "Esse email já está em uso!");
            //Criando os VO(values objects)
            var nome = new Nome(comando.PrimeiroNome, comando.Sobrenome);
            var cpfCnpj = new CpfCnpj(comando.CpfCnpj);
            var rg = new Rg(comando.Rg);
            var email = new Email(comando.Email);
            //criando o cliente
            var cliente = new Cliente(nome, cpfCnpj, rg, email, comando.OrgaoEmissor, comando.Nacionalidade,
                comando.EstadoCivil, comando.Profissao, comando.Telefone);
            //validar os objetos de valor e a entidade
            AddNotifications(nome.Notifications);
            AddNotifications(cpfCnpj.Notifications);
            AddNotifications(rg.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(cliente.Notifications);

            if (Invalid)
                return null;
            //inserir o cliente no banco
            _repositorio.Salvar(cliente);

            return new ResultadoClienteInserido(cliente.Id, nome.ToString(), email.EnderecoEmail);
        }
    }
}
