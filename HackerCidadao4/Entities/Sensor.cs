using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerCidadao4.Entities
{
    public class Sensor
    {
        public string Codigo { get; set; }
        public string Porta { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string Tipo { get; set; }
        public string DataSheet { get; set; }
        public string Minimo { get; set; }
        public string Maximo { get; set; }
        public string Valor { get; set; }
    }
}
