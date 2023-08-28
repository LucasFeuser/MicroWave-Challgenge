using MicroOndas.BLL.Business;
using MicroOndas.BLL.Business.Interfaces;
using MicroOndas.DTO.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace MicroOndas.API.Controllers
{
    public class ProgramaAquecimentoController : ApiController
    {
        private IProgramaAquecimentoBLL _programaAquecimentoBLL;

        public ProgramaAquecimentoController(IProgramaAquecimentoBLL programaAquecimentoBLL)
        {
            _programaAquecimentoBLL = programaAquecimentoBLL; 
        }

        public string Get()
        {
            return _programaAquecimentoBLL.getProgramasAquecimento();
        }

        public void Post([FromBody] ProgramaAquecimentoDTO programaAquecimento)
        {
           _programaAquecimentoBLL.newProgramaAquecimento(programaAquecimento);
        }
    }
}
