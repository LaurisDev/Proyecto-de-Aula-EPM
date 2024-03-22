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

    public class MenuTests   // Pruebas unitarias de los cases del menu faltantes
    {
        //case 4

        [TestMethod]
        public void TestCalcularPromedioConsumoEnergia()
        {
            // Arrange
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente(123456, "Juan", "Pérez", "2023-03", 1, 100, 80, 50, 40),
                new Cliente(654321, "María", "Gómez", "2023-04", 2, 150, 120, 60, 50)
            };

            double expectedPromedio = (80 + 120) / 2.0; // Cálculo del promedio esperado

            // Capturar la salida de la consola
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                CalculadoraFacturacion.CalcularPromedioConsumoEnergia(clientes);

                // Obtener la salida de la consola como string
                string consoleOutput = sw.ToString().Trim();

                // Assert
                Assert.AreEqual($"El promedio de consumo de energía es: {expectedPromedio}", consoleOutput);
            }
        }



        //case 5
        [TestMethod]
        public void TestCalcularTotalDescuentos_Caso5()
        {
            // Arrange
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente(123456, "Juan", "Pérez", "2023-03", 1, 100, 80, 50, 40),
                new Cliente(654321, "María", "Gómez", "2023-04", 2, 150, 120, 60, 50)
            };

            // Capturar la salida de la consola
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                CalculadoraFacturacion.CalcularTotalDescuentos(clientes);

                // Obtener la salida de la consola como string
                string consoleOutput = sw.ToString().Trim();

                // Assert
                Assert.AreEqual("El total de descuentos por incentivo de energía es: 42500", consoleOutput);
            }
        }


        // case 6

        [TestMethod]
        public void TestCalcularTotalExcesoAgua_Caso6()
        {
            // Arrange
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente(123456, "Juan", "Pérez", "2023-03", 1, 100, 80, 50, 60),
                new Cliente(654321, "María", "Gómez", "2023-04", 2, 150, 120, 60, 50)
            };

            // Capturar la salida de la consola
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                CalculadoraFacturacion.CalcularTotalExcesoAgua(clientes);

                // Obtener la salida de la consola como string
                string consoleOutput = sw.ToString().Trim();

                // Assert
                Assert.IsTrue(consoleOutput.Contains("La cantidad total de mt3 de agua consumidos por encima del promedio es:")); // Verifica si se muestra el mensaje esperado
            }
        }


        // case 7

        [TestMethod]
        public void TestCalcularPorcentajeConsumoExcesoAguaPorEstrato_Caso7()
        {
            // Arrange
            List<Cliente> clientes = new List<Cliente>
        {
            new Cliente(123456, "Juan", "Pérez", "2023-03", 1, 100, 80, 50, 40),
            new Cliente(654321, "María", "Gómez", "2023-04", 2, 150, 120, 60, 50)
        };

            // Capturar la salida de la consola
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                CalculadoraFacturacion.CalcularPorcentajeConsumoExcesoAguaPorEstrato(clientes);

                // Obtener la salida de la consola como string
                string consoleOutput = sw.ToString().Trim();

                // Assert
                Assert.IsTrue(consoleOutput.Contains("Estrato 1:")); // Verifica si se muestra el porcentaje para el estrato 1
                Assert.IsTrue(consoleOutput.Contains("Estrato 2:")); // Verifica si se muestra el porcentaje para el estrato 2

            }
        }

        //case 8

        [TestMethod]
        public void TestCalcularMayorAhorroAguaPorEstrato_Caso8()
        {
            // Arrange
            List<Cliente> clientes = new List<Cliente>
        {
            new Cliente(123456, "Juan", "Pérez", "2023-03", 1, 100, 80, 50, 40),
            new Cliente(654321, "María", "Gómez", "2023-04", 2, 150, 120, 60, 50)
        };

            // Capturar la salida de la consola
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                CalculadoraFacturacion.CalcularMayorAhorroAguaPorEstrato(clientes);

                // Obtener la salida de la consola como string
                string consoleOutput = sw.ToString().Trim();

                // Assert
                Assert.IsTrue(consoleOutput.Contains("El estrato con el mayor ahorro de agua es el estrato")); // Verifica si se muestra el mensaje esperado
            }
        }



        //case 9

        [TestMethod]
        public void TestCalcularConsumoEnergiaPorEstrato_Caso9()
        {
            // Arrange
            List<Cliente> clientes = new List<Cliente>
        {
            new Cliente(123456, "Juan", "Pérez", "2023-03", 1, 100, 80, 50, 40),
            new Cliente(654321, "María", "Gómez", "2023-04", 2, 150, 120, 60, 50)
        };

            // Capturar la salida de la consola
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                CalculadoraFacturacion.CalcularConsumoEnergiaPorEstrato(clientes);

                // Obtener la salida de la consola como string
                string consoleOutput = sw.ToString().Trim();

                // Assert
                Assert.IsTrue(consoleOutput.Contains("El estrato con el mayor consumo de energía es el estrato")); // Verifica si se muestra el mensaje
                Assert.IsTrue(consoleOutput.Contains("El estrato con el menor consumo de energía es el estrato")); // Verifica si se muestra el mensaje 
            }
        }


        //case 10

        [TestMethod]
        public void TestContarClientesConConsumoMayorPromedio_Caso10()
        {
            // Arrange
            List<Cliente> clientes = new List<Cliente>
        {
            new Cliente(123456, "Juan", "Pérez", "2023-03", 1, 100, 80, 50, 60),
            new Cliente(654321, "María", "Gómez", "2023-04", 2, 150, 120, 60, 50),
            new Cliente(789012, "Carlos", "López", "2023-05", 3, 200, 180, 60, 70)
        };

            // Capturar la salida de la consola
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                CalculadoraFacturacion.ContarClientesConConsumoMayorPromedio(clientes);

                // Obtener la salida de la consola como string
                string consoleOutput = sw.ToString().Trim();

                // Assert
                Assert.AreEqual("La cantidad de clientes con consumo de agua mayor al promedio es: 2", consoleOutput); // Verifica si se muestra el mensaje con la cantidad correcta 
            }
        }


        //case 11

        [TestMethod]
        public void TestMostrarClienteMayorDesfase_Caso11()
        {
            // Arrange
            List<Cliente> clientes = new List<Cliente>
        {
            new Cliente(123456, "Juan", "Pérez", "2023-03", 1, 100, 80, 50, 40),
            new Cliente(654321, "María", "Gómez", "2023-04", 2, 150, 120, 60, 50)
        };

            // Capturar la salida de la consola
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                CalculadoraFacturacion.MostrarClienteMayorDesfase(clientes);

                // Obtener la salida de la consola como string
                string consoleOutput = sw.ToString().Trim();

                // Assert
                Assert.IsTrue(consoleOutput.Contains("Datos del cliente con mayor desfase en el consumo de energía:")); // Verifica si se muestra el mensaje esperado
            }
        }




        //case 12

        [TestMethod]
        public void TestCalcularTotalPagado_Caso12()
        {
            // Arrange
            List<Cliente> clientes = new List<Cliente>
        {
            new Cliente(123456, "Juan", "Pérez", "2023-03", 1, 100, 80, 50, 40),
            new Cliente(654321, "María", "Gómez", "2023-04", 2, 150, 120, 60, 50)
        };

            // Capturar la salida de la consola
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                CalculadoraFacturacion.CalcularTotalPagado(clientes);

                // Obtener la salida de la consola como string
                string consoleOutput = sw.ToString().Trim();

                // Assert
                Assert.IsTrue(consoleOutput.Contains("El total pagado por los clientes por concepto de energía es:")); // Verifica si se muestra el mensaje esperado
                Assert.IsTrue(consoleOutput.Contains("El total pagado por los clientes por concepto de agua es:"));
            }
        }



    }


}