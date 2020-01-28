using System;
using AliExpress.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class ValidadorHoraUTest
    {
        [TestMethod]
        public void ProcesarTiempo_TiempoMenorA1Dia_CadenaConDiferenciaEnHoras()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 23, 12, 30, 00);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 23, 22, 45, 00);
            ValidadorHora validadorHora = new ValidadorHora();

            //Act
            var cHoras = validadorHora.ProcesarTiempo(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual("10 Horas", cHoras);
        }

        [TestMethod]
        public void ProcesarTiempo_TiempoMayorA1Dia_ResultadoCadenaVacia()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 23, 12, 30, 00);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 24, 13, 30, 00);
            ValidadorHora validadorHora = new ValidadorHora();

            //Act
            var cHoras = validadorHora.ProcesarTiempo(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual("", cHoras);
        }
    }
}
