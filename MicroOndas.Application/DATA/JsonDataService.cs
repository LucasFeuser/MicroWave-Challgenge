using MicroOndas.Application.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace MicroOndas.Application.DATA
{
    public static class JsonDataService 
    {
        private static string arquivo = HttpContext.Current.Server.MapPath("~/programasAquecimento.json");

        public static void Save<T>(T data)
        {
            var jsonString = JsonConvert.SerializeObject(data);
            File.WriteAllText(arquivo, jsonString);
        }

        public static List<ProgramaAquecimentoDTO> Load()
        {
            var jsonString = File.ReadAllText(arquivo);
            return JsonConvert.DeserializeObject<List<ProgramaAquecimentoDTO>>(jsonString);
        }
    }
}