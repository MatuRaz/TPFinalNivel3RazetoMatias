using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Vista
{
    public partial class Default : System.Web.UI.Page
    {
        public bool SinResultado { get; set; }
        List<Articulo> ListaArticulos;
        List<Articulo> FiltroRapido;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();


            try
            {
                Session.Add("ListaArticulo", negocio.Listar());
                ListaArticulos = (List<Articulo>)Session["ListaArticulo"];
                if (!IsPostBack)
                {
                    rep1.DataSource = ListaArticulos;
                    rep1.DataBind();
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {


            try
            {
                Session.Remove("ListaArticulosCategorias");
                string filtro = txbFiltro.Text;
                FiltroRapido = ListaArticulos.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()));
                Session.Add("ListaArticulosFiltro", FiltroRapido);

                rep1.DataSource = FiltroRapido;
                rep1.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            if (FiltroRapido.Count == 0)
            {
                SinResultado = true;
                lblResultado.Text = "'" + txbFiltro.Text + "'";
            }

        }

        protected void btnCelulares_Click(object sender, EventArgs e)
        {

            FiltroRapido = ListaArticulos.FindAll(x => x.Categoria.Descripcion == "Celulares");
            Session.Add("ListaArticulosCategorias", FiltroRapido);

            rep1.DataSource = FiltroRapido;
            rep1.DataBind();
        }

        protected void btnTelevisores_Click(object sender, EventArgs e)
        {

            FiltroRapido = ListaArticulos.FindAll(x => x.Categoria.Descripcion == "Televisores");
            Session.Add("ListaArticulosCategorias", FiltroRapido);

            rep1.DataSource = FiltroRapido;
            rep1.DataBind();
        }

        protected void btnMedia_Click(object sender, EventArgs e)
        {

            FiltroRapido = ListaArticulos.FindAll(x => x.Categoria.Descripcion == "Media");
            Session.Add("ListaArticulosCategorias", FiltroRapido);

            rep1.DataSource = FiltroRapido;
            rep1.DataBind();
        }

        protected void btnAudio_Click(object sender, EventArgs e)
        {

            FiltroRapido = ListaArticulos.FindAll(x => x.Categoria.Descripcion == "Audio");
            Session.Add("ListaArticulosCategorias", FiltroRapido);

            rep1.DataSource = FiltroRapido;
            rep1.DataBind();
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

        protected void btnOMenor_Click(object sender, EventArgs e)
        {
            List<Articulo> listaFiltroRapido = (List<Articulo>)Session["ListaArticulosFiltro"];
            List<Articulo> lista = (List<Articulo>)Session["ListaArticulosCategorias"];

            if (lista != null)
            {
                FiltroRapido = lista.OrderBy(x => x.Precio).ToList();
                rep1.DataSource = FiltroRapido;
                rep1.DataBind();

            }
            else if (listaFiltroRapido != null)
            {
                FiltroRapido = listaFiltroRapido.OrderBy(x => x.Precio).ToList();
                rep1.DataSource = FiltroRapido;
                rep1.DataBind();
            }
            else
            {
                FiltroRapido = ListaArticulos.OrderBy(x => x.Precio).ToList();
                rep1.DataSource = FiltroRapido;
                rep1.DataBind();
            }

        }

        protected void btnOMayor_Click(object sender, EventArgs e)
        {
            List<Articulo> listaFiltroRapido = (List<Articulo>)Session["ListaArticulosFiltro"];
            List<Articulo> listaCategoria = (List<Articulo>)Session["ListaArticulosCategorias"];

            if (listaCategoria != null)
            {
                FiltroRapido = listaCategoria.OrderByDescending(x => x.Precio).ToList();
                rep1.DataSource = FiltroRapido;
                rep1.DataBind();

            }
            else if (listaFiltroRapido != null)
            {
                FiltroRapido = listaFiltroRapido.OrderByDescending(x => x.Precio).ToList();
                rep1.DataSource = FiltroRapido;
                rep1.DataBind();
            }
            else
            {
                FiltroRapido = ListaArticulos.OrderByDescending(x => x.Precio).ToList();
                rep1.DataSource = FiltroRapido;
                rep1.DataBind();
            }
        }
    }
}