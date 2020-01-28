using System;
using AliExpress.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class ValidadorDiaUTest
    {
        [TestMethod]
        public void ProcesarTiempo_TiempoMenorA31Dia_CadenaConDiferenciaEnDias()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 23, 12, 30, 00);
            DateTime dtFechaEvaluar = new DateTime(2020, 02, 20, 22, 45, 00);
            ValidadorDia validadorDia = new ValidadorDia();

            //Act
            var cDias = validadorDia.ProcesarTiempo(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual("28 Días", cDias);
        }

        [TestMethod]
        public void ProcesarTiempo_TiempoMayorA30Dia_ResultadoCadenaVacia()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 23, 12, 30, 00);
            DateTime dtFechaEvaluar = new DateTime(2020, 02, 23, 12, 30, 00);
            ValidadorDia validadorDia = new ValidadorDia();

            //Act
            var cDias = validadorDia.ProcesarTiempo(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual("", cDias);
        }
    }
}
