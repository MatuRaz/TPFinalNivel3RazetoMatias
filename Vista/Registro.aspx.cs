using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            EmailServices emailServices = new EmailServices();
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario nuevo = new Usuario();

            try
            {
                nuevo.Email = txbEmail.Text;
                nuevo.Contraseña = txbContraseña.Text;

                if (!negocio.MailCheck(nuevo.Email))
                {
                    negocio.Agregar(nuevo);
                    Session.Add("Usuario", nuevo);

                    emailServices.ArmarCorreo(nuevo.Email, "Bienvenido", "Bienvenido a Tecno Store");
                    emailServices.inviarEmail();

                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Email en uso, pruebe con otro");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }


    }
}