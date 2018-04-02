using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using scaweb.Daos;

namespace scaweb.Tests.Teste {
    [TestClass]
    public class InstituicaoDAOTeste {
        [TestMethod]
        public void BuscarTodos() {

            InstituicaoDAO.BuscarTodos();
        }
    }
}
