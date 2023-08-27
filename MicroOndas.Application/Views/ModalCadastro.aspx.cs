using MicroOndas.Application.DATA;
using MicroOndas.Application.DTO;
using System.Collections.Generic;
using System.Web.UI;
using System.Linq;
using System;

namespace MicroOndas.Application.Views
{
    public partial class ModalCadastro : Page
    {

        protected void AdicionarNovoItemPreAquecimento(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                List<ProgramaAquecimentoDTO> programas = JsonDataService.Load();

                bool programaJaExiste = programas.Any(p => p.Nome == NomeDTO.Text || p.Alimento == AlimentoDTO.Text);
                if (programaJaExiste)
                {
                    string script = "function AlertaProgramaInvalido(){alert('Programa já existe no sistema.');} AlertaProgramaInvalido();";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ProgramaInvalido", script, true);
                }
                else
                {
                    programas.Add(new ProgramaAquecimentoDTO
                    {
                        Nome = NomeDTO.Text,
                        Alimento = AlimentoDTO.Text,
                        Tempo = TempoDTO.Text,
                        Potencia = int.Parse(PotenciaDTO.Text),
                        Instrucao = InstrucaoDTO.Text,
                        isCustomizado = true,
                    });
                    JsonDataService.Save(programas);
                }
            }
        }

        protected void RetonarAquecimento(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}