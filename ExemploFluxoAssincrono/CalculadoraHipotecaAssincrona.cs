using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploFluxoAssincrono
{
    public static class CalculadoraHipotecaAssincrona
    {
        public static async Task<int> ObterAnosVida()
        {
            Console.WriteLine("\nObtendo anos de vida laboral...");
            await Task.Delay(5000);
            return new Random().Next(1, 35);
        }

        public static async Task<bool> EContratoIndefinido()
        {
            Console.WriteLine("\nVerificando se o tipo de contrato é indefinido...");
            await Task.Delay(5000);
            return new Random().Next(1, 10) % 2 == 0;

        }

        public static async Task<int> ObterSaldoBruto()
        {
            Console.WriteLine("\nObtendo Saldo Brto...");
            await Task.Delay(5000);
            return new Random().Next(800, 6000);
        }

        public static async Task<int> ObterGastosMensais()
        {
            Console.WriteLine("\nObtendo gastos mensais...");
            await Task.Delay(5000);
            return new Random().Next(200, 1000);

        }

        
        // Function
        public static bool AnalizarConcederHipoteca(

                int anosVidaLaboral,
                bool tipoContratoIndefinido,
                int saldoBruto,
                int gastosMensais,
                int quantidadeSolicitada,
                int anosPagar
                )
        {
            Console.WriteLine("\nAnaliando condições para conseção de hipoteca...");
            
            if (anosVidaLaboral < 2)
            {
                return false;
            }

            // Obter cota mensal
            var cota = (quantidadeSolicitada / anosPagar) / 12;

            if (cota >= saldoBruto || cota > (saldoBruto / 2)) {
                return false;
            }

            // Obter percentagem sobre gastos
            var percentagemGastosSobreSaldo = gastosMensais * 100 / saldoBruto;

            if (percentagemGastosSobreSaldo > 30)
            {
                return false;
            }

            if ((cota = gastosMensais) >= saldoBruto)
            {
                return false;
            }

            if (tipoContratoIndefinido)
            {
                if((cota + gastosMensais) > (saldoBruto / 3) )
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            // Hipoteca concedida
            return true;
        }
    }
}
