using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.DTO.DTO
{
    public class ProgramaAquecimentoDTO
    {
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public string Tempo { get; set; }
        public int Potencia { get; set; }
        public string Instrucao { get; set; }
        public bool isCustomizado { get; set; }
    }
}
