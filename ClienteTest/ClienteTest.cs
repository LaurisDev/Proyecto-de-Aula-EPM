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
            int cedula = 1234;
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
        public void SolicitarDatos()
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
        [TestMethod]
        public void ActualizarClienteCedula()
        {
            //Arrange
            Cliente cliente = new Cliente(1234, "Nombre", "Apellidos", "Periodo", 2, 100, 140, 30, 25);
            int nuevaCedula = 3145;

            //Act
            Cliente.ActualizarCedula(cliente, nuevaCedula);

            //Assert
            Assert.AreEqual(nuevaCedula, cliente.Cedula);

        }

        [TestMethod]
        public void ActualizarClienteNombre()
        {
            //Arrange
            Cliente cliente = new Cliente(1234, "Nombre", "Apellidos", "Periodo", 2, 100, 140, 30, 25);
            string nuevoNombre = "NuevoNombre";

            //Act
            Cliente.ActualizarNombre(cliente, nuevoNombre);

            //Assert
            Assert.AreEqual(nuevoNombre, cliente.Nombre);

        }

        [TestMethod]
        public void ActualizarClienteApellidos()
        {
            //Arrange
            Cliente cliente = new Cliente(1234, "Nombre", "Apellidos", "Periodo", 2, 100, 140, 30, 25);
            string nuevoApellidos = "NuevoApellidos";

            //Act
            Cliente.ActualizarApellidos(cliente, nuevoApellidos);

            //Assert
            Assert.AreEqual(nuevoApellidos, cliente.Apellidos);

        }

        [TestMethod]
        public void ActualizarClientePeriodoConsumo()
        {
            //Arrange
            Cliente cliente = new Cliente(1234, "Nombre", "Apellidos", "Periodo", 2, 100, 140, 30, 25);
            string nuevoPeriodoConsumo = "NuevoPeriodoConsumo";

            //Act
            Cliente.ActualizarPeriodoConsumo(cliente, nuevoPeriodoConsumo);

            //Assert
            Assert.AreEqual(nuevoPeriodoConsumo, cliente.PeriodoConsumo);

        }

        [TestMethod]
        public void ActualizarClienteEstrato()
        {
            //Arrange
            Cliente cliente = new Cliente(1234, "Nombre", "Apellidos", "Periodo", 2, 100, 140, 30, 25);
            int nuevoEstrato = 3;

            //Act
            Cliente.ActualizarEstrato(cliente, nuevoEstrato);

            //Assert
            Assert.AreEqual(nuevoEstrato, cliente.Estrato);

        }

        [TestMethod]
        public void ActualizarClienteMetaAhorroEnergia()
        {
            //Arrange
            Cliente cliente = new Cliente(1234, "Nombre", "Apellidos", "Periodo", 2, 100, 140, 30, 25);
            int nuevaMetaAhorro = 120;

            //Act
            Cliente.ActualizarMetaAhorroEnergia(cliente, nuevaMetaAhorro);

            //Assert
            Assert.AreEqual(nuevaMetaAhorro, cliente.MetaAhorroEnergia);

        }

        [TestMethod]
        public void ActualizarClienteConsumoActualEnergia()
        {
            //Arrange
            Cliente cliente = new Cliente(1234, "Nombre", "Apellidos", "Periodo", 2, 100, 140, 30, 25);
            int nuevoConsumoEnergia = 130;

            //Act
            Cliente.ActualizarConsumoActualEnergia(cliente, nuevoConsumoEnergia);

            //Assert
            Assert.AreEqual(nuevoConsumoEnergia, cliente.ConsumoActualEnergia);

        }

        [TestMethod]
        public void ActualizarClientePromedioConsumoAgua()
        {
            //Arrange
            Cliente cliente = new Cliente(1234, "Nombre", "Apellidos", "Periodo", 2, 100, 140, 30, 25);
            int nuevoPromedioConsumoAgua = 40;

            //Act
            Cliente.ActualizarPromedioConsumoAgua(cliente, nuevoPromedioConsumoAgua);

            //Assert
            Assert.AreEqual(nuevoPromedioConsumoAgua, cliente.PromedioConsumoAgua);

        }

        [TestMethod]
        public void ActualizarClienteConsumoActualAgua()
        {
            //Arrange
            Cliente cliente = new Cliente(1234, "Nombre", "Apellidos", "Periodo", 2, 100, 140, 30, 25);
            int nuevoConsumoAgua = 30;

            //Act
            Cliente.ActualizarConsumoActualAgua(cliente, nuevoConsumoAgua);

            //Assert
            Assert.AreEqual(nuevoConsumoAgua, cliente.ConsumoActualAgua);

        }

  


    }
}





