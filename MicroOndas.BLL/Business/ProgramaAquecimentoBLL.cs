using MicroOndas.BLL.Business.Interfaces;
using MicroOndas.DATA.Repository.Interfaces;
using MicroOndas.DTO.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MicroOndas.BLL.Business
{
    public class ProgramaAquecimentoBLL : IProgramaAquecimentoBLL
    {
        private readonly IJsonRepository _jsonRepository;

        public ProgramaAquecimentoBLL(IJsonRepository jsonRepository)
        {
            _jsonRepository = jsonRepository;
        }

        public string getProgramasAquecimento()
        {
            return _jsonRepository.getJson();
        }


    }
}
