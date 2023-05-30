using FluentValidator;
using FluentValidator.Validation;
using Geradoc.Shared.Interfaces.Comando;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Geradoc.Domain.Comandos.Cliente {
    public class AdicionarClienteComando : Notifiable, IComando {
        //FailFastValidation -> fazer todas as verificacoes no banco com o minimo de consultas possiveis
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public int Rg { get; set; }
        public string OrgaoEmissor { get; set; }
        public string Nacionalidade { get; set; }
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
        public string Telefone { get; set; }

        public bool Validar() {
            AddNotifications(new ValidationContract()
                    .Requires()
                    .HasMinLen(PrimeiroNome, 3, "PrimeiroNome", "O Nome deve conter pelo menos 3 caracteres")
                    .HasMaxLen(PrimeiroNome, 40, "PrimeiroNome", "O Nome deve conter no máximo 40 caracteres")
                    .HasMinLen(Sobrenome, 3, "Sobrenome", "O Sobrenome deve conter pelo menos 3 caracteres")
                    .HasMaxLen(Sobrenome, 150, "Sobrenome", "O Sobrenome deve conter no máximo 150 caracteres")
                    .IsEmail(Email, "Email", "Email inválido")
                    .HasMaxLen(Email, 160, "Email", "O Email deve conter no máximo 160 caracteres")
                    .HasLen(CpfCnpj, 18, "CpfCnpj", "CPF/CNPJ inválido")
                    .HasLen(Rg.ToString(), 13, "CpfCnpj", "CPF/CNPJ inválido")
                    );
            return IsValid;
        }
    }
}
