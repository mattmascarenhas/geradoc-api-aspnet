using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geradoc.Domain.Objetos {
    public class Nome: Notifiable {
        public Nome(string primeiroNome, string sobrenome){
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;

            //teste de validacao do tamanho do nome
            AddNotifications(new ValidationContract()
                 .Requires()
                 .HasMinLen(PrimeiroNome, 3, "PrimeiroNome", "O Nome deve conter pelo menos 3 caracteres")
                 .HasMaxLen(PrimeiroNome, 40, "PrimeiroNome", "O Nome deve conter no máximo 40 caracteres")
                 .HasMinLen(Sobrenome, 3, "Sobrenome", "O Sobrenome deve conter pelo menos 3 caracteres")
                 .HasMaxLen(Sobrenome, 150, "Sobrenome", "O Sobrenome deve conter no máximo 150 caracteres"));
        }

        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }

        public override string ToString() {
            return $"{PrimeiroNome} + {Sobrenome}";
        }
    }
}

