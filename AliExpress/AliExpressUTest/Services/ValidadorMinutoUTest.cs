using System;
using AliExpress.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class ValidadorMinutoUTest
    {
        [TestMethod]
        public void ProcesarTiempo_TiempoMenorA1Hora_CadenaConDiferenciaEnMinutos()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 23, 12, 30, 00);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 23, 12, 45, 00);
            ValidadorMinuto validadorMinuto = new ValidadorMinuto();

            //Act
            var iMinutos = validadorMinuto.ProcesarTiempo(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual("15 Minutos", iMinutos);
        }

        [TestMethod]
        public void ProcesarTiempo_TiempoMayorA1Hora_ResultadoCadenaVacia()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 23, 12, 30, 00);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 23, 01, 30, 00);
            ValidadorMinuto validadorMinuto = new ValidadorMinuto();

            //Act
            var iMinutos = validadorMinuto.ProcesarTiempo(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual("", iMinutos);
        }
    }
}
