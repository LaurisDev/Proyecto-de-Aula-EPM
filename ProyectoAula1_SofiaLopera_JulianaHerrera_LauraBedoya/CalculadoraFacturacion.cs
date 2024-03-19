using ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula1_SofiaLopera_JulianaHerrera_LauraBedoya
{
    internal class CalculadoraFacturacion
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
    }
}
 
