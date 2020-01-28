using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AliExpress.Services.Interfaces;
using AliExpress.Services;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class RecuperadorListaPaquetesUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RecuperadorListaPaquetes_ParametroIObtenedorDatosArchivoNulo_ArgumentNullException()
        {
            //Arrange
            var SUT = new RecuperadorListaPaquetes(null);

            //Act

            //Assert
        }

        [TestMethod]
        public void RecuperarListaPaquetes_ArregloDatosVacio_ListaPaqueteVacia()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = null;
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual(0, lstEvento.Count());
        }

        [TestMethod]
        public void RecuperarListaPaquetes_ArregloDatosConItem_ListaPaqueteCon1Item()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen,1104,Fedex,Barco,21-01-2020" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual(1, lstEvento.Count());
        }

        [TestMethod]
        public void RecuperarListaPaquetes_ArregloDatosConItem1SeparacionesPorComa_ListaPaqueteCon1Item()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual(1, lstEvento.Count());
        }

        [TestMethod]
        public void RecuperarListaPaquetes_ArregloDatosConItem2SeparacionesPorComa_ListaPaqueteCon1Item()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual(1, lstEvento.Count());
        }

        [TestMethod]
        public void RecuperarListaPaquetes_ArregloDatosConItem3SeparacionesPorComa_ListaPaqueteCon1Item()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen,1104" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual(1, lstEvento.Count());
        }

        [TestMethod]
        public void RecuperarListaPaquetes_ArregloDatosConItem4SeparacionesPorComa_ListaPaqueteCon1Item()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen,1104,Fedex" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual(1, lstEvento.Count());
        }

        [TestMethod]
        public void RecuperarListaPaquetes_ArregloDatosConItem5SeparacionesPorComa_ListaPaqueteCon1Item()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen,1104,Fedex,Barco" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual(1, lstEvento.Count());
        }

        [TestMethod]
        public void RecuperarListaPaquetes_ArregloDatosConItem7SeparacionesPorComa_ListaPaqueteVacia()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen,1104,Fedex,Barco,21-01-2020," };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual(1, lstEvento.Count());
        }

        [TestMethod]
        public void RecuperarListaPaquetes_ValidarPosicionOrigen_ListaEventoConPosicionOrigenValido()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen,1104,Fedex,Barco,21-01-2020" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual("Cozumel", lstEvento[0].cOrigen);
        }
        [TestMethod]
        public void RecuperarListaPaquetes_ValidarPosicionDestino_ListaEventoConPosicionDestinoValido()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen,1104,Fedex,Barco,21-01-2020" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual("Playa del Carmen", lstEvento[0].cDestino);
        }
        [TestMethod]
        public void RecuperarListaPaquetes_ValidarPosicionDistancia_ListaEventoConPosicionDistanciaValido()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen,1104,Fedex,Barco,21-01-2020" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual("1104", lstEvento[0].cDistancia);
        }
        [TestMethod]
        public void RecuperarListaPaquetes_ValidarPosicionPaqueteria_ListaEventoConPosicionPaqueteriaValido()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen,1104,Fedex,Barco,21-01-2020" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual("Fedex", lstEvento[0].cPaqueteria);
        }
        [TestMethod]
        public void RecuperarListaPaquetes_ValidarPosicionMedio_ListaEventoConPosicionMedioValido()
        {
            //Arrange
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen,1104,Fedex,Barco,21-01-2020" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual("Barco", lstEvento[0].cMedioTransporte);
        }

        [TestMethod]
        public void RecuperarListaPaquetes_ValidarPosicionFechaPedido_ListaEventoConPosicionFechaPedidoValido()
        {
            //Arrange
            DateTime dtTest = new DateTime(2020, 01, 21);
            var DOCObtenedorDatosArchivo = new Mock<IObtenedorDatosArchivo>();
            string[] arrFilas = new string[1] { "Cozumel,Playa del Carmen,1104,Fedex,Barco,21-01-2020" };
            DOCObtenedorDatosArchivo.Setup((s) => s.LeerArchivo(It.IsAny<string>())).Returns(arrFilas);
            var SUT = new RecuperadorListaPaquetes(DOCObtenedorDatosArchivo.Object);

            //Act
            var lstEvento = SUT.RecuperarListaPaquetes(It.IsAny<string>());

            //Assert
            Assert.AreEqual(dtTest, lstEvento[0].dtFechaPedido);
        }
    }
}
