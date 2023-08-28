using MicroOndas.DATA.Repository.Interfaces;
using System.Web;
using System.IO;
using System;

namespace MicroOndas.DATA.Repository
{
    public class JsonRepository : IJsonRepository
    {
        private string ArquivoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\MicroOndas.DATA\\ProgramasAquecimento.json");

        public void Save(string jsonString)
        {            
            File.WriteAllText(ArquivoPath, jsonString);
        }

        public string getJson()
        {
            return File.ReadAllText(ArquivoPath);
        }
    }
}
