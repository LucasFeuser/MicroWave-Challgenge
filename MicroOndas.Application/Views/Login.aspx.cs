using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MicroOndas.Application.Views
{
    public partial class Login :Page
    {
        private const string BackendEndpoint = "https://seu-backend-api.com/api/authenticate";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUser(object sender, EventArgs e)
        {
            bool isAuthenticated = AuthenticateUser(txtUsuario.Text, txtPassword.Text).Result;

            if (isAuthenticated)
            {
                Session["User"] = txtUsuario.Text;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblMessage.Text = "Credenciais inválidas.";
            }
        }

        private async Task<bool> AuthenticateUser(string usuario, string password)
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("usuario", usuario),
                    new KeyValuePair<string, string>("password", password)
                });

                var response = await client.PostAsync(BackendEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}