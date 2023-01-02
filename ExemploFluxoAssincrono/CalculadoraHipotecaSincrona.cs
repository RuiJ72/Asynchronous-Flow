using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploFluxoAssincrono
{
    public static class CalculadoraHipotecaSincrona
    {
        public static int ObterAnosVida()
        {
            Console.WriteLine("\nObtendo anos de vida laboral...");
            Task.Delay(5000).Wait(); // Esperamos 5 segundos
            return new Random().Next(1, 35); // Entre um e 35
        }

        public static bool EContratoIndefinido()
        {
            Console.WriteLine("\nVerificando se o tipo de contrato é indefinido");
            Task.Delay(5000).Wait();
            return new Random().Next(1, 10) % 2 == 0; // True ou False se o valor aleatório é par/ímpar

        }

        public static int ObterSaldoBruto()
        {
            Console.WriteLine("\nObtendo Saldo Brto...");
            Task.Delay(5000).Wait();
            return new Random().Next(800, 6000); // Devolvemos um valor entre 800 e 6000
        }

        public static int ObterGastosMensais()
        {
            Console.WriteLine("\nObtendo gastos mensais...");
            Task.Delay(10000).Wait();
            return new Random().Next(200, 10000); // Devolve um valor entyre 200 e 1000
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
