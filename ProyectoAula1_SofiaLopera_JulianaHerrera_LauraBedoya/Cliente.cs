using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya
{
    public class Cliente
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string PeriodoConsumo { get; set; }
        public int Estrato { get; set; }
        public int MetaAhorroEnergia { get; set; }
        public int ConsumoActualEnergia { get; set; }
        public int PromedioConsumoAgua { get; set; }
        public int ConsumoActualAgua { get; set; }
        public const int TarifaEnergia = 850;
        public const int TarifaAgua = 4600;


        public Cliente(int cedula, string nombre,string apellidos, string periodoConsumo, int estrato, int metaAhorroEnergia, int consumoActualEnergia, int promedioConsumoAgua, int consumoActualAgua)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellidos = apellidos;
            PeriodoConsumo = periodoConsumo;
            Estrato = estrato;
            MetaAhorroEnergia = metaAhorroEnergia;
            ConsumoActualEnergia = consumoActualEnergia;
            PromedioConsumoAgua = promedioConsumoAgua;
            ConsumoActualAgua = consumoActualAgua;

        }

        public static Cliente SolicitarDatosCliente()
        {
            Console.WriteLine("Ingrese los datos del nuevo cliente:");
   
            Console.Write("Cédula: ");
            int cedula = int.Parse(Console.ReadLine());

            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Apellido: ");
            string apellidos = Console.ReadLine();

            Console.WriteLine("Periodo de consumo: ");
            string periodoConsumo = Console.ReadLine();

            Console.Write("Estrato: ");
            int estrato = int.Parse(Console.ReadLine());

            Console.Write("Meta de ahorro de energía: ");
            int metaAhorroEnergia = int.Parse(Console.ReadLine());

            Console.Write("Consumo actual de energía: ");
            int consumoActualEnergia = int.Parse(Console.ReadLine());

            Console.Write("Promedio de consumo de agua: ");
            int promedioConsumoAgua = int.Parse(Console.ReadLine());

            Console.Write("Consumo actual de agua: ");
            int consumoActualAgua = int.Parse(Console.ReadLine());

            return new Cliente(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, promedioConsumoAgua, consumoActualAgua);
        }

        static void ActualizarCedula(Cliente cliente, int nuevaCedula)
        {
            cliente.Cedula = nuevaCedula;
        }

        static void ActualizarNombre(Cliente cliente, string nuevoNombre)
        {
            cliente.Nombre = nuevoNombre;
        }

        static void ActualizarApellidos(Cliente cliente, string nuevoApellidos)
        {
            cliente.Apellidos = nuevoApellidos;
        }

        static void ActualizarPeriodoConsumo(Cliente cliente, string nuevoPeriodoConsumo)
        {
            cliente.PeriodoConsumo = nuevoPeriodoConsumo;
        }

        static void ActualizarEstrato(Cliente cliente, int nuevoEstrato)
        {
            cliente.Estrato = nuevoEstrato;
        }

        static void ActualizarMetaAhorroEnergia(Cliente cliente, int nuevaMetaAhorro)
        {
            cliente.MetaAhorroEnergia = nuevaMetaAhorro;
        }

        static void ActualizarConsumoActualEnergia(Cliente cliente, int nuevoConsumoEnergia)
        {
            cliente.ConsumoActualEnergia = nuevoConsumoEnergia;
        }

        static void ActualizarPromedioConsumoAgua(Cliente cliente, int nuevoPromedioAgua)
        {
            cliente.PromedioConsumoAgua = nuevoPromedioAgua;
        }

        static void ActualizarConsumoActualAgua(Cliente cliente, int nuevoConsumoAgua)
        {
            cliente.ConsumoActualAgua = nuevoConsumoAgua;
        }

        public static void ActualizarInformacionCliente(List<Cliente> clientes)
        {
            Console.Write("Ingrese la cédula del cliente que desea actualizar: ");
            int cedulaClienteActualizar = int.Parse(Console.ReadLine());
            Cliente clienteActualizar = clientes.Find(c => c.Cedula == cedulaClienteActualizar);
            if (clienteActualizar != null)
            {
                Console.WriteLine("Seleccione el dato que desea actualizar:");
                Console.WriteLine("1. Cedula");
                Console.WriteLine("2. Nombre");
                Console.WriteLine("3. Apellidos");
                Console.WriteLine("4. Periodo de consumo");
                Console.WriteLine("5. Estrato");
                Console.WriteLine("6. Meta de ahorro de energía");
                Console.WriteLine("7. Consumo actual de energía");
                Console.WriteLine("8. Promedio de consumo de agua");
                Console.WriteLine("9. Consumo actual de agua");
                Console.Write("Ingrese el número correspondiente a la opción: ");
                string opcionActualizar = Console.ReadLine();

                switch (opcionActualizar)
                {
                    case "1":
                        Console.Write("Ingrese la nueva cedula del usuario: ");
                        int nuevaCedula = int.Parse(Console.ReadLine());
                        ActualizarCedula(clienteActualizar, nuevaCedula);
                        Console.WriteLine("Cedula del usuario actualizada correctamente.");
                        break;
                    case "2":
                        Console.Write("Ingrese el nuevo nombre del usuario: ");
                        string nuevoNombre = Console.ReadLine();
                        ActualizarNombre(clienteActualizar, nuevoNombre);
                        Console.WriteLine("Nombre del usuario actualizada correctamente.");
                        break;
                    case "3":
                        Console.Write("Ingrese los nuevos apellidos del usuario: ");
                        string nuevoApellidos = Console.ReadLine();
                        ActualizarApellidos(clienteActualizar, nuevoApellidos);
                        Console.WriteLine("Apellidos del usuario actualizados correctamente.");
                        break;
                    case "4":
                        Console.Write("Ingrese el nuevo periodo de consumo del usuario: ");
                        string nuevoPeriodoConsumo = Console.ReadLine();
                        ActualizarPeriodoConsumo(clienteActualizar, nuevoPeriodoConsumo);
                        Console.WriteLine("Periodo de consumo actualizado correctamente.");
                        break;
                    case "5":
                        Console.Write("Ingrese el nuevo estrato del usuario: ");
                        int nuevoEstrato = int.Parse(Console.ReadLine());
                        ActualizarEstrato(clienteActualizar, nuevoEstrato);
                        Console.WriteLine("Estrato actualizado correctamente.");
                        break;
                    case "6":
                        Console.Write("Ingrese la nueva meta de ahorro de energia del usuario: ");
                        int nuevaMetaAhorro = int.Parse(Console.ReadLine());
                        ActualizarMetaAhorroEnergia(clienteActualizar, nuevaMetaAhorro);
                        Console.WriteLine("Meta de ahorro de energia actualizado correctamente.");
                        break;
                    case "7":
                        Console.Write("Ingrese el nuevo consumo actual de energía: ");
                        int nuevoConsumoEnergia = int.Parse(Console.ReadLine());
                        ActualizarConsumoActualEnergia(clienteActualizar, nuevoConsumoEnergia);
                        Console.WriteLine("Consumo actual de energía actualizado correctamente.");
                        break;
                    case "8":
                        Console.Write("Ingrese el nuevo promedio de consumo de agua: ");
                        int nuevoPromedioAgua = int.Parse(Console.ReadLine());
                        ActualizarPromedioConsumoAgua(clienteActualizar, nuevoPromedioAgua);
                        Console.WriteLine("Promedio de consumo de agua actualizado correctamente.");
                        break;
                    case "9":
                        Console.Write("Ingrese el nuevo consumo actual de agua: ");
                        int nuevoConsumoAgua = int.Parse(Console.ReadLine());
                        ActualizarConsumoActualAgua(clienteActualizar, nuevoConsumoAgua);
                        Console.WriteLine("Consumo actual de agua actualizado correctamente.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        public static void EliminarInformacionCliente(List<Cliente> clientes)
        {
            Console.Write("Ingrese la cédula del cliente que desea eliminar: ");
            int cedulaClienteEliminar = int.Parse(Console.ReadLine());
            Cliente clienteEliminar = clientes.Find(c => c.Cedula == cedulaClienteEliminar);
            if (clienteEliminar != null)
            {
                clientes.Remove(clienteEliminar);
                Console.WriteLine("Cliente eliminado correctamente");
            }
            else { Console.WriteLine("Cliente no encontrado"); }
        }

    }

}

