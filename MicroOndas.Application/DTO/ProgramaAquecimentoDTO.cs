namespace MicroOndas.Application.DTO
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
