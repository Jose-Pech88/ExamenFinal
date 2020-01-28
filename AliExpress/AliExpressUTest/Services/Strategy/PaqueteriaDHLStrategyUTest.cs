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
    public class PaqueteriaDHLStrategyUTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PaqueteriaDHLStrategy_ParametroIEvaluadorFechaAnteriorNulo_ArgumentNullException()
        {
            //Arrange
            var SUT = new PaqueteriaDHLStrategy(null);

            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProcesarDTOPaqueteEnviado_ParametroIPaqueteEnviadoNulo_ArgumentNullException()
        {
            //Arrange
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaDHLStrategy(DOCRecuperadorTiempo.Object);

            //Act
            var PaqueteProcesado = SUT.ProcesarDTOPaqueteEnviado(null);

            //Assert
        }

        [TestMethod]
        public void cPaqueteria_ObtenerValorPropiedad_ValorCorrectoDHL()
        {
            //Arrange
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaDHLStrategy(DOCRecuperadorTiempo.Object);

            //Act
            var cPaqueteria = SUT.cPaqueteria;

            //cMedioTransporte
            Assert.AreEqual(cPaqueteria, "DHL");
        }

        [TestMethod]
        public void ProcesarDTOPaqueteEnviado_MedioTransporteInexistente_BoleanoConValorFalse()
        {
            //Arrange
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaDHLStrategy(DOCRecuperadorTiempo.Object);
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
            List<IMediosTransportes> lstDHL = new List<IMediosTransportes>();
            IMediosTransportes avion = new MedioTransporteAvion();
            lstDHL.Add(avion);
            DateTime dtTest = new DateTime(2020, 01, 21, 01, 00, 00);
            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaDHLStrategy(DOCRecuperadorTiempo.Object);
            SUT.lstMediosTransporte = lstDHL;
            IPaqueteEnviado paqueteEnviado = new PaqueteEnviado();

            paqueteEnviado.cPaqueteria = "DHL";
            paqueteEnviado.cMedioTransporte = "Avión";
            paqueteEnviado.dtFechaActual = new DateTime(2020, 01, 01);
            paqueteEnviado.dtFechaPedido = new DateTime(2020, 01, 21);
            paqueteEnviado.cDistancia = "600";

            //Act
            var PaqueteProcesado = SUT.ProcesarDTOPaqueteEnviado(paqueteEnviado);

            //Assert
            Assert.AreEqual(dtTest, paqueteEnviado.dtFechaEntrega);
        }

        [TestMethod]
        public void ProcesarDTOPaqueteEnviado_ValidarAsignacionCostoEnvio_PropiedadCostoEnvioAsignada()
        {
            //Arrange
            List<IMediosTransportes> lstDHL = new List<IMediosTransportes>();
            IMediosTransportes avion = new MedioTransporteAvion();
            lstDHL.Add(avion);

            var DOCRecuperadorTiempo = new Mock<IGeneradorMensajes>();
            var SUT = new PaqueteriaDHLStrategy(DOCRecuperadorTiempo.Object);
            SUT.lstMediosTransporte = lstDHL;
            IPaqueteEnviado paqueteEnviado = new PaqueteEnviado();

            paqueteEnviado.cPaqueteria = "DHL";
            paqueteEnviado.cMedioTransporte = "Avión";
            paqueteEnviado.dtFechaActual = new DateTime(2020, 01, 01);
            paqueteEnviado.dtFechaPedido = new DateTime(2020, 01, 21);
            paqueteEnviado.cDistancia = "600";

            //Act
            var PaqueteProcesado = SUT.ProcesarDTOPaqueteEnviado(paqueteEnviado);

            //Assert
            Assert.AreEqual(8400, paqueteEnviado.dCostoEnvio);
        }
    }
}
