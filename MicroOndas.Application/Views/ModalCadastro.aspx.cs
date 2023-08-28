using MicroOndas.Application.Endpoint;
using MicroOndas.Application.Filters;
using Newtonsoft.Json;
using System;
using System.Web.UI;

namespace MicroOndas.Application.Views
{
    public partial class ModalCadastro : Page
    {

        protected void AdicionarNovoItemPreAquecimento(object sender, EventArgs e)
        {
            EndpointHelper helper = new EndpointHelper();
            ProgramaAquecimentoFilter programaAquecimento = new ProgramaAquecimentoFilter
            {
                Nome = NomeDTO.Text,
                Alimento = AlimentoDTO.Text,
                Tempo = TempoDTO.Text,
                Potencia = int.Parse(PotenciaDTO.Text),
                isCustomizado = true,
                Instrucao = InstrucaoDTO.Text
            };

            string json = JsonConvert.SerializeObject(programaAquecimento);
            try
            {
                helper.postProgramasAquecimento(json);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.InnerException.Message); }
        }

        protected void RetonarAquecimento(object sender, EventArgs e)
        {
            Response.Redirect("MicroOndas.aspx");
        }
    }
}