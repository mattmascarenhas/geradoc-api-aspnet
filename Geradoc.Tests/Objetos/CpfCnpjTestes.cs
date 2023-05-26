using Geradoc.Domain.Objetos;


namespace Geradoc.Tests.Objetos {
    [TestClass]
    public class CpfCnpjTestes {
        private CpfCnpj cpfInvalido;
        private CpfCnpj cnpjInvalido;
        private CpfCnpj cpfValido;
        private CpfCnpj cnpjValido;

        public CpfCnpjTestes() {
            cpfInvalido = new CpfCnpj("099.222.333-466");
            cnpjInvalido = new CpfCnpj("12.345.678/0001-0");
            cpfValido = new CpfCnpj("065.917.185-67");
            cnpjValido = new CpfCnpj("76.864.178/0001-42");
        }

        [TestMethod]
        public void CpfInvalidoTemQueRetornarFalse() {
            //(o que esperar do teste, o que esta sendo testado)
            Assert.AreEqual(false, cpfInvalido.IsValid);
            Assert.AreEqual(1, cpfInvalido.Notifications.Count);
        }

        [TestMethod]
        public void CnpjInvalidoTemQueRetornarFalse() {
            Assert.AreEqual(false, cnpjInvalido.IsValid);
            Assert.AreEqual(1, cnpjInvalido.Notifications.Count);
        }

        [TestMethod]
        public void CpfValidoTemQueRetornarTrue() {
            Assert.AreEqual(true, cpfValido.IsValid);
            Assert.AreEqual(0, cpfValido.Notifications.Count);
        }

        [TestMethod]
        public void CnpjValidoTemQueRetornarTrue() {
            Assert.AreEqual(true, cnpjValido.IsValid);
            Assert.AreEqual(0, cnpjValido.Notifications.Count);
        }
    }
}
