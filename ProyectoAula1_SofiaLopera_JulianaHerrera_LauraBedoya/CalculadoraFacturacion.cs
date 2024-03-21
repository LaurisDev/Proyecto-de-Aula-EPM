using ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya
{
    public class CalculadoraFacturacion
    {
        public double CalcularValorPagar(int metaAhorroEnergia, int consumoActualEnergia, int promedioConsumoAgua, int consumoActualAgua)
        {
            // Calcular incentivo de energía
            double valorIncentivoEnergia = (metaAhorroEnergia - consumoActualEnergia) * Cliente.TarifaEnergia;

            // Calcular valor a pagar por energía
            double valorParcialEnergia = consumoActualEnergia * Cliente.TarifaEnergia;
            double valorPagarEnergia = valorParcialEnergia - valorIncentivoEnergia;

            // Inicialización de las variables
            double valorParcialAgua;
            double valorPagarAgua;

            // Calcular valor a pagar por agua
            if (consumoActualAgua > promedioConsumoAgua)
            {
                double valorExcesoAgua = (consumoActualAgua - promedioConsumoAgua) * 2 * Cliente.TarifaAgua;
                valorParcialAgua = promedioConsumoAgua * Cliente.TarifaAgua;
                valorPagarAgua = valorParcialAgua + valorExcesoAgua;
            }
            else
            {
                valorParcialAgua = consumoActualAgua * Cliente.TarifaAgua;
                valorPagarAgua = valorParcialAgua;
            }

            double valorTotalPagar = valorPagarEnergia + valorPagarAgua;
            return valorTotalPagar;
        }

        //case 3

        public static void CalcularValorPagar(List<Cliente> clientes)
        {
            Console.Write("Ingrese la cédula del cliente: ");
            int cedulaCliente = int.Parse(Console.ReadLine());
            Cliente cliente = clientes.Find(c => c.Cedula == cedulaCliente);
            if (cliente != null)
            {
                CalculadoraFacturacion calculadora = new CalculadoraFacturacion();
                double valorPagar = calculadora.CalcularValorPagar(cliente.MetaAhorroEnergia, cliente.ConsumoActualEnergia, cliente.PromedioConsumoAgua, cliente.ConsumoActualAgua);
                Console.WriteLine($"El valor a pagar del cliente {cliente.Cedula} es: {valorPagar}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }


        //case 4
        public static void CalcularPromedioConsumoEnergia(List<Cliente> clientes)
        {
            int sumaConsumoEnergia = 0;
            foreach (Cliente c in clientes)
            {
                sumaConsumoEnergia += c.ConsumoActualEnergia;
            }
            double promedioConsumoEnergia = (double)sumaConsumoEnergia / clientes.Count;
            Console.WriteLine($"El promedio de consumo de energía es: {promedioConsumoEnergia}");
        }

        //case 5
        public static void CalcularTotalDescuentos(List<Cliente> clientes)
        {
            double totalDescuentos = 0;
            foreach (Cliente c in clientes)
            {
                double descuentoCliente = (c.MetaAhorroEnergia - c.ConsumoActualEnergia) * Cliente.TarifaEnergia;
                if (descuentoCliente > 0)
                    totalDescuentos += descuentoCliente;
            }
            Console.WriteLine($"El total de descuentos por incentivo de energía es: {totalDescuentos}");
        }

        //case 6
        public static void CalcularTotalExcesoAgua(List<Cliente> clientes)
        {
            double totalExcesoAgua = 0;
            foreach (Cliente c in clientes)
            {
                totalExcesoAgua += Math.Max(0, c.ConsumoActualAgua - c.PromedioConsumoAgua);
            }
            Console.WriteLine($"La cantidad total de mt3 de agua consumidos por encima del promedio es: {totalExcesoAgua}");
        }

        // case 7
        public static void CalcularPorcentajeConsumoExcesoAguaPorEstrato(List<Cliente> clientes)
        {
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
        }

        // case 8

        public static void CalcularMayorAhorroAguaPorEstrato(List<Cliente> clientes)
        {
            Dictionary<int, int> TotalAhorroDeAguaPorEstrato = new Dictionary<int, int>();

            foreach (Cliente c in clientes)
            {
                int excesoAgua = Math.Max(0, c.ConsumoActualAgua - c.PromedioConsumoAgua);
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
        }
        //case 9
        public static void CalcularConsumoEnergiaPorEstrato(List<Cliente> clientes)
        {
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
        }

        //case 10
        public static void ContarClientesConConsumoMayorPromedio(List<Cliente> clientes)
        {
            int clientesConConsumoMayorPromedio = 0;
            foreach (Cliente c in clientes)
            {
                if (c.ConsumoActualAgua > c.PromedioConsumoAgua)
                {
                    clientesConConsumoMayorPromedio++;
                }
            }
            Console.WriteLine($"La cantidad de clientes con consumo de agua mayor al promedio es: {clientesConConsumoMayorPromedio}");
        }

        //case 11
        public static void MostrarClienteMayorDesfase(List<Cliente> clientes)
        {
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
        }

        //case 12
        public static void CalcularTotalPagado(List<Cliente> clientes)
        {
            double totalPagadoEnergia = 0;
            double totalPagadoAgua = 0;

            foreach (Cliente c in clientes)
            {
                CalculadoraFacturacion calculadora = new CalculadoraFacturacion();
                double valorPagarEnergia = calculadora.CalcularValorPagar(c.MetaAhorroEnergia, c.ConsumoActualEnergia, c.PromedioConsumoAgua, c.ConsumoActualAgua);
                totalPagadoEnergia += valorPagarEnergia;

                double valorPagarAgua = c.ConsumoActualAgua * Cliente.TarifaAgua;
                totalPagadoAgua += valorPagarAgua;
            }

            Console.WriteLine($"El total pagado por los clientes por concepto de energía es: {totalPagadoEnergia}");
            Console.WriteLine($"El total pagado por los clientes por concepto de agua es: {totalPagadoAgua}");
        }


    }
}
