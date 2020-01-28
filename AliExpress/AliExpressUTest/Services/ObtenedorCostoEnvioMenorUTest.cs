using System;
using System.Collections.Generic;
using AliExpress.Data.Entities.DTO;
using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services;
using AliExpress.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class ObtenedorCostoEnvioMenorUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnlistadorPaqueteriasDisponibles_ParametroIEnlistadorPaqueteriaDisponiblesNulo_ArgumentNullException()
        {
            //Arrange
            var SUT = new ObtenedorCostoEnvioMenor(null);

            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RecuperarDTOCostoMenor_ParametroIPaqueteEnviadoNulo_ArgumentNullException()
        {
            //Arrange
            var DOCIEnlistadorPaqueterias = new Mock<IEnlistadorPaqueteriaDisponibles>();
            var SUT = new ObtenedorCostoEnvioMenor(DOCIEnlistadorPaqueterias.Object);

            //Act
            var DT = SUT.RecuperarDTOCostoMenor(null);

            //Assert
        }

        [TestMethod]
        public void RecuperarDTOCostoMenor_ValidarPropiedadEmpresa_PropiedadPaqueteriaDHL()
        {
            //Arrange
            List<IMediosTransportes> lstDHL = new List<IMediosTransportes>();
            IMediosTransportes barco = new MedioTransporteBarco();
            var DOCGeneradorMensaje = new Mock<IGeneradorMensajes>();
            lstDHL.Add(barco);
            var DHL = new PaqueteriaDHLStrategy(DOCGeneradorMensaje.Object);
            DHL.lstMediosTransporte = lstDHL;
            List<ITransportistas> lstTransportistas = new List<ITransportistas>();
            lstTransportistas.Add(DHL);
            IPaqueteEnviado paqueteEnviado = new PaqueteEnviado();
            paqueteEnviado.cPaqueteria = "Fedex";
            paqueteEnviado.cMedioTransporte = "Barco";
            paqueteEnviado.dtFechaActual = new DateTime(2020, 01, 01);
            paqueteEnviado.dtFechaPedido = new DateTime(2020, 01, 21);
            paqueteEnviado.cDistancia = "600";
            paqueteEnviado.dCostoEnvio = 1000;
            var DOCIEnlistadorPaqueterias = new Mock<IEnlistadorPaqueteriaDisponibles>();
            DOCIEnlistadorPaqueterias.Setup((s) => s.obtenerListadoTransportistas()).Returns(lstTransportistas);
            var SUT = new ObtenedorCostoEnvioMenor(DOCIEnlistadorPaqueterias.Object);

            //Act
            var PaqueteCostoMenor = SUT.RecuperarDTOCostoMenor(paqueteEnviado);

            //Assert
            Assert.AreEqual("DHL", PaqueteCostoMenor.Empresa);
        }

        [TestMethod]
        public void RecuperarDTOCostoMenor_ValidarPropiedadCosto_PropiedadCosto()
        {
            //Arrange
            List<IMediosTransportes> lstDHL = new List<IMediosTransportes>();
            IMediosTransportes barco = new MedioTransporteBarco();
            var DOCGeneradorMensaje = new Mock<IGeneradorMensajes>();
            lstDHL.Add(barco);
            var DHL = new PaqueteriaDHLStrategy(DOCGeneradorMensaje.Object);
            DHL.lstMediosTransporte = lstDHL;
            List<ITransportistas> lstTransportistas = new List<ITransportistas>();
            lstTransportistas.Add(DHL);
            IPaqueteEnviado paqueteEnviado = new PaqueteEnviado();
            paqueteEnviado.cPaqueteria = "Fedex";
            paqueteEnviado.cMedioTransporte = "Barco";
            paqueteEnviado.dtFechaActual = new DateTime(2020, 01, 01);
            paqueteEnviado.dtFechaPedido = new DateTime(2020, 01, 21);
            paqueteEnviado.cDistancia = "600";
            paqueteEnviado.dCostoEnvio = 1000;
            var DOCIEnlistadorPaqueterias = new Mock<IEnlistadorPaqueteriaDisponibles>();
            DOCIEnlistadorPaqueterias.Setup((s) => s.obtenerListadoTransportistas()).Returns(lstTransportistas);
            var SUT = new ObtenedorCostoEnvioMenor(DOCIEnlistadorPaqueterias.Object);

            //Act
            var PaqueteCostoMenor = SUT.RecuperarDTOCostoMenor(paqueteEnviado);

            //Assert
            Assert.AreEqual(160, PaqueteCostoMenor.CostoEnvio);
        }
    }
}
