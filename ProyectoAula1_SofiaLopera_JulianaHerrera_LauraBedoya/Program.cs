using ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya;
using System;
using System.Collections.Generic;

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
                Console.WriteLine("12.Salir");
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
                        Console.Write("Ingrese la cédula del cliente: ");
                        int cedulaCliente = int.Parse(Console.ReadLine());
                        Cliente cliente = clientes.Find(c => c.Cedula == cedulaCliente);
                        if (cliente != null)
                        {
                            CalculadoraFacturacion calculadora = new CalculadoraFacturacion();
                            double valorPagar = calculadora.CalcularValorPagar(cliente.MetaAhorroEnergia, cliente.ConsumoActualEnergia, cliente.PromedioConsumoAgua, cliente.ConsumoActualAgua );
                            Console.WriteLine($"El valor a pagar del cliente {cliente.Cedula} es: {valorPagar}");
                        }
                        else
                        {
                            Console.WriteLine("Cliente no encontrado.");
                        }
                        break;
                    case "4":
                        int sumaConsumoEnergia = 0;
                        foreach (Cliente c in clientes)
                        {
                            sumaConsumoEnergia += c.ConsumoActualEnergia;
                        }
                        double promedioConsumoEnergia = (double)sumaConsumoEnergia / clientes.Count;
                        Console.WriteLine($"El promedio de consumo de energía es: {promedioConsumoEnergia}");
                        break;
                    case "5":
                        double totalDescuentos = 0;
                        foreach (Cliente c in clientes)
                        {
                            double descuentoCliente = (c.MetaAhorroEnergia - c.ConsumoActualEnergia) * Cliente.TarifaEnergia;
                            if (descuentoCliente > 0)
                                totalDescuentos += descuentoCliente;
                        }
                        Console.WriteLine($"El total de descuentos por incentivo de energía es: {totalDescuentos}");
                        break;
                    case "6":
                        totalExcesoAgua = 0;
                        foreach (Cliente c in clientes)
                        {
                            totalExcesoAgua += Math.Max(0, c.ConsumoActualAgua - c.PromedioConsumoAgua);
                        }
                        Console.WriteLine($"La cantidad total de mt3 de agua consumidos por encima del promedio es: {totalExcesoAgua}");
                        break;
                    case "7":
                        Dictionary<int, int> totalConsumoAguaPorEstrato = new Dictionary<int, int>();
                        Dictionary<int, int> totalExcesoAguaPorEstrato = new Dictionary<int, int>();

                        foreach (Cliente c in clientes)
                        {
                            if (!totalConsumoAguaPorEstrato.ContainsKey(c.Estrato))
                            {
                                totalConsumoAguaPorEstrato[c.Estrato] = 0;
                            }
                            if (!totalExcesoAguaPorEstrato.ContainsKey(c.Estrato))
                            {
                                totalExcesoAguaPorEstrato[c.Estrato] = 0;
                            }

                            totalConsumoAguaPorEstrato[c.Estrato] += c.ConsumoActualAgua;
                            totalExcesoAguaPorEstrato[c.Estrato] += Math.Max(0, c.ConsumoActualAgua - c.PromedioConsumoAgua);
                        }

                        Console.WriteLine("Porcentaje de consumo excesivo de agua por estrato:");
                        foreach (KeyValuePair<int, int> kvp in totalExcesoAguaPorEstrato)
                        {
                            int estrato = kvp.Key;
                            int totalExcesoAguaEstrato = kvp.Value;
                            int totalConsumoAguaEstrato = totalConsumoAguaPorEstrato[estrato];
                            double porcentajeExceso = (double)totalExcesoAguaEstrato / totalConsumoAguaEstrato * 100;
                            Console.WriteLine($"Estrato {estrato}: {porcentajeExceso}%");
                        }
                        break;
                    case "8":
                        Dictionary<int, int> TotalAhorroDeAguaPorEstrato = new Dictionary<int, int>();

                        foreach (Cliente c in clientes)
                        {
                            int excesoAgua = Math.Max(0, c.ConsumoActualAgua - c.PromedioConsumoAgua);//ahorro
                            if (!TotalAhorroDeAguaPorEstrato.ContainsKey(c.Estrato))
                            {
                                TotalAhorroDeAguaPorEstrato[c.Estrato] = 0;
                            }
                            TotalAhorroDeAguaPorEstrato[c.Estrato] += excesoAgua;
                        }

                        // Encontrar el estrato con el mayor ahorro de agua
                        KeyValuePair<int, int> mayorAhorroAgua = TotalAhorroDeAguaPorEstrato.OrderByDescending(x => x.Value).FirstOrDefault();

                        if (mayorAhorroAgua.Key != 0)
                        {
                            Console.WriteLine($"El estrato con el mayor ahorro de agua es el estrato {mayorAhorroAgua.Key} con un ahorro de {mayorAhorroAgua.Value} mt3.");
                        }
                        else
                        {
                            Console.WriteLine("No hay datos suficientes para calcular el estrato con el mayor ahorro de agua.");
                        }

                        break;
                    case "9":
                        Dictionary<int, int> consumoEnergiaPorEstrato = new Dictionary<int, int>();

                        // Calcular el consumo de energía por estrato
                        foreach (Cliente c in clientes)
                        {
                            if (!consumoEnergiaPorEstrato.ContainsKey(c.Estrato))
                            {
                                consumoEnergiaPorEstrato[c.Estrato] = 0;
                            }
                            consumoEnergiaPorEstrato[c.Estrato] += c.ConsumoActualEnergia;
                        }

                        // Encontrar el estrato con el mayor y menor consumo de energía
                        int estratoMayorConsumoEnergia = consumoEnergiaPorEstrato.OrderByDescending(x => x.Value).FirstOrDefault().Key;
                        int estratoMenorConsumoEnergia = consumoEnergiaPorEstrato.OrderBy(x => x.Value).FirstOrDefault().Key;

                        Console.WriteLine($"El estrato con el mayor consumo de energía es el estrato {estratoMayorConsumoEnergia}.");
                        Console.WriteLine($"El estrato con el menor consumo de energía es el estrato {estratoMenorConsumoEnergia}.");
                        break;
                    case "10":
                        int clientesConConsumoMayorPromedio = 0;
                        foreach (Cliente c in clientes)
                        {
                            if (c.ConsumoActualAgua > c.PromedioConsumoAgua)
                            {
                                clientesConConsumoMayorPromedio++;
                            }
                        }
                        Console.WriteLine($"La cantidad de clientes con consumo de agua mayor al promedio es: {clientesConConsumoMayorPromedio}");
                        break;
                    case "11":
                        Cliente clienteMayorDesfase = clientes.OrderByDescending(c => Math.Abs(c.ConsumoActualEnergia - c.MetaAhorroEnergia)).FirstOrDefault();
                        if (clienteMayorDesfase != null)
                        {
                            Console.WriteLine("Datos del cliente con mayor desfase en el consumo de energía:");
                            Console.WriteLine($"Cédula: {clienteMayorDesfase.Cedula}");
                            Console.WriteLine($"Nombre: {clienteMayorDesfase.Nombre}");
                            Console.WriteLine($"Apellido: {clienteMayorDesfase.Apellidos}");
                            Console.WriteLine($"Periodo de consumo: {clienteMayorDesfase.PeriodoConsumo}");
                            Console.WriteLine($"Estrato: {clienteMayorDesfase.Estrato}");
                            Console.WriteLine($"Meta de ahorro de energía: {clienteMayorDesfase.MetaAhorroEnergia}");
                            Console.WriteLine($"Consumo actual de energía: {clienteMayorDesfase.ConsumoActualEnergia}");
                            Console.WriteLine($"Promedio de consumo de agua: {clienteMayorDesfase.PromedioConsumoAgua}");
                            Console.WriteLine($"Consumo actual de agua: {clienteMayorDesfase.ConsumoActualAgua}");
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron clientes.");
                        }
                        break;
                    case "12":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
