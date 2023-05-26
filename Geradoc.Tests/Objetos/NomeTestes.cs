using Geradoc.Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geradoc.Tests.Objetos {
    [TestClass]
    public class NomeTestes {
        private Nome nomeValido;
        private Nome nomeInvalido1;
        private Nome nomeInvalido2;

        public NomeTestes() {
            nomeValido = new Nome("Matheus", "Mascarenhas");
            nomeInvalido1 = new Nome("AB","CC"); //2 erros 
            nomeInvalido2 = new Nome("Matheus", ""); // 1 erro
        }

        [TestMethod]
        public void NomeInvalidoRetotnaNotificacao() {
            Assert.AreEqual(false, nomeInvalido1.IsValid);
            Assert.AreEqual(2, nomeInvalido1.Notifications.Count);

            Assert.AreEqual(false, nomeInvalido2.IsValid);
            Assert.AreEqual(1, nomeInvalido2.Notifications.Count);
        }

        [TestMethod]
        public void NomeValidoNaoRetornaNotificacao() {
            Assert.AreEqual(true, nomeValido.IsValid);
            Assert.AreEqual(0, nomeValido.Notifications.Count);
        }
    }
}
