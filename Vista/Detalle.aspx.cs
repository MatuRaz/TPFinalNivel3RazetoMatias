using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["articulo"] == null)
                    Response.Redirect("Default.aspx");

                try
                {
                    Articulo articulo = (Articulo)Session["articulo"];

                    if (articulo.ImagenUrl == "" || articulo.ImagenUrl == null)
                        imgArticulo.ImageUrl = "https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg";
                    else
                        imgArticulo.ImageUrl = articulo.ImagenUrl;

                    lblNombre.Text = articulo.Nombre;
                    lblCodigo.Text = articulo.Codigo;
                    lblCategoria.Text = articulo.Categoria.Descripcion;
                    lblMarca.Text = articulo.Marca.Descripcion;
                    lblDescripcion.Text = articulo.Descripcion;
                    lblPrecio.Text = articulo.Precio.ToString();

                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }

            }
        }
    }
}