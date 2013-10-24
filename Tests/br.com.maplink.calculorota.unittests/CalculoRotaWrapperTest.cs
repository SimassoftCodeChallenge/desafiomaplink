using br.com.maplink.calculorota.common.integration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using br.com.maplink.calculorota.common.integration.CalculoRota;
using System.Collections.Generic;

namespace br.com.maplink.calculorota.unittests
{
    /// <summary>
    ///This is a test class for CalculoRotaWrapperTest and is intended
    ///to contain all CalculoRotaWrapperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CalculoRotaWrapperTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CalcularRotaEvitandoTransito
        ///</summary>
        [TestMethod()]
        public void CalcularRotaEvitandoTransitoTest()
        {
            CalculoRotaWrapper target = new CalculoRotaWrapper(); // TODO: Initialize to an appropriate value
            var d = new List<DadosEntrada>();
            d.Add(new DadosEntrada { Cidade = "Vila Velha", Estado = "ES", Numero = "613", Rua = "Mestre Gomes", Cep = "29122100" });
            d.Add(new DadosEntrada { Cidade = "São Paulo", Estado = "SP", Numero = "14", Rua = "Orissanga", Cep = "04052030" });

            var result = target.CalcularRotaEvitandoTransito(d);
            Assert.IsTrue(result.DistanciaTotalRota > 0);
        }

        /// <summary>
        ///A test for CalcularRotaMaisRapida
        ///</summary>
        [TestMethod()]
        public void CalcularRotaMaisRapidaTest()
        {
            CalculoRotaWrapper target = new CalculoRotaWrapper(); // TODO: Initialize to an appropriate value
            var d = new List<DadosEntrada>();
            d.Add(new DadosEntrada { Cidade = "Vila Velha", Estado = "ES", Numero = "613", Rua = "Mestre Gomes", Cep = "29122100" });
            d.Add(new DadosEntrada { Cidade = "São Paulo", Estado = "SP", Numero = "14", Rua = "Orissanga", Cep = "04052030" });

            var result = target.CalcularRotaMaisRapida(d);
            Assert.IsTrue(result.DistanciaTotalRota > 0);
        }
    }
}
