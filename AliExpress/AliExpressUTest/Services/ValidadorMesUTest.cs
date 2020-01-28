using System;
using AliExpress.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class ValidadorMesUTest
    {
        [TestMethod]
        public void ProcesarTiempo_TiempoMayor30Dias_CadenaDiferenciaEnMeses()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 23, 12, 30, 00);
            DateTime dtFechaEvaluar = new DateTime(2020, 02, 27, 12, 45, 00);
            ValidadorMes validadorMes = new ValidadorMes();

            //Act
            var cMes = validadorMes.ProcesarTiempo(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual("1 Meses", cMes);
        }

        [TestMethod]
        public void ProcesarTiempo_TiempoMenorA30Dias_ResultadoCadenaError()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 23, 12, 30, 00);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 23, 01, 30, 00);
            ValidadorMes validadorMes = new ValidadorMes();

            //Act
            var cMes = validadorMes.ProcesarTiempo(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual("No se pudo determinar la expressión tiempo", cMes);
        }
    }
}
