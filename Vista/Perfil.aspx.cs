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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario user = (Usuario)Session["Usuario"];
                if (SeguridadNegocio.SesionActiva(user))
                {
                    txbNombre.Text = user.Nombre;
                    txbApellido.Text = user.Apellido;
                    txbEmail.Text = user.Email;
                    txbEmail.Enabled = false;

                    if (!string.IsNullOrEmpty(user.urlImagenPerfil))
                        imgPerfil.ImageUrl = "~/Images/" + user.urlImagenPerfil + "?" + DateTime.Now;
                    else
                        imgPerfil.ImageUrl = "https://th.bing.com/th/id/R.3708994bdca38cd8dbea509f233f3cf4?rik=p1v2LkWH17fSEg&pid=ImgRaw&r=0";

                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio Negocio = new UsuarioNegocio();
            Usuario user = new Usuario();

            if (string.IsNullOrEmpty(txbApellido.Text) || string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbImagen.Value.ToString()))
                return;

            user = (Usuario)Session["Usuario"];

            if (txbImagen.PostedFile.FileName != "")
            {
                string ruta = Server.MapPath("./Images/");
                txbImagen.PostedFile.SaveAs(ruta + "Perfil-" + user.Id + ".jpg");
                user.urlImagenPerfil = "Perfil-" + user.Id + ".jpg";
            }
            else
                user.urlImagenPerfil = null;

            user.Nombre = txbNombre.Text;
            user.Apellido = txbApellido.Text;

            Negocio.Actualizar(user);
        }
    }
}