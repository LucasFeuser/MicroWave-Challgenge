using MicroOndas.DATA.Repository.Interfaces;
using MicroOndas.BLL.Business.Interfaces;
using MicroOndas.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void newProgramaAquecimento(ProgramaAquecimentoDTO programaAquecimento)
        {
            bool existe = VerificarExiste(programaAquecimento);
            if (existe) { return; }
            try
            {
                string jsonGet = _jsonRepository.getJson();
                List<ProgramaAquecimentoDTO> programas = JsonConvert.DeserializeObject<List<ProgramaAquecimentoDTO>>(jsonGet);
                programas.Add(programaAquecimento);

                string jsonSave = JsonConvert.SerializeObject(programas);
                _jsonRepository.Save(jsonSave);
            }catch(Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        private bool VerificarExiste(ProgramaAquecimentoDTO programaAquecimento)
        {
            string json = _jsonRepository.getJson();
            List<ProgramaAquecimentoDTO> programas = JsonConvert.DeserializeObject<List<ProgramaAquecimentoDTO>>(json);
            return programas.Any(p => p.Nome == programaAquecimento.Nome || p.Alimento == programaAquecimento.Alimento);
        }
    }
}
