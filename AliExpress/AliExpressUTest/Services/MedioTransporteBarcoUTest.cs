using System;
using AliExpress.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class MedioTransporteBarcoUTest
    {
        [TestMethod]
        public void ObtenerCostoEnvio_ParametroDistancia100MargenUtilidad15_ValorCorrecto115()
        {
            //Arrange
            decimal dDistancia = 100;
            decimal dMargenUtilidad = 15;
            var SUT = new MedioTransporteBarco();

            //Act
            var dCostoEnvio = SUT.ObtenerCostoEnvio(dDistancia, dMargenUtilidad);

            //Assert
            Assert.AreEqual(dCostoEnvio, 115);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_ParametroDistancia0MargenUtilidad0_ValorCorrecto0()
        {
            //Arrange
            decimal dDistancia = 0;
            decimal dMargenUtilidad = 0;
            var SUT = new MedioTransporteBarco();

            //Act
            var dCostoEnvio = SUT.ObtenerCostoEnvio(dDistancia, dMargenUtilidad);

            //Assert
            Assert.AreEqual(dCostoEnvio, 0);
        }
        [TestMethod]
        public void dCostoKilometroPesos_ObtenerValorPropiedad_ValorCorrecto1()
        {
            //Arrange
            var SUT = new MedioTransporteBarco();

            //Act
            var dCostoKilometroPesos = SUT.dCostoKilometroPesos;

            //Assert
            Assert.AreEqual(dCostoKilometroPesos, 1);
        }

        [TestMethod]
        public void dVelocidadEntrega_ObtenerValorPropiedad_ValorCorrecto46()
        {
            //Arrange
            var SUT = new MedioTransporteBarco();

            //Act
            var dVelocidadEntrega = SUT.dVelocidadEntrega;

            //Assert
            Assert.AreEqual(dVelocidadEntrega, 46);
        }

        [TestMethod]
        public void cMedioTransporte_ObtenerValorPropiedad_ValorCorrectoBarco()
        {
            //Arrange
            var SUT = new MedioTransporteBarco();

            //Act
            var cMedioTransporte = SUT.cMedioTransporte;

            //cMedioTransporte
            Assert.AreEqual(cMedioTransporte, "Barco");
        }
    }
}
