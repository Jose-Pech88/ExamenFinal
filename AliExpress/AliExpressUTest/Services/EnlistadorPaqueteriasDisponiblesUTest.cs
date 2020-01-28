using System;
using AliExpress.Services;
using AliExpress.Services.Factory.Interfaces;
using AliExpress.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class EnlistadorPaqueteriasDisponiblesUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnlistadorPaqueteriasDisponibles_ParametroIRecuperadorTransportistasNulo_ArgumentNullException()
        {
            //Arrange
            var DOCRecuperadorTransportista= new Mock<IRecuperadorTransportistas>();
            var SUT = new EnlistadorPaqueteriasDisponibles(null);

            //Act

            //Assert
        }

        [TestMethod]
        public void obtenerListadoTransportistas_ObtenerListaTransportistas_ListaTransportitasCon3Items()
        {
            //Arrange
            var DOCDHL = new Mock<ITransportistas>();
            var DOCEstafeta = new Mock<ITransportistas>();
            var DOCFedex = new Mock<ITransportistas>();
            var DOCRecuperadorTransportista = new Mock<IRecuperadorTransportistas>();
            var SUT = new EnlistadorPaqueteriasDisponibles(DOCRecuperadorTransportista.Object);
            DOCRecuperadorTransportista.Setup((s) => s.ObtenerTransportista("DHL")).Returns(DOCDHL.Object);
            DOCRecuperadorTransportista.Setup((s) => s.ObtenerTransportista("Estafeta")).Returns(DOCEstafeta.Object);
            DOCRecuperadorTransportista.Setup((s) => s.ObtenerTransportista("Fedex")).Returns(DOCFedex.Object);
            //Act
            var lstTransportistas = SUT.obtenerListadoTransportistas();

            //Assert
            Assert.AreEqual(3, lstTransportistas.Count);
        }
    }
}
