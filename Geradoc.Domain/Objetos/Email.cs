using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geradoc.Domain.Objetos {
    public class Email: Notifiable {
        public Email(string email) {
            EnderecoEmail = email;

            //teste de validacao se é email
            AddNotifications(new ValidationContract()
                 .Requires()
                 .IsEmail(EnderecoEmail, "Email", "Email inválido")
                 .HasMaxLen(EnderecoEmail, 160, "Email", "O Email deve conter no máximo 160 caracteres"));
        }

        public string EnderecoEmail { get; private set; }

        public override string ToString() {
            return EnderecoEmail;
        }
    }
}
