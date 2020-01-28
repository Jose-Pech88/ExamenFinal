using System;
using AliExpress.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class MedioTransporteAvionUTest
    {
        [TestMethod]
        public void ObtenerCostoEnvio_ParametroDistancia100MargenUtilidad15_ValorCorrecto1150()
        {
            //Arrange
            decimal dDistancia = 100;
            decimal dMargenUtilidad = 15;
            var SUT = new MedioTransporteAvion();

            //Act
            var dCostoEnvio = SUT.ObtenerCostoEnvio(dDistancia, dMargenUtilidad);

            //Assert
            Assert.AreEqual(dCostoEnvio, 1150);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_ParametroDistancia0MargenUtilidad0_ValorCorrecto0()
        {
            //Arrange
            decimal dDistancia = 0;
            decimal dMargenUtilidad = 0;
            var SUT = new MedioTransporteAvion();

            //Act
            var dCostoEnvio = SUT.ObtenerCostoEnvio(dDistancia, dMargenUtilidad);

            //Assert
            Assert.AreEqual(dCostoEnvio, 0);
        }

        [TestMethod]
        public void dCostoKilometroPesos_ObtenerValorPropiedad_ValorCorrecto10()
        {
            //Arrange
            var SUT = new MedioTransporteAvion();

            //Act
            var dCostoKilometroPesos = SUT.dCostoKilometroPesos;

            //Assert
            Assert.AreEqual(dCostoKilometroPesos, 10);
        }

        [TestMethod]
        public void dVelocidadEntrega_ObtenerValorPropiedad_ValorCorrecto600()
        {
            //Arrange
            var SUT = new MedioTransporteAvion();

            //Act
            var dVelocidadEntrega = SUT.dVelocidadEntrega;

            //Assert
            Assert.AreEqual(dVelocidadEntrega, 600);
        }

        [TestMethod]
        public void cMedioTransporte_ObtenerValorPropiedad_ValorCorrectoAvion()
        {
            //Arrange
            var SUT = new MedioTransporteAvion();

            //Act
            var cMedioTransporte = SUT.cMedioTransporte;

            //cMedioTransporte
            Assert.AreEqual(cMedioTransporte, "Avión");
        }
    }
}
