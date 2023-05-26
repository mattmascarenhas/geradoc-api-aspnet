using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Geradoc.Domain.Objetos {
    public class Rg: Notifiable {
        public Rg(int rg){
            NumeroRg = rg;

            AddNotifications(new ValidationContract()
                .Requires()
                 .HasMinLen(NumeroRg.ToString(), 6, "Rg", "O Rg deve conter pelo menos 6 caracteres")
                 .HasMaxLen(NumeroRg.ToString(), 13, "Rg", "O Rg deve conter no máximo 13 caracteres"));
        }

        public int NumeroRg { get; private set; }
    }
}
