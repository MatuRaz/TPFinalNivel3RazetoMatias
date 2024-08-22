﻿using System;
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
                if (!IsPostBack)
                {
                    Session.Add("ListaArticulo", negocio.Listar());
                    rep1.DataSource = Session["ListaArticulo"];
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
            ListaArticulos = (List<Articulo>)Session["ListaArticulo"];

            try
            {
                string filtro = txbFiltro.Text;
                FiltroRapido = ListaArticulos.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()));

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

            }

        }

        protected void btnCelulares_Click(object sender, EventArgs e)
        {
            ListaArticulos = (List<Articulo>)Session["ListaArticulo"];
            FiltroRapido = ListaArticulos.FindAll(x => x.Categoria.Descripcion == "Celulares");


            rep1.DataSource = FiltroRapido;
            rep1.DataBind();
        }

        protected void btnTelevisores_Click(object sender, EventArgs e)
        {
            ListaArticulos = (List<Articulo>)Session["ListaArticulo"];
            FiltroRapido = ListaArticulos.FindAll(x => x.Categoria.Descripcion == "Televisores");


            rep1.DataSource = FiltroRapido;
            rep1.DataBind();
        }

        protected void btnMedia_Click(object sender, EventArgs e)
        {
            ListaArticulos = (List<Articulo>)Session["ListaArticulo"];
            FiltroRapido = ListaArticulos.FindAll(x => x.Categoria.Descripcion == "Media");


            rep1.DataSource = FiltroRapido;
            rep1.DataBind();
        }

        protected void btnAudio_Click(object sender, EventArgs e)
        {
            ListaArticulos = (List<Articulo>)Session["ListaArticulo"];
            FiltroRapido = ListaArticulos.FindAll(x => x.Categoria.Descripcion == "Audio");


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
    }
}