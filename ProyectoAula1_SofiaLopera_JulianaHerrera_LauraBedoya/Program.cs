using ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya;
using System;
using System.Collections.Generic;
using static ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya.CalculadoraFacturacion;

namespace ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>();


            bool salir = false;
            int totalExcesoAgua = 0;

            while (!salir)
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("0. Agregar un cliente");
                Console.WriteLine("1. Actualizar la información del cliente");
                Console.WriteLine("2. Eliminar la información del cliente");
                Console.WriteLine("3. Calcular valor a pagar de un cliente");
                Console.WriteLine("4. Calcular promedio de consumo de energía");
                Console.WriteLine("5. Calcular valor total de descuentos por incentivo de energía");
                Console.WriteLine("6. Mostrar cantidad total de mt3 de agua consumidos por encima del promedio");
                Console.WriteLine("7. Mostrar porcentajes de consumo excesivo de agua por estrato");
                Console.WriteLine("8. Estrato en el cual ahorraron la mayor cantidad de agua");
                Console.WriteLine("9. Mostrar el estrato con el mayor y menor consumo de energía");
                Console.WriteLine("10.Contabilizar clientes con consumo de agua mayor al promedio");
                Console.WriteLine("11.Cliente que tuvo mayor desfase");
                Console.WriteLine("12.Valor total que los clientes le pagan a la empresa por concepto de energía y agua.");
                Console.WriteLine("13.Salir");

                Console.Write("Ingrese una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "0":
                        Cliente nuevoCliente = Cliente.SolicitarDatosCliente();
                        clientes.Add(nuevoCliente);
                        break;

                    case "1":
                        Cliente.ActualizarInformacionCliente(clientes);
                        break;

                    case "2":
                        Cliente.EliminarInformacionCliente(clientes);
                        break;

                    case "3":
                        CalculadoraFacturacion.CalcularValorPagar(clientes);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;

                    case "4":
                        CalculadoraFacturacion.CalcularPromedioConsumoEnergia(clientes);
                        break;

                    case "5":

                        CalculadoraFacturacion.CalcularTotalDescuentos(clientes);
                        break;

                    case "6":
                        CalculadoraFacturacion.CalcularTotalExcesoAgua(clientes);
                        break;

                    case "7":
                        CalculadoraFacturacion.CalcularPorcentajeConsumoExcesoAguaPorEstrato(clientes);
                        break;

                    case "8":
                        CalculadoraFacturacion.CalcularMayorAhorroAguaPorEstrato(clientes);
                        break;


                    case "9":
                        CalculadoraFacturacion.CalcularConsumoEnergiaPorEstrato(clientes);
                        break;

                    case "10":
                        CalculadoraFacturacion.ContarClientesConConsumoMayorPromedio(clientes);
                        break;

                    case "11":
                        CalculadoraFacturacion.MostrarClienteMayorDesfase(clientes);
                        break;

                    case "12":
                        CalculadoraFacturacion.CalcularTotalPagado(clientes);

                        break;

                    case "13":
                        salir = true;
                        break;
                }


            }
            Console.WriteLine();
        }
    }
}
