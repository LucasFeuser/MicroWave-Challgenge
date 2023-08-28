using System;
using System.Web.UI;

namespace MicroOndas.Application.Views
{
    public partial class ModalCadastro : Page
    {

        protected void AdicionarNovoItemPreAquecimento(object sender, EventArgs e)
        {                      
        }

        protected void RetonarAquecimento(object sender, EventArgs e)
        {
            Response.Redirect("MicroOndas.aspx");
        }
    }
}