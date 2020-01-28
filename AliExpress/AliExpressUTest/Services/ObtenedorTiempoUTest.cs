using System;
using AliExpress.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AliExpress.Services;

namespace AliExpressUTest.Services
{
    [TestClass]
    public class ObtenedorTiempoUTest
    {
        [TestMethod]
        public void RecuperarExpresionTiempo_ObtenerInstancia_InstanciaValida()
        {
            //Arrange
            var DOC = new Mock<IRecuperadorExpressionTiempo>();
            var SUT = new ObtenedorTiempo();
            //Act
            var expresionTime = SUT.RecuperarExpresionTiempo();

            //Assert
            Assert.IsInstanceOfType(expresionTime, typeof(ValidadorMinuto));
        }
    }
}
