using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Detalle : System.Web.UI.Page
    {
        List<Articulo> listaArticulo;
        List<Articulo> ListaNueva;
        List<Articulo> Lista3 = new List<Articulo>();


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

                    listaArticulo = (List<Articulo>)Session["ListaArticulo"];
                    ListaNueva = listaArticulo.FindAll(x => x.Categoria.Descripcion == articulo.Categoria.Descripcion);
                    int articuloBorrar = ListaNueva.FindIndex(x => x.Id == articulo.Id);
                    ListaNueva.Remove(ListaNueva[articuloBorrar]);
                    Session.Add("ListaNueva", ListaNueva);
                    ListaNueva = (List<Articulo>)Session["ListaNueva"];

                    if (ListaNueva.Count != 0)
                    {
                        if (ListaNueva.Count >= 3)
                        {
                            Lista3.Add(ListaNueva[0]);
                            Lista3.Add(ListaNueva[1]);
                            Lista3.Add(ListaNueva[2]);
                        }
                        else if (ListaNueva.Count == 2)
                        {
                            Lista3.Add(ListaNueva[0]);
                            Lista3.Add(ListaNueva[1]);
                        }
                        else if (ListaNueva.Count == 1)
                        {
                            Lista3.Add(ListaNueva[0]);
                        }
                        rep1.DataSource = Lista3;
                        rep1.DataBind();
                    }
                    if (ListaNueva.Count < 6)
                        Session.Add("Lista3", null);
                    else
                        Session.Add("Lista3", Lista3[1]);
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
        }


        protected void btnSiguiente_Click(object sender, EventArgs e)
        {

            if (Session["Lista3"] != null)
            {
                int contador = 0;

                Articulo articulo = (Articulo)Session["Lista3"];
                ListaNueva = (List<Articulo>)Session["ListaNueva"];
                int indice = ListaNueva.FindIndex(x => x.Id == articulo.Id);

                contador = indice + 1;

                int resto = ListaNueva.Count % 3;

                if (contador < (((ListaNueva.Count) - 1) - resto))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (contador < (((ListaNueva.Count) - 1) - resto))
                        {
                            contador++;
                            Lista3.Add(ListaNueva[contador]);

                        }
                    }
                    rep1.DataSource = Lista3;
                    rep1.DataBind();
                    Session.Add("Lista3", Lista3[1]);
                }
            }
        }
        protected void brnPrevio_Click(object sender, EventArgs e)
        {
            if (Session["Lista3"] != null)
            {
                int contador = 0;

                Articulo articulo = (Articulo)Session["Lista3"];
                ListaNueva = (List<Articulo>)Session["ListaNueva"];
                int indice = ListaNueva.FindIndex(x => x.Id == articulo.Id);

                contador = indice - 1;

                int resto = ListaNueva.Count % 3;

                if (contador != 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (contador != 0)
                        {
                            contador--;
                            Lista3.Add(ListaNueva[contador]);

                        }
                    }
                    Lista3.Reverse();
                    rep1.DataSource = Lista3;
                    rep1.DataBind();
                    Session.Add("Lista3", Lista3[1]);
                }
            }
        }

        protected void DetalleId_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                string id = ((Button)sender).CommandArgument;

                seleccionado = (negocio.Listar(id))[0];
                Session.Add("articulo", seleccionado);

                Response.Redirect("Detalle.aspx?=id" + id, false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}