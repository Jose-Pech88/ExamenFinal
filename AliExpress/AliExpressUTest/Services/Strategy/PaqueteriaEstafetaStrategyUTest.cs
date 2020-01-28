using System;
using System.Collections.Generic;
using AliExpress.Data.Entities.DTO;
using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services;
using AliExpress.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AliExpressUTest.Services.Strategy
{
    [TestClass]
    public class PaqueteriaEstafetaStrategyUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PaqueteriaEstafetaStrategy_ParametroIEvaluadorFechaAnteriorNulo_ArgumentNullException()
        {
            //Arrange
            var SUT = new PaqueteriaEstafetaStrategy(null);

            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProcesarDTOPaqueteEnviado_ParametroIPaqueteEnviadoNulo_ArgumentNullException()
        {
            //Arrange
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaEstafetaStrategy(DOCRecuperadorTiempo.Object);

            //Act
            var PaqueteProcesado = SUT.ProcesarDTOPaqueteEnviado(null);

            //Assert
        }

        [TestMethod]
        public void cPaqueteria_ObtenerValorPropiedad_ValorCorrectoEstafeta()
        {
            //Arrange
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaEstafetaStrategy(DOCRecuperadorTiempo.Object);

            //Act
            var cPaqueteria = SUT.cPaqueteria;

            //cMedioTransporte
            Assert.AreEqual(cPaqueteria, "Estafeta");
        }

        [TestMethod]
        public void ProcesarDTOPaqueteEnviado_MedioTransporteInexistente_BoleanoConValorFalse()
        {
            //Arrange
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaEstafetaStrategy(DOCRecuperadorTiempo.Object);
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
            List<IMediosTransportes> lstEstafeta = new List<IMediosTransportes>();
            IMediosTransportes tren = new MedioTransporteTren();
            lstEstafeta.Add(tren);
            DateTime dtTest = new DateTime(2020, 01, 21, 01, 00, 00);
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaEstafetaStrategy(DOCRecuperadorTiempo.Object);
            SUT.lstMediosTransporte = lstEstafeta;
            IPaqueteEnviado paqueteEnviado = new PaqueteEnviado();

            paqueteEnviado.cPaqueteria = "Estafeta";
            paqueteEnviado.cMedioTransporte = "Tren";
            paqueteEnviado.dtFechaActual = new DateTime(2020, 01, 01);
            paqueteEnviado.dtFechaPedido = new DateTime(2020, 01, 21);
            paqueteEnviado.cDistancia = "80";

            //Act
            var PaqueteProcesado = SUT.ProcesarDTOPaqueteEnviado(paqueteEnviado);

            //Assert
            Assert.AreEqual(dtTest, paqueteEnviado.dtFechaEntrega);
        }

        [TestMethod]
        public void ProcesarDTOPaqueteEnviado_ValidarAsignacionCostoEnvio_PropiedadCostoEnvioAsignada()
        {
            //Arrange
            List<IMediosTransportes> lstEstafeta = new List<IMediosTransportes>();
            IMediosTransportes tren = new MedioTransporteTren();
            lstEstafeta.Add(tren);

            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaEstafetaStrategy(DOCRecuperadorTiempo.Object);
            SUT.lstMediosTransporte = lstEstafeta;
            IPaqueteEnviado paqueteEnviado = new PaqueteEnviado();

            paqueteEnviado.cPaqueteria = "Estafeta";
            paqueteEnviado.cMedioTransporte = "Tren";
            paqueteEnviado.dtFechaActual = new DateTime(2020, 01, 01);
            paqueteEnviado.dtFechaPedido = new DateTime(2020, 01, 21);
            paqueteEnviado.cDistancia = "80";

            //Act
            var PaqueteProcesado = SUT.ProcesarDTOPaqueteEnviado(paqueteEnviado);

            //Assert
            Assert.AreEqual(480, paqueteEnviado.dCostoEnvio);
        }
    }
}
