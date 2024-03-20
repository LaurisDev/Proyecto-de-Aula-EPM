using Microsoft.VisualStudio.TestPlatform.TestHost;
using ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAulaTest
{
    [TestClass]

    public class MenuTests
    {
        [TestMethod]

        public void TestPromedioConsumoEnergia()
        {
            // Arrange
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente(13421, "Juan", "Perez", "2024-03", 3, 100, 200, 50, 60),
                new Cliente(23421, "Maria", "Lopez", "2024-03", 2, 150, 250, 40, 70)
            };


            int sumaConsumoEnergia = 0;
            foreach (Cliente c in clientes)
            {
                sumaConsumoEnergia += c.ConsumoActualEnergia;
            }
            double promedio = (double)sumaConsumoEnergia / clientes.Count;

            // Assert
            Assert.AreEqual(225, promedio);

        }

        [TestMethod]
        public void TestTotalDescuentos()
        {
            //Arrange
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente(13421, "Juan", "Perez", "2024-03", 3, 100, 200, 50, 60),
                new Cliente(23421, "Maria", "Lopez", "2024-03", 2, 150, 250, 40, 70)
            };

            double totalDescuentosEsperado = 0;
            foreach (Cliente c in clientes)
            {
                double descuentoCliente = (c.MetaAhorroEnergia - c.ConsumoActualEnergia) * Cliente.TarifaEnergia;
                if (descuentoCliente > 0)
                    totalDescuentosEsperado += descuentoCliente;
            }

            // Act
            double totalDescuentosCalculado = 0;
            foreach (Cliente c in clientes)
            {
                double descuentoCliente = (c.MetaAhorroEnergia - c.ConsumoActualEnergia) * Cliente.TarifaEnergia;
                if (descuentoCliente > 0)
                    totalDescuentosCalculado += descuentoCliente;
            }

            // Assert
            Assert.AreEqual(totalDescuentosEsperado, totalDescuentosCalculado);


        }

        [TestMethod]

        public void TestExcesoDeAgua()
        {

            //arrage
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente(13421, "Juan", "Perez", "2024-03", 3, 100, 200, 50, 60),
                new Cliente(23421, "Maria", "Lopez", "2024-03", 2, 150, 250, 40, 70)
            };

            int totalExcesoAguaEsperado = 0;
            foreach (Cliente c in clientes)
            {
                totalExcesoAguaEsperado += Math.Max(0, c.ConsumoActualAgua - c.PromedioConsumoAgua);
            }


            int totalExcesoAguaCalculado = 0;
            foreach (Cliente c in clientes)
            {
                totalExcesoAguaCalculado += Math.Max(0, c.ConsumoActualAgua - c.PromedioConsumoAgua);
            }

            Assert.AreEqual(totalExcesoAguaEsperado, totalExcesoAguaCalculado);

        }





    }
}
