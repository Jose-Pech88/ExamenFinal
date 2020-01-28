using System;
using AliExpress.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class MedioTransporteTrenUTest
    {
        [TestMethod]
        public void ObtenerCostoEnvio_ParametroDistancia100MargenUtilidad15_ValorCorrecto575()
        {
            //Arrange
            decimal dDistancia = 100;
            decimal dMargenUtilidad = 15;
            var SUT = new MedioTransporteTren();

            //Act
            var dCostoEnvio = SUT.ObtenerCostoEnvio(dDistancia, dMargenUtilidad);

            //Assert
            Assert.AreEqual(dCostoEnvio, 575);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_ParametroDistancia0MargenUtilidad0_ValorCorrecto0()
        {
            //Arrange
            decimal dDistancia = 0;
            decimal dMargenUtilidad = 0;
            var SUT = new MedioTransporteTren();

            //Act
            var dCostoEnvio = SUT.ObtenerCostoEnvio(dDistancia, dMargenUtilidad);

            //Assert
            Assert.AreEqual(dCostoEnvio, 0);
        }
        [TestMethod]
        public void dCostoKilometroPesos_ObtenerValorPropiedad_ValorCorrecto5()
        {
            //Arrange
            var SUT = new MedioTransporteTren();

            //Act
            var dCostoKilometroPesos = SUT.dCostoKilometroPesos;

            //Assert
            Assert.AreEqual(dCostoKilometroPesos, 5);
        }

        [TestMethod]
        public void dVelocidadEntrega_ObtenerValorPropiedad_ValorCorrecto80()
        {
            //Arrange
            var SUT = new MedioTransporteTren();

            //Act
            var dVelocidadEntrega = SUT.dVelocidadEntrega;

            //Assert
            Assert.AreEqual(dVelocidadEntrega, 80);
        }

        [TestMethod]
        public void cMedioTransporte_ObtenerValorPropiedad_ValorCorrectoTren()
        {
            //Arrange
            var SUT = new MedioTransporteTren();

            //Act
            var cMedioTransporte = SUT.cMedioTransporte;

            //cMedioTransporte
            Assert.AreEqual(cMedioTransporte, "Tren");
        }
    }
}
