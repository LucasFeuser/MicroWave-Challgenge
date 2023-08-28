using MicroOndas.Application.Endpoint;
using MicroOndas.Application.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MicroOndas.Application
{
    partial class Default : Page
    {
        private bool isAquecendo
        {
            get { return (bool)(ViewState["Aquecendo"] ?? true); }
            set { ViewState["Aquecendo"] = value; }
        }
        private bool isPausado
        {
            get { return (bool)(ViewState["Pausado"] ?? false); }
            set { ViewState["Pausado"] = value; }
        }

        private bool isProgramaAquecimento
        {
            get { return (bool)(ViewState["ProgramaAquecimento"] ?? false); }
            set { ViewState["ProgramaAquecimento"] = value; }
        }

        private int Minuto
        {
            get { return (int)(ViewState["Minuto"] ?? 0); }
            set { ViewState["Minuto"] = value; }
        }
        private int Segundo
        {
            get { return (int)(ViewState["Segundo"] ?? 0); }
            set { ViewState["Segundo"] = value; }
        }
        private int Contador
        {
            get { return (int)(ViewState["Contador"] ?? 0); }
            set { ViewState["Contador"] = value; }
        }


        protected void Page_PreInit()
        {
            List<ProgramaAquecimentoFilter> programas = getProgramasAquecimento().Result;
            ProgramasPreAquecimento.Items.Add(new ListItem("Selecione uma opção", ""));
            foreach (var programa in programas)
            {
                ListItem listItem = new ListItem(programa.Nome, programa.Alimento);
                if (programa.isCustomizado)
                {
                    listItem.Attributes["style"] = "font-style: italic";
                    ProgramasPreAquecimento.Items.Add(listItem);
                }
                else
                {
                    ProgramasPreAquecimento.Items.Add(listItem);
                }
            }
        }

        protected void PreAquecimentoChanged(object sender, EventArgs e)
        {
            string programa = ProgramasPreAquecimento.Text;
            BuscarProgramaPreAquecimento(programa);
        }

        protected void Aquecimento(object sender, EventArgs e)
        {
            if (ProgramasPreAquecimento.SelectedIndex != 0)
            {
                isProgramaAquecimento = true;
            }


            if (isAquecendo)
            { IncrementarAquecimentoEmAndamento(); }
            PegaTempoAquecimento();

            isAquecendo = true;
            Timer1.Enabled = true;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            if (Segundo > 0)
            {
                Segundo--;
            }
            else if (Minuto > 0)
            {
                Minuto--;
                Segundo = 59;
            }

            var tempoCorrido = $"{Minuto:D2}:{Segundo:D2}";
            Tempo.Text = tempoCorrido;
            Contador++;
            if (Contador > int.Parse(Potencia.Text))
            { Contador = 0; labelTimer.Text += " "; }

            labelTimer.Text += ".";

            if (Minuto == 0 && Segundo == 0)
            {
                Timer1.Enabled = false;
                isAquecendo = false;
                isPausado = false;

                labelOut.Text = "Aquecimento concluído";
                labelTimer.Text = "";
                Tempo.Text = "";
            }
        }

        private void PegaTempoAquecimento()
        {
            if (String.IsNullOrEmpty(Tempo.Text))
            {
                Tempo.Text = "00:30";
            }

            String[] tempo = Tempo.Text.Split(':');
            Minuto = int.Parse(tempo[0]);
            Segundo = int.Parse(tempo[1]);
        }

        protected void PausarCancelar(object sender, EventArgs e)
        {
            if (isPausado)
            {
                Timer1.Enabled = false;
                Minuto = 0;
                Segundo = 0;

                Tempo.Text = "";
                Potencia.Text = "10";
                labelTimer.Text = "";
                labelOut.Text = "";
                ProgramasPreAquecimento.SelectedIndex = 0;

                isPausado = false;
            }
            else
            {
                Timer1.Enabled = !Timer1.Enabled;
                isPausado = true;
            }
        }

        private void IncrementarAquecimentoEmAndamento()
        {
            if (Timer1.Enabled && !isProgramaAquecimento)
            {
                String tempoUpdate = string.Empty;
                Segundo += 30;
                if (Segundo >= 60)
                {
                    Minuto += Segundo / 60;
                    Segundo = Segundo % 60;
                    if (Minuto >= 2 && Segundo > 0)
                    {
                        Minuto = 2;
                        Segundo = 0;
                    }
                }

                if (Segundo == 0)
                {
                    tempoUpdate = $"0{Minuto}:0{Segundo}";
                }
                else
                {
                    tempoUpdate = $"0{Minuto}:{Segundo}";
                }

                Tempo.Text = tempoUpdate;
            }
            else
            {
                Timer1.Enabled = true;
            }
        }

        private void BuscarProgramaPreAquecimento(string programaAquecimento)
        {
            List<ProgramaAquecimentoFilter> programas = getProgramasAquecimento().Result;
            bool programaEncontrado = false;
            foreach (var programa in programas)
            {
                if (programa.Alimento.Equals(programaAquecimento))
                {
                    programaEncontrado = true;
                    Tempo.Text = programa.Tempo;
                    labelOut.Text = programa.Instrucao;
                    Potencia.Text = programa.Potencia.ToString();

                    Tempo.ReadOnly = true;
                    Potencia.ReadOnly = true;
                }
            }

            if (!programaEncontrado)
            {
                Tempo.Text = "";
                Potencia.Text = "10";
                labelOut.Text = "";

                Tempo.ReadOnly = false;
                Potencia.ReadOnly = false;
            }
        }
 
        protected void AbrirModal(object sender, EventArgs e)
        {
            Response.Redirect("ModalCadastro.aspx");
        }

        private async Task<List<ProgramaAquecimentoFilter>> getProgramasAquecimento()
        {
            EndpointHelper helper = new EndpointHelper();
            string json = await helper.getProgramasAquecimento();
            return JsonConvert.DeserializeObject<List<ProgramaAquecimentoFilter>>(json);
        }
    }
}