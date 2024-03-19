using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya;

namespace ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya_Test

{
    [TestClass]
    public class ClienteTests
    {
        [TestMethod]
        public void Cliente_Constructor()
        {
            // Arrange
            int cedula = 123456789;
            string nombre = "John";
            string apellidos = "Doe";
            string periodoConsumo = "Mes 3";
            int estrato = 3;
            int metaAhorroEnergia = 150;
            int consumoActualEnergia = 180;
            int promedioConsumoAgua = 25;
            int consumoActualAgua = 20;

            // Act
            Cliente cliente = new Cliente(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);

            // Assert
            // Esta prueba garantiza que el constructor de la clase Cliente inicialice correctamente todas las propiedades del cliente con los valores proporcionados.
            Assert.AreEqual(cedula, cliente.Cedula);
            Assert.AreEqual(nombre, cliente.Nombre);
            Assert.AreEqual(apellidos, cliente.Apellidos);
            Assert.AreEqual(periodoConsumo, cliente.PeriodoConsumo);
            Assert.AreEqual(estrato, cliente.Estrato);
            Assert.AreEqual(metaAhorroEnergia, cliente.MetaAhorroEnergia);
            Assert.AreEqual(consumoActualEnergia, cliente.ConsumoActualEnergia);
            Assert.AreEqual(promedioConsumoAgua, cliente.PromedioConsumoAgua);
            Assert.AreEqual(consumoActualAgua, cliente.ConsumoActualAgua);
        }
    

 
        [TestMethod]
        public void SolicitarDatosCliente()
        {
            // Arrange
            var input = new System.IO.StringReader(
                "3145\nRoger\nTorres\nMes 3\n3\n150\n180\n25\n20\n"
            );
            System.Console.SetIn(input);

            // Act
            var cliente = Cliente.SolicitarDatosCliente();

            // Assert
            Assert.IsNotNull(cliente);
            Assert.AreEqual(3145, cliente.Cedula);
            Assert.AreEqual("Roger", cliente.Nombre);
            Assert.AreEqual("Torres", cliente.Apellidos);
            Assert.AreEqual("Mes 3", cliente.PeriodoConsumo);
            Assert.AreEqual(3, cliente.Estrato);
            Assert.AreEqual(150, cliente.MetaAhorroEnergia);
            Assert.AreEqual(180, cliente.ConsumoActualEnergia);
            Assert.AreEqual(25, cliente.PromedioConsumoAgua);
            Assert.AreEqual(20, cliente.ConsumoActualAgua);
        }


    }
}





