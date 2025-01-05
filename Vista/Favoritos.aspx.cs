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

    public partial class Favoritos : System.Web.UI.Page
    {
        List<Favorito> ListaFavoritos;
        List<Articulo> ListaArticulos;
        List<Articulo> FiltroRapido;
        List<Articulo> listaNueva = new List<Articulo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocioA = new ArticuloNegocio();
            if (!SeguridadNegocio.SesionActiva(Session["Usuario"]))
                Response.Redirect("Login.aspx");
            FavoritoNegocio negocio = new FavoritoNegocio();
            try
            {
                Usuario user = (Usuario)Session["Usuario"];


                if (!IsPostBack)
                {
                    ListaFavoritos = negocio.Listar(user.Id);
                    ListaArticulos = negocioA.Listar();
                    for (int i = 0; i < ListaFavoritos.Count; i++)
                    {
                        FiltroRapido = ListaArticulos.FindAll(x => x.Id == ListaFavoritos[i].IdArticulo);
                        if (FiltroRapido.Count != 0)
                            listaNueva.Add(FiltroRapido[0]);
                    }




                    rep1.DataSource = listaNueva;
                    rep1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
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
