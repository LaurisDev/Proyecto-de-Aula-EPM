using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya;

namespace CalculadoraFacturacionTests
{
    [TestClass]
    public class CalculadoraFacturacionTests
    {
        [TestMethod]
        public void TestValorPagarConConsumoIgualAMeta()
        {
            // Arrange
            CalculadoraFacturacion calculadora = new CalculadoraFacturacion();
            int metaAhorroEnergia = 150;
            int consumoActualEnergia = 180;
            int promedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            // Act
            double valorTotalPagar = calculadora.CalcularValorPagar(metaAhorroEnergia, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);

            // Assert
            Assert.AreEqual(293500, valorTotalPagar);
        }

        [TestMethod]
        public void TestValorPagarConConsumoMenorQueMeta()
        {
            // Arrange
            CalculadoraFacturacion calculadora = new CalculadoraFacturacion();
            int metaAhorroEnergia = 150;
            int consumoActualEnergia = 120;
            int promedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            // Act
            double valorTotalPagar = calculadora.CalcularValorPagar(metaAhorroEnergia, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);

            // Assert
            Assert.AreEqual(191500, valorTotalPagar);
        }

        [TestMethod]
        public void TestValorPagarConConsumoMayorQueMeta()
        {
            // Arrange
            CalculadoraFacturacion calculadora = new CalculadoraFacturacion();
            int metaAhorroEnergia = 150;
            int consumoActualEnergia = 200;
            int promedioConsumoAgua = 25;
            int consumoActualAgua = 20;

            // Act
            double valorTotalPagar = calculadora.CalcularValorPagar(metaAhorroEnergia, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);

            // Assert
            Assert.AreEqual(304500, valorTotalPagar);
        }
    }
}
