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
    public partial class FromularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                MarcaNegocio negocioMarca = new MarcaNegocio();
                ArticuloNegocio negocioArticulo = new ArticuloNegocio();

                try
                {
                    txbId.Enabled = false;
                    dllCategoria.DataSource = negocioCategoria.Listar();
                    dllMarca.DataSource = negocioMarca.Listar();
                    dllCategoria.DataBind();
                    dllMarca.DataBind();


                    string id = Request.QueryString["id"] != null ? Request.QueryString["iD"] : "";

                    if (id != "")
                    {
                        Articulo seleccionado = new Articulo();

                        seleccionado = (negocioArticulo.Listar(id))[0];

                        txbId.Text = seleccionado.Id.ToString();
                        txbCodigo.Text = seleccionado.Codigo;
                        txbNombre.Text = seleccionado.Nombre;
                        txbDescripcion.Text = seleccionado.Descripcion;
                        dllMarca.Text = seleccionado.Marca.Descripcion.ToString();
                        dllCategoria.Text = seleccionado.Categoria.Descripcion.ToString();
                        txbUrlImagen.Text = seleccionado.ImagenUrl;
                        txbPrecio.Text = seleccionado.Precio.ToString();

                        lblEliminar.Text = txbNombre.Text;
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
}