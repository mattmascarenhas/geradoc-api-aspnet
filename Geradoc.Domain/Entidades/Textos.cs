using Geradoc.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geradoc.Domain.Entidades {
    public class Textos: Entidade {
        public Textos(string titulo, string texto) {
            this.Titulo = titulo;
            this.Texto = texto;
            DataDeCriacao = DateTime.Now;
        }
        public string Titulo { get; private set; }
        public string Texto { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDeAtualizacao { get; private set; }

    }
}
