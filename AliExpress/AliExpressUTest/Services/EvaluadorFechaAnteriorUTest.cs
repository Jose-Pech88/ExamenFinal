using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliExpress.Services;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class EvaluadorFechaAnteriorUTest
    {
        [TestMethod]
        public void EvaluarFechaAnterior_FechaEvaluarPasado_ValorTrue()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 07, 20, 55, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 05, 14, 45, 000);
            var SUT = new EvaluadorFechaAnterior();

            //Act
            var lEsFechaAnterior = SUT.EvaluarFechaAnterior(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(true, lEsFechaAnterior);
        }

        [TestMethod]
        public void EvaluarFechaAnterior_FechaEvaluarPasado_ValorFalse()
        {
            //Arrange
            DateTime dtFechaBase = new DateTime(2020, 01, 05, 20, 55, 000);
            DateTime dtFechaEvaluar = new DateTime(2020, 01, 07, 14, 45, 000);
            var SUT = new EvaluadorFechaAnterior();

            //Act
            var lEsFechaAnterior = SUT.EvaluarFechaAnterior(dtFechaBase, dtFechaEvaluar);

            //Assert
            Assert.AreEqual(false, lEsFechaAnterior);
        }
    }
}
