using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services;
using AliExpress.Services.Factory;
using AliExpress.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AliExpressUTest.Services.Factory
{
    [TestClass()]
    public class RecuperadorTransportistaFactoryUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RecuperadorTransportistaFactory_ParametrorecuperadorConfiguracionTransportistaNulo_ArgumentNullException()
        {
            //Arrange
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var SUT = new RecuperadorTransportistaFactory(null, DOCGeneradorMensajes.Object);

            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RecuperadorTransportistaFactory_ParametrogeneradorMensajesNulo_ArgumentNullException()
        {
            //Arrange
            var DOCRecuperador = new Mock<IRecuperadorConfiguracionTransportista>();
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var SUT = new RecuperadorTransportistaFactory(DOCRecuperador.Object, null);

            //Act

            //Assert
        }

        [TestMethod()]
        public void ObtenerTransportista_ObtenerInstacia_InstanciaNula()
        {
            //Arrange
            string cOpcion = string.Empty;
            var DOCRecuperador = new Mock<IRecuperadorConfiguracionTransportista>();
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var SUT = new RecuperadorTransportistaFactory(DOCRecuperador.Object, DOCGeneradorMensajes.Object);

            //Act
            var Transportistas = SUT.ObtenerTransportista(cOpcion);

            //Assert
            Assert.IsNull(Transportistas);
        }

        [TestMethod()]
        public void ObtenerTransportista_ObtenerInstacia_InstanciaPaqueteriaDHLStrategy()
        {
            //Arrange
            string cOpcion = "DHL";
            var DOCRecuperador = new Mock<IRecuperadorConfiguracionTransportista>();
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var SUT = new RecuperadorTransportistaFactory(DOCRecuperador.Object, DOCGeneradorMensajes.Object);

            //Act
            var Transportistas = SUT.ObtenerTransportista(cOpcion);

            //Assert
            Assert.IsInstanceOfType(Transportistas, typeof(PaqueteriaDHLStrategy));
        }

        [TestMethod()]
        public void ObtenerTransportista_ObtenerInstacia_InstanciaPaqueteriaEstafetaStrategy()
        {
            //Arrange
            string cOpcion = "Estafeta";
            var DOCRecuperador = new Mock<IRecuperadorConfiguracionTransportista>();
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var SUT = new RecuperadorTransportistaFactory(DOCRecuperador.Object, DOCGeneradorMensajes.Object);

            //Act
            var Transportistas = SUT.ObtenerTransportista(cOpcion);

            //Assert
            Assert.IsInstanceOfType(Transportistas, typeof(PaqueteriaEstafetaStrategy));
        }
        [TestMethod()]
        public void ObtenerTransportista_ObtenerInstacia_InstanciaPaqueteriaFedexStrategy()
        {
            //Arrange
            string cOpcion = "Fedex";
            var DOCRecuperador = new Mock<IRecuperadorConfiguracionTransportista>();
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var SUT = new RecuperadorTransportistaFactory(DOCRecuperador.Object, DOCGeneradorMensajes.Object);

            //Act
            var Transportistas = SUT.ObtenerTransportista(cOpcion);

            //Assert
            Assert.IsInstanceOfType(Transportistas, typeof(PaqueteriaFedexStrategy));
        }
    }
}