using System.Globalization;
using br.com.maplink.calculorota.business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using br.com.maplink.calculorota.business.dtos;
using System.Collections.Generic;
using br.com.maplink.calculorota.data;

namespace br.com.maplink.calculorota.unittests
{


    /// <summary>
    ///This is a test class for CalculoRotaBusinessTest and is intended
    ///to contain all CalculoRotaBusinessTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CalculoRotaBusinessTest
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
        ///A test for CalcularRota
        ///</summary>
        [TestMethod()]
        public void CalcularRotaTest()
        {
            var c = new CalculoRotaBusiness();
            List<DadosEntradaV1> d = new List<DadosEntradaV1>();

            d.Add(new DadosEntradaV1 { Cidade = "São Paulo", Estado = "SP", Rua = "Orissanga", Numero = "14" });
            d.Add(new DadosEntradaV1 { Cidade = "Vila Velha", Estado = "ES", Rua = "Mestre Gomes", Numero = "613" });

            var result = c.CalcularRota(d, TiposCalculoRota.MaisRapida);

            Assert.IsTrue(result.DistanciaTotalRota > 0);
        }

        [TestMethod()]
        public void TesteConversaoData()
        {
            string p1 = "PT11H40M";
            string p2 = "PT1H7M";

            TimeSpan t = TimeSpan.ParseExact(p2, @"\P\T%h\H%m\M", CultureInfo.InvariantCulture);

            Assert.IsTrue(t.TotalMinutes > 0);
        }
    }
}
