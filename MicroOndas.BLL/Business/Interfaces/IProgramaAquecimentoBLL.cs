using MicroOndas.DTO.DTO;

namespace MicroOndas.BLL.Business.Interfaces
{
    public interface IProgramaAquecimentoBLL
    {
        string getProgramasAquecimento();
        void newProgramaAquecimento(ProgramaAquecimentoDTO programaAquecimento);
    }
}
