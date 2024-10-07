using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsCartS
{
    public class HelpProtesto
    {
        private static double ValorProtesto { get; set; }
        private static double ValorCertidao { get; set;}

        public static double ResultProtesto(int certidao, int quantidade)
        {
            ValorProtesto = 8.95;
            ValorCertidao = 80.92;
            var Subtracao = quantidade - certidao;
            var Multipicacao = Subtracao * ValorProtesto;
            var Soma = Multipicacao + ValorCertidao;
            var Resultado = Soma;
            return Resultado;
        }

    }
}
