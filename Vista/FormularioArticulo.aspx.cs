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

        public bool eliminar;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["iD"] : "";
                Session.Add("id", id);


                CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                MarcaNegocio negocioMarca = new MarcaNegocio();
                ArticuloNegocio negocioArticulo = new ArticuloNegocio();

                try
                {
                    txbId.Enabled = false;
                    dllCategoria.DataSource = negocioCategoria.Listar();
                    dllCategoria.DataTextField = "Descripcion";
                    dllCategoria.DataValueField = "Id";
                    dllMarca.DataSource = negocioMarca.Listar();
                    dllMarca.DataTextField = "Descripcion";
                    dllMarca.DataValueField = "Id";
                    dllCategoria.DataBind();
                    dllMarca.DataBind();

                    if (id != "")
                    {
                        Articulo seleccionado = new Articulo();

                        seleccionado = (negocioArticulo.Listar(id))[0];

                        txbId.Text = seleccionado.Id.ToString();
                        txbCodigo.Text = seleccionado.Codigo;
                        txbNombre.Text = seleccionado.Nombre;
                        txbDescripcion.Text = seleccionado.Descripcion;
                        dllMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                        dllCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                        txbUrlImagen.Text = seleccionado.ImagenUrl;
                        txbPrecio.Text = seleccionado.Precio.ToString();
                        if (seleccionado.ImagenUrl != "" && seleccionado.ImagenUrl.ToLower().Contains("http"))
                            urlImagen.ImageUrl = seleccionado.ImagenUrl;
                        else
                            urlImagen.ImageUrl = "https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg";

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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                LogicaNegocio logicaNegocio = new LogicaNegocio();


                if (string.IsNullOrEmpty(txbCodigo.Text) || string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbDescripcion.Text) || string.IsNullOrEmpty(txbUrlImagen.Text) || string.IsNullOrEmpty(txbPrecio.Text))
                    return;
                if (logicaNegocio.hayLetras(txbPrecio.Text))
                    return;

                nuevo.Codigo = txbCodigo.Text;
                nuevo.Nombre = txbNombre.Text;
                nuevo.Descripcion = txbDescripcion.Text;
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(dllMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(dllCategoria.SelectedValue);
                nuevo.ImagenUrl = txbUrlImagen.Text;
                nuevo.Precio = int.Parse(txbPrecio.Text);


                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    negocio.Modificar(nuevo);
                    Session.Add("mensajeM", true);
                    Response.Redirect("ListaArticulos.aspx", false);
                }
                else
                {
                    negocio.Agregar(nuevo);
                    Session.Add("mensajeN", true);
                    Response.Redirect("ListaArticulos.aspx", false);
                }

                //System.Threading.Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.EliminarFisico(int.Parse(Request.QueryString["id"]));

            eliminar = true;
            Session.Add("mensajeE", eliminar);
            Session.Add("ArticuloEliminado", true);
            Response.Redirect("ListaArticulos.aspx");
        }
    }
}