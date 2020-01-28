using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AliExpress.Services;
using AliExpress.Services.Interfaces;
using AliExpress.Services.Factory.Interfaces;
using AliExpress.Data.Entities.Interfaces;

namespace AliExpressUTest.Services
{
    /// <summary>
    /// Descripción resumida de ObtenedorMensajeEventosUTest
    /// </summary>
    [TestClass]
    public class ObtenedorMensajePaquetesUTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObtenedorMensajePaquetes_CrearInstanciaDepenciaIRecuperadorListaPaquetesNulo_ArgumentNullException()
        {
            //Arrange
            var DOCRecuperadorTransportistas = new Mock<IRecuperadorTransportistas>();
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var DOCObtenedorCostoEnvioMenor = new Mock<IObtenedorCostoEnvioMenor>();
            var SUT = new ObtenedorMensajePaquetes(null, DOCRecuperadorTransportistas.Object, DOCCompletadorDatosDTO.Object, DOCGeneradorMensajes.Object, DOCObtenedorCostoEnvioMenor.Object);
            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObtenedorMensajePaquetes_CrearInstanciaDependenciaIRecuperadorTransportistasNulo_ArgumentNullException()
        {
            //Arrange
            var DOCListaPaquetes = new Mock<IRecuperadorListaPaquetes>();
            var DOCRecuperadorTransportistas = new Mock<IRecuperadorTransportistas>();
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var DOCObtenedorCostoEnvioMenor = new Mock<IObtenedorCostoEnvioMenor>();
            var SUT = new ObtenedorMensajePaquetes(DOCListaPaquetes.Object, null, DOCCompletadorDatosDTO.Object, DOCGeneradorMensajes.Object, DOCObtenedorCostoEnvioMenor.Object);
            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObtenedorMensajePaquetes_CrearInstanciaDependenciaICompletadorDatosDTONulo_ArgumentNullException()
        {
            //Arrange
            var DOCListaPaquetes = new Mock<IRecuperadorListaPaquetes>();
            var DOCRecuperadorTransportistas = new Mock<IRecuperadorTransportistas>();
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var DOCObtenedorCostoEnvioMenor = new Mock<IObtenedorCostoEnvioMenor>();
            var SUT = new ObtenedorMensajePaquetes(DOCListaPaquetes.Object, DOCRecuperadorTransportistas.Object, null, DOCGeneradorMensajes.Object, DOCObtenedorCostoEnvioMenor.Object);
            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObtenedorMensajePaquetes_CrearInstanciaDependenciaIGeneradorMensajesNulo_ArgumentNullException()
        {
            //Arrange
            var DOCListaPaquetes = new Mock<IRecuperadorListaPaquetes>();
            var DOCRecuperadorTransportistas = new Mock<IRecuperadorTransportistas>();
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var DOCObtenedorCostoEnvioMenor = new Mock<IObtenedorCostoEnvioMenor>();
            var SUT = new ObtenedorMensajePaquetes(DOCListaPaquetes.Object, DOCRecuperadorTransportistas.Object, DOCCompletadorDatosDTO.Object, null, DOCObtenedorCostoEnvioMenor.Object);
            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObtenedorMensajePaquetes_CrearInstanciaDependenciaIObtenedorCostoEnvioMenorNulo_ArgumentNullException()
        {
            //Arrange
            var DOCListaPaquetes = new Mock<IRecuperadorListaPaquetes>();
            var DOCRecuperadorTransportistas = new Mock<IRecuperadorTransportistas>();
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var DOCObtenedorCostoEnvioMenor = new Mock<IObtenedorCostoEnvioMenor>();
            var SUT = new ObtenedorMensajePaquetes(DOCListaPaquetes.Object, DOCRecuperadorTransportistas.Object, DOCCompletadorDatosDTO.Object, DOCGeneradorMensajes.Object, null);
            //Act

            //Assert
        }
        public void ObtenerMensaje_ListaPaqueteVacia_SinRegistrosProcesados()
        {
            //Arrange
            List<IPaqueteEnviado> lstPaquete = new List<IPaqueteEnviado>();
            string cPath = string.Empty;
            DateTime dtFechaBase = new DateTime(2020, 01, 05);
            var DOCListaPaquetes = new Mock<IRecuperadorListaPaquetes>();
            DOCListaPaquetes.Setup((s) => s.RecuperarListaPaquetes(It.IsAny<string>())).Returns(lstPaquete);
            var DOCRecuperadorTransportistas = new Mock<IRecuperadorTransportistas>();         
            var DOCCompletadorDatosDTO = new Mock<ICompletadorDatosDTO>();
            var DOCGeneradorMensajes = new Mock<IGeneradorMensajes>();
            var DOCObtenedorCostoEnvioMenor = new Mock<IObtenedorCostoEnvioMenor>();
            var SUT = new ObtenedorMensajePaquetes(DOCListaPaquetes.Object, DOCRecuperadorTransportistas.Object, DOCCompletadorDatosDTO.Object, DOCGeneradorMensajes.Object, DOCObtenedorCostoEnvioMenor.Object);
            //Act
            SUT.ObtenerMensaje(cPath, dtFechaBase);

            //Assert
            Assert.AreEqual(0, lstPaquete.Count);
        }

    }
}
