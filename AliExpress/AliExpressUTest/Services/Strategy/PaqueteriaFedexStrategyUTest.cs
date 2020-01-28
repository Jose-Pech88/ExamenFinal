using System;
using System.Collections.Generic;
using AliExpress.Data.Entities;
using AliExpress.Data.Entities.DTO;
using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services;
using AliExpress.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AliExpressUTest.Services.Strategy
{
    [TestClass]
    public class PaqueteriaFedexStrategyUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PaqueteriaFedexStrategy_ParametroIEvaluadorFechaAnteriorNulo_ArgumentNullException()
        {
            //Arrange
            var SUT = new PaqueteriaFedexStrategy(null);

            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProcesarDTOPaqueteEnviado_ParametroIPaqueteEnviadoNulo_ArgumentNullException()
        {
            //Arrange
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaFedexStrategy(DOCRecuperadorTiempo.Object);

            //Act
            var PaqueteProcesado = SUT.ProcesarDTOPaqueteEnviado(null);

            //Assert
        }

        [TestMethod]
        public void cPaqueteria_ObtenerValorPropiedad_ValorCorrectoFedex()
        {
            //Arrange
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaFedexStrategy(DOCRecuperadorTiempo.Object);

            //Act
            var cPaqueteria = SUT.cPaqueteria;

            //cMedioTransporte
            Assert.AreEqual(cPaqueteria, "Fedex");
        }

        [TestMethod]
        public void ProcesarDTOPaqueteEnviado_MedioTransporteInexistente_BoleanoConValorFalse()
        {
            //Arrange
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaFedexStrategy(DOCRecuperadorTiempo.Object);
            IPaqueteEnviado paqueteEnviado = new PaqueteEnviado();
            paqueteEnviado.cPaqueteria = "Patito";

            //Act
            var PaqueteProcesado = SUT.ProcesarDTOPaqueteEnviado(paqueteEnviado);

            //Assert
            Assert.IsFalse(PaqueteProcesado);
        }

        [TestMethod]
        public void ProcesarDTOPaqueteEnviado_ValidarAsignacionFechaEntrega_PropiedadFechaEntregaAsiganda()
        {
            //Arrange
            List<IMediosTransportes> lstFedex = new List<IMediosTransportes>();
            MedioTransporteBarco barco = new MedioTransporteBarco();
            lstFedex.Add(barco);
            DateTime dtTest = new DateTime(2020, 01, 21, 01, 00, 00);
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaFedexStrategy(DOCRecuperadorTiempo.Object);
            SUT.lstMediosTransporte = lstFedex;
            IPaqueteEnviado paqueteEnviado = new PaqueteEnviado();

            paqueteEnviado.cPaqueteria = "Fedex";
            paqueteEnviado.cMedioTransporte = "Barco";
            paqueteEnviado.dtFechaActual = new DateTime(2020,01,01);
            paqueteEnviado.dtFechaPedido = new DateTime(2020,01,21);
            paqueteEnviado.cDistancia = "46";

            //Act
            var PaqueteProcesado = SUT.ProcesarDTOPaqueteEnviado(paqueteEnviado);

            //Assert
            Assert.AreEqual(dtTest, paqueteEnviado.dtFechaEntrega);
        }
        [TestMethod]
        public void ProcesarDTOPaqueteEnviado_ValidarAsignacionCostoEnvio_PropiedadCostoEnvioAsignada()
        {
            //Arrange
            List<IMediosTransportes> lstFedex = new List<IMediosTransportes>();
            MedioTransporteBarco barco = new MedioTransporteBarco();
            lstFedex.Add(barco);

            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaFedexStrategy(DOCRecuperadorTiempo.Object);
            SUT.lstMediosTransporte = lstFedex;
            IPaqueteEnviado paqueteEnviado = new PaqueteEnviado();

            paqueteEnviado.cPaqueteria = "Fedex";
            paqueteEnviado.cMedioTransporte = "Barco";
            paqueteEnviado.dtFechaActual = new DateTime(2020, 01, 01);
            paqueteEnviado.dtFechaPedido = new DateTime(2020, 01, 21);
            paqueteEnviado.cDistancia = "46";

            //Act
            var PaqueteProcesado = SUT.ProcesarDTOPaqueteEnviado(paqueteEnviado);

            //Assert
            Assert.AreEqual(69, paqueteEnviado.dCostoEnvio);
        }
    }
}
