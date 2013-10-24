using br.com.maplink.calculorota.common.integration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using br.com.maplink.calculorota.common.integration.Route;

namespace br.com.maplink.calculorota.unittests
{


    /// <summary>
    ///This is a test class for RouteWrapperTest and is intended
    ///to contain all RouteWrapperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RouteWrapperTest
    {
        private static RouteWrapper _route;

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
            _route = new RouteWrapper(); // TODO: Initialize to an appropriate value
        }

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
        ///A test for GetRoute
        ///</summary>
        [TestMethod()]
        public void GetRouteTest()
        {
            _route = new RouteWrapper();
            AddressFinderWrapper af = new AddressFinderWrapper();

            var p0 = af.GetXY("Mestre Gomes", "613", "Vila Velha", "ES", "Gloria", "29122100");
            var p1 = af.GetXY("Orissanga", "14", "São Paulo", "SP", "Mirandopolis", "04052030");

            RouteInfo ri = _route.GetRoute(RouteWrapper.ConvertToRoutePoint(p0), 
                                           RouteWrapper.ConvertToRoutePoint(p1), 
                                           RouteWrapper.TipoRota.PadraoMaisCurta);

            Assert.IsTrue(ri.routeTotals.totalDistance > 0);
        }
    }
}
