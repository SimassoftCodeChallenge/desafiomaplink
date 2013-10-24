using System.Collections;
using br.com.maplink.calculorota.data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using br.com.maplink.calculorota.business.entities;
using System.Collections.Generic;
using br.com.maplink.calculorota.common.integration.Route;

namespace br.com.maplink.calculorota.unittests
{


    /// <summary>
    ///This is a test class for CalculoRotaDataTest and is intended
    ///to contain all CalculoRotaDataTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CalculoRotaDataTest
    {
        private static CalculoRotaData _target;

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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            _target = new CalculoRotaData();
        }
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
        ///A test for ObterCoordenadas
        ///</summary>
        [TestMethod()]
        public void ObterCoordenadasTest()
        {
            IList<EnderecoEntity> l = new List<EnderecoEntity>();
            l.Add(new EnderecoEntity{Bairro = "Mirandopolis", Cidade = "São Paulo", Estado = "SP", Numero = "14", Rua = "Orissanga", Cep = "04052030"});

            var r = _target.ObterCoordenadas(l);

            Assert.IsTrue(r.Count > 0);
        }

        /// <summary>
        ///A test for CalcularRota
        ///</summary>
        [TestMethod()]
        public void CalcularRotaTest()
        {
            IList<EnderecoEntity> l = new List<EnderecoEntity>();
            l.Add(new EnderecoEntity { Bairro = "Mirandopolis", Cidade = "São Paulo", Estado = "SP", Numero = "14", Rua = "Orissanga", Cep = "04052030" });
            l.Add(new EnderecoEntity { Bairro = "Gloria", Cidade = "Vila Velha", Estado = "ES", Numero = "613", Rua = "Mestre Gomes", Cep = "29122100" });

            var ps = _target.ObterCoordenadas(l);

            var r = _target.CalcularRota(ps, TiposCalculoRota.EvitandoTransito);

            Assert.IsTrue(r.DistanciaTotalRota > 0);
        }
    }
}
