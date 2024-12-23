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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario user = (Usuario)Session["Usuario"];
            if (SeguridadNegocio.SesionActiva(user))
            {
                if (!string.IsNullOrEmpty(user.urlImagenPerfil))
                    imgPerfil.ImageUrl = "~/Images/" + user.urlImagenPerfil + "?" + DateTime.Now;
                else
                    imgPerfil.ImageUrl = "https://th.bing.com/th/id/R.3708994bdca38cd8dbea509f233f3cf4?rik=p1v2LkWH17fSEg&pid=ImgRaw&r=0";
                
                lblMail.Text = user.Email;
            }
            else
            {
                imgPerfil.ImageUrl = "https://th.bing.com/th/id/R.3708994bdca38cd8dbea509f233f3cf4?rik=p1v2LkWH17fSEg&pid=ImgRaw&r=0";
                if (!(Page is Login || Page is Default || Page is Registro || Page is Error))
                    Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void btnCerrarsesion_Click(object sender, EventArgs e)
        {
            Session.Remove("Usuario");
            Response.Redirect("Login.aspx");
        }
    }
}