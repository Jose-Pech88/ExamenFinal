using System;
using AliExpress.Data.Entities;
using AliExpress.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpressUTest.Data.Entities
{
    [TestClass]
    public class RecuperadorConfiguracionTransportistaUTest
    {
        [TestMethod]
        public void ObtenerConfiguracionDHL_ValidarListaMedios_ListaMedioConItems()
        {
            //Arrange
            var SUT = new RecuperadorConfiguracionTransportista();

            //Act
            var lstMedios = SUT.ObtenerConfiguracionDHL();

            //Assert
            Assert.AreEqual(2, lstMedios.Count);
        }
        [TestMethod]
        public void ObtenerConfiguracionDHL_ValidarListaMedios_ItemsInstanciaAvionValido()
        {
            //Arrange
            var SUT = new RecuperadorConfiguracionTransportista();

            //Act
            var lstMedios = SUT.ObtenerConfiguracionDHL();

            //Assert
            Assert.IsInstanceOfType(lstMedios[0], typeof(MedioTransporteAvion));
        }
        [TestMethod]
        public void ObtenerConfiguracionDHL_ValidarListaMedios_ItemsInstanciaBarcoValido()
        {
            //Arrange
            var SUT = new RecuperadorConfiguracionTransportista();

            //Act
            var lstMedios = SUT.ObtenerConfiguracionDHL();

            //Assert
            Assert.IsInstanceOfType(lstMedios[1], typeof(MedioTransporteBarco));
        }
        [TestMethod]
        public void ObtenerConfiguracionEstafeta_ValidarListaMedios_ListaMedioConItems()
        {
            //Arrange
            var SUT = new RecuperadorConfiguracionTransportista();

            //Act
            var lstMedios = SUT.ObtenerConfiguracionEstafeta();

            //Assert
            Assert.AreEqual(1, lstMedios.Count);
        }
        [TestMethod]
        public void ObtenerConfiguracionEstafeta_ValidarListaMedios_ItemsInstanciaTrenValido()
        {
            //Arrange
            var SUT = new RecuperadorConfiguracionTransportista();

            //Act
            var lstMedios = SUT.ObtenerConfiguracionEstafeta();

            //Assert
            Assert.IsInstanceOfType(lstMedios[0], typeof(MedioTransporteTren));
        }
        [TestMethod]
        public void ObtenerConfiguracionFedex_ValidarListaMedios_ListaMedioConItems()
        {
            //Arrange
            var SUT = new RecuperadorConfiguracionTransportista();

            //Act
            var lstMedios = SUT.ObtenerConfiguracionFedex();

            //Assert
            Assert.AreEqual(1, lstMedios.Count);
        }
        [TestMethod]
        public void ObtenerConfiguracionFedex_ValidarListaMedios_ItemsInstanciaTrenValido()
        {
            //Arrange
            var SUT = new RecuperadorConfiguracionTransportista();

            //Act
            var lstMedios = SUT.ObtenerConfiguracionFedex();

            //Assert
            Assert.IsInstanceOfType(lstMedios[0], typeof(MedioTransporteBarco));
        }
    }
}
