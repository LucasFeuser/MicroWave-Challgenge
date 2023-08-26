using System;
using System.Text;
using System.Threading;
using System.Web.UI;

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


        protected void Aquecimento(object sender, EventArgs e)
        {
            labelOut.Text = "";
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
            if(Contador > int.Parse(Potencia.Text)) 
            { Contador = 0; labelOut.Text += " "; }

            labelOut.Text += ".";

            if (Minuto == 0 && Segundo == 0)
            {
                Timer1.Enabled = false;
                isAquecendo = false;
                isPausado = false;

                labelOut.Text = "Aquecimento concluído";
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
                labelOut.Text = "";
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
            if (Timer1.Enabled)
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
    }
}