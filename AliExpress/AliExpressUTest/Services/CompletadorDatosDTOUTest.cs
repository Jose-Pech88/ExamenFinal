using System;
using AliExpress.Data.Entities.DTO;
using AliExpress.Services;
using AliExpress.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class CompletadorDatosDTOUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompletadorDatosDTO_ParametroIEvaluadorFechaAnteriorNulo_ArgumentNullException()
        {
            //Arrange
            var DOCRecuperadorTiempo = new Mock<IObtenedorTiempo>();
            var SUT = new CompletadorDatosDTO(null, DOCRecuperadorTiempo.Object);

            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompletadorDatosDTO_ParametroIRecuperadorEstrategiaMensajeEventoNulo_ArgumentNullException()
        {
            //Arrange
            var DOCEvaluadorFechaAnterior = new Mock<IEvaluadorFechaAnterior>();
            var DOCRecuperadorTiempo = new Mock<IObtenedorTiempo>();
            var SUT = new CompletadorDatosDTO(DOCEvaluadorFechaAnterior.Object, null);

            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LlenarDTOPaquete_ParametroPaqueteNulo_ArgumentNullException()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 07, 20, 55, 000);
            var DOCEvaluadorFechaAnterior = new Mock<IEvaluadorFechaAnterior>();
            var DOCRecuperadorTiempo = new Mock<IObtenedorTiempo>();
            var SUT = new CompletadorDatosDTO(DOCEvaluadorFechaAnterior.Object, DOCRecuperadorTiempo.Object);

            //Act
            SUT.LlenarDTOPaquete(null);

            //Assert

        }

        [TestMethod]
        public void LlenarDTOPaquete_AsignarValorPropiedadlPaqueteEnviado_PropiedadlPaqueteEntregadoTrue()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 07, 20, 55, 000);
            PaqueteEnviado Paquete = new PaqueteEnviado() { dtFechaActual = dtFechaBase , dtFechaEntrega = new DateTime(2020, 01, 10, 20, 55, 000)};
            var DOCEvaluadorFechaAnterior = new Mock<IEvaluadorFechaAnterior>();
            DOCEvaluadorFechaAnterior.Setup((s) => s.EvaluarFechaAnterior(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);
            var DOCRecuperadorTiempo = new Mock<IObtenedorTiempo>();
            DOCRecuperadorTiempo.Setup((s) => s.RecuperarExpresionTiempo().ProcesarTiempo(Paquete.dtFechaActual, Paquete.dtFechaEntrega)).Returns(string.Empty);
            var SUT = new CompletadorDatosDTO(DOCEvaluadorFechaAnterior.Object, DOCRecuperadorTiempo.Object);

            //Act
            SUT.LlenarDTOPaquete(Paquete);

            //Assert
            Assert.AreEqual(true, Paquete.lPaqueteEntregado);
        }

        [TestMethod]
        public void LlenarDTOPaquete_AsignarValorPropiedadlPaqueteEnviado_PropiedadlPaqueteEntregadoFalse()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2021, 01, 07, 20, 55, 000);
            PaqueteEnviado Paquete = new PaqueteEnviado() { dtFechaActual = dtFechaBase, dtFechaEntrega = new DateTime(2020, 01, 10, 20, 55, 000) };
            var DOCEvaluadorFechaAnterior = new Mock<IEvaluadorFechaAnterior>();
            DOCEvaluadorFechaAnterior.Setup((s) => s.EvaluarFechaAnterior(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(false);
            var DOCRecuperadorTiempo = new Mock<IObtenedorTiempo>();
            DOCRecuperadorTiempo.Setup((s) => s.RecuperarExpresionTiempo().ProcesarTiempo(Paquete.dtFechaActual, Paquete.dtFechaEntrega)).Returns(string.Empty);
            var SUT = new CompletadorDatosDTO(DOCEvaluadorFechaAnterior.Object, DOCRecuperadorTiempo.Object);

            //Act
            SUT.LlenarDTOPaquete(Paquete);

            //Assert
            Assert.AreEqual(false, Paquete.lPaqueteEntregado);
        }

        [TestMethod]
        public void LlenarDTOEvento_AsignarValorPropiedadcExpresionTiempo_PropiedadcExpresionTiempoIgualA10Minutos()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 10, 20, 45, 000);
            PaqueteEnviado Paquete = new PaqueteEnviado() { dtFechaActual = dtFechaBase, dtFechaEntrega = new DateTime(2020, 01, 10, 20, 55, 000) };
            var DOCEvaluadorFechaAnterior = new Mock<IEvaluadorFechaAnterior>();
            DOCEvaluadorFechaAnterior.Setup((s) => s.EvaluarFechaAnterior(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(false);
            var DOCRecuperadorTiempo = new Mock<IObtenedorTiempo>();
            DOCRecuperadorTiempo.Setup((s) => s.RecuperarExpresionTiempo().ProcesarTiempo(Paquete.dtFechaActual, Paquete.dtFechaEntrega)).Returns("10 Minutos");
            var SUT = new CompletadorDatosDTO(DOCEvaluadorFechaAnterior.Object, DOCRecuperadorTiempo.Object);

            //Act
            SUT.LlenarDTOPaquete(Paquete);

            //Assert
            Assert.AreEqual("10 Minutos", Paquete.cExpresionTiempo);
        }
    }
}
