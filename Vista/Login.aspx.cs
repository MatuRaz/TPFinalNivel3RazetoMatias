using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Vista
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                if (string.IsNullOrEmpty(txbEmail.Text) || string.IsNullOrEmpty(txbContraseña.Text))
                    return;

                user.Email = txbEmail.Text;
                user.Contraseña = txbContraseña.Text;

                if (negocio.Logear(user))
                {
                    Session.Add("Usuario", user);
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    Session.Add("Error", "User o pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }




    }
}