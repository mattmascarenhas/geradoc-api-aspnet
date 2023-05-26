using FluentValidator.Validation;
using Geradoc.Domain.Objetos;
using Geradoc.Shared.Entidades;
using System.Net;

namespace Geradoc.Domain.Entidades {
    public class Cliente: Entidade {
        private readonly IList<Endereco> _enderecos;

        public Cliente(Nome nome, CpfCnpj cpfCnpj, Rg rg, Email email, string orgaoEmissor, string nacionalidade,
            string estadoCivil, string profissao, string telefone){
            Nome = nome;
            CpfCnpj = cpfCnpj;
            Rg = rg;
            Email = email;
            OrgaoEmissor = orgaoEmissor;
            Nacionalidade = nacionalidade;
            EstadoCivil = estadoCivil;
            Profissao = profissao;
            Telefone = telefone;
        }

        public Nome Nome { get; private set; }
        public CpfCnpj CpfCnpj { get; private set; }
        public Email Email { get; private set; }
        public Rg Rg { get; private set; }
        public string OrgaoEmissor { get; private set; }
        public string Nacionalidade { get; private set; }
        public string EstadoCivil { get; private set; }
        public string Profissao { get; private set; }
        public string Telefone { get; private set; }
        public IReadOnlyCollection<Endereco> Addresses => _enderecos.ToArray(); //apenas metodos de leitura


    }
}
