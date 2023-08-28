using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroOndas.Application.Filters
{
    public class ProgramaAquecimentoFilter
    {
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public string Tempo { get; set; }
        public int Potencia { get; set; }
        public string Instrucao { get; set; }
        public bool isCustomizado { get; set; }
    }
}