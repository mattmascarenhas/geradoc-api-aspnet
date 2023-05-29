using Geradoc.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geradoc.Domain.Entidades {
    public class Bloco: Entidade {
        public Bloco(string titulo) {
            this.Titulo = titulo;
            this.DataDeCriacao = DateTime.Now;
            
        }
        public string Titulo { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDeAtualizacao { get; private set; }

        public override string ToString() {
            return Titulo;
        }
    }
}
