using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsCartS
{
    public class Relatorio
    {
        public Relatorio() { }

        public int Id { get; set; }
        public int Certidao {  get; set; }
        public string Remessa { get; set; }
        public string Protesto { get; set; }
        public int Quantidade { get; set; }
        public string Data {  get; set; }
        public double Valor { get; set; }

        public Relatorio(int id, string remessa, int certidao, string protesto, int quantidade, string data, double valor) 
        {
            this.Id = id;
            this.Certidao = certidao;
            this.Remessa = remessa;
            this.Protesto = protesto;
            this.Quantidade = quantidade;
            this.Data = data;
            this.Valor = valor;

        }
    }
}
