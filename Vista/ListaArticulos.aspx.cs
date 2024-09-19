using Dominio;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        public bool SinResultado { get; set; }
        List<Articulo> ListaArticulo;
        List<Articulo> FiltroRapido;
        List<Articulo> FiltroAvanzado;
        public bool chkNombre;
        public bool chkCodigo;
        public bool chkCategoria;
        public bool chkMarca;
        public bool chkPrecio;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (chkFiltroAvanzado.Checked)
            {
                txbFiltro.Enabled = false;
            }
            else
                txbFiltro.Enabled = true;

            if (chkFiltros.Checked && dllCampo.Text == "Categoria" || chkFiltros.Checked && dllCampo.Text == "Marca")
            {
                txbFiltroAvanzado.Enabled = false;
            }
            else
                txbFiltroAvanzado.Enabled = true;

            if (chkFiltros.Checked)
            {
                if (Session["chkNombre"] != null)
                {
                    chkNombre = (bool)Session["chkNombre"];
                }
                if (Session["chkCodigo"] != null)
                {
                    chkCodigo = (bool)Session["chkCodigo"];
                }
                if (Session["chkCategoria"] != null)
                {
                    chkCategoria = (bool)Session["chkCategoria"];
                }
                if (Session["chkMarca"] != null)
                {
                    chkMarca = (bool)Session["chkMarca"];
                }
                if (Session["chkPrecio"] != null)
                {
                    chkPrecio = (bool)Session["chkPrecio"];
                }
            }

            if (!IsPostBack)
            {
                try
                {
                    Session.Remove("chkNombre");
                    Session.Remove("chkCodigo");
                    Session.Remove("chkCategoria");
                    Session.Remove("chkMarca");
                    Session.Remove("chkPrecio");

                    Session.Add("ListaArticulos", negocio.Listar());
                    ListaArticulo = (List<Articulo>)Session["ListaArticulos"];
                    gvArticulos.DataSource = ListaArticulo;
                    gvArticulos.DataBind();
                    dllCriterio.Enabled = false;
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }
        }


        protected void gvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void gvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["FiltroAvanzado"] != null)
            {
                gvArticulos.DataSource = Session["FiltroAvanzado"];
                gvArticulos.PageIndex = e.NewPageIndex;
                gvArticulos.DataBind();
            }
            else if (Session["ListaArticulos"] != null)
            {
                gvArticulos.DataSource = Session["ListaArticulos"];
                gvArticulos.PageIndex = e.NewPageIndex;
                gvArticulos.DataBind();
            }
        }

        protected void txbFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ListaArticulo = (List<Articulo>)Session["ListaArticulos"];

                string filtro = txbFiltro.Text;
                FiltroRapido = ListaArticulo.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()));

                gvArticulos.DataSource = FiltroRapido;
                gvArticulos.DataBind();

                if (FiltroRapido.Count == 0)
                {
                    SinResultado = true;
                    lblResultado.Text = "'" + txbFiltro.Text + "'";
                }
                txbFiltro.Text = "";
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void dllCampo_TextChanged(object sender, EventArgs e)
        {
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();

            if (dllCampo.Text == "Categoria")
            {
                dllCriterio.Enabled = true;
                dllCriterio.DataSource = negocioCategoria.Listar();
                dllCriterio.DataBind();

            }
            else if (dllCampo.Text == "Marca")
            {
                dllCriterio.Enabled = true;
                dllCriterio.DataSource = negocioMarca.Listar();
                dllCriterio.DataBind();

            }
            else if (dllCampo.Text == "Precio")
            {
                dllCriterio.Enabled = true;
                dllCriterio.Items.Clear();
                dllCriterio.Items.Add("Menor");
                dllCriterio.Items.Add("Mayor");
                dllCriterio.Items.Add("Igual");

            }
            else
            {
                dllCriterio.Items.Clear();
                dllCriterio.Enabled = false;
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                FiltroAvanzado = (List<Articulo>)Session["ListaArticulos"];

                if (chkFiltros.Checked)
                {
                    if (chkNombre.ToString() != null)
                    {
                        FiltroAvanzado = negocio.FiltroAvanzado("Nombre", "", lblNombre.Text);
                    }
                    if (Session["chkCodigo"] != null)
                    {
                        FiltroAvanzado = FiltroAvanzado.FindAll(x => x.Codigo.ToLower() == lblCodigo.Text);
                    }
                    if (Session["chkCategoria"] != null)
                    {
                        FiltroAvanzado = FiltroAvanzado.FindAll(x => x.Categoria.ToString() == (string)Session["dllCategoria"]);

                    }
                    if (Session["chkMarca"] != null)
                    {
                        FiltroAvanzado = FiltroAvanzado.FindAll(x => x.Marca.ToString() == (string)Session["dllMarca"]);

                    }
                    if (Session["chkPrecio"] != null)
                    {
                        if ((string)Session["dllPrecio"] == "Igual")
                            FiltroAvanzado = FiltroAvanzado.FindAll(x => x.Precio.ToString() == (string)Session["txbFiltroPrecio"]);
                        else if ((string)Session["dllPrecio"] == "Menor")
                        {
                            if ((string)Session["txbFiltroPrecio"] != "")
                            {
                                string value = (string)Session["txbFiltroPrecio"];
                                int n = Convert.ToInt32(value);
                                FiltroAvanzado = FiltroAvanzado.FindAll(x => x.Precio < n);
                                FiltroAvanzado = FiltroAvanzado.OrderBy(x => x.Precio).ToList();
                            }
                            else
                                FiltroAvanzado = FiltroAvanzado.OrderBy(x => x.Precio).ToList();
                        }
                        else if ((string)Session["dllPrecio"] == "Mayor")
                        {
                            if ((string)Session["txbFiltroPrecio"] != "")
                            {
                                string value = (string)Session["txbFiltroPrecio"];
                                int n = Convert.ToInt32(value);
                                FiltroAvanzado = FiltroAvanzado.FindAll(x => x.Precio > n);
                                FiltroAvanzado = FiltroAvanzado.OrderByDescending(x => x.Precio).ToList();
                            }
                            else
                                FiltroAvanzado = FiltroAvanzado.OrderByDescending(x => x.Precio).ToList();
                        }
                    }
                }
                else
                {
                    if (dllCriterio.Text == "Mayor" && txbFiltroAvanzado.Text == "")
                        txbFiltroAvanzado.Text = "0";
                    else if (dllCriterio.Text == "Menor" && txbFiltroAvanzado.Text == "")
                        txbFiltroAvanzado.Text = "2147483647";


                    FiltroAvanzado = negocio.FiltroAvanzado(dllCampo.Text, dllCriterio.Text, txbFiltroAvanzado.Text);
                    if (dllCriterio.Text == "Menor")
                        FiltroAvanzado = FiltroAvanzado.OrderBy(x => x.Precio).ToList();
                    else if (dllCriterio.Text == "Mayor")
                        FiltroAvanzado = FiltroAvanzado.OrderByDescending(x => x.Precio).ToList();
                }

                Session.Add("FiltroAvanzado", FiltroAvanzado);

                gvArticulos.DataSource = FiltroAvanzado;
                gvArticulos.DataBind();

                if (FiltroAvanzado.Count == 0)
                {
                    SinResultado = true;
                    lblResultado.Text = "'" + txbFiltroAvanzado.Text + "'";
                }

                txbFiltroAvanzado.Text = "";
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }



        }
        protected void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            if (dllCampo.Text == "Nombre")
            {
                Session.Add("lblNombre", lblNombre.Text);
                lblNombre.Text = (string)Session["lblNombre"];
                chkNombre = true;
                Session.Add("chkNombre", chkNombre);
                if (!string.IsNullOrEmpty(txbFiltroAvanzado.Text))
                {
                    lblNombre.Text = txbFiltroAvanzado.Text;
                }
                else
                    lblNombre.Text = txbFiltroAvanzado.Text;
            }
            else if (dllCampo.Text == "Codigo")
            {
                Session.Add("lblCodigo", lblCodigo.Text);
                lblCodigo.Text = (string)Session["lblCodigo"];
                chkCodigo = true;
                Session.Add("chkCodigo", chkCodigo);
                if (!string.IsNullOrEmpty(txbFiltroAvanzado.Text))
                    lblCodigo.Text = txbFiltroAvanzado.Text;
                else
                    lblNombre.Text = txbFiltroAvanzado.Text;
            }
            else if (dllCampo.Text == "Categoria")
            {
                Session.Add("lblCategoria", lblCategoria.Text);
                lblCategoria.Text = (string)Session["lblCategoria"];
                chkCategoria = true;
                Session.Add("chkCategoria", chkCategoria);
                Session.Add("dllCategoria", dllCriterio.Text);
                lblCategoria.Text = dllCriterio.Text;
            }
            else if (dllCampo.Text == "Marca")
            {
                Session.Add("lblMarca", lblMarca.Text);
                lblMarca.Text = (string)Session["lblMarca"];
                chkMarca = true;
                Session.Add("chkMarca", chkMarca);
                Session.Add("dllMarca", dllCriterio.Text);
                lblMarca.Text = dllCriterio.Text;
            }
            else if (dllCampo.Text == "Precio")
            {
                Session.Add("lblPrecio", lblPrecio.Text);
                lblPrecio.Text = (string)Session["lblPrecio"];
                chkPrecio = true;
                Session.Add("chkPrecio", chkPrecio);
                Session.Add("dllPrecio", dllCriterio.Text);
                Session.Add("txbFiltroPrecio", txbFiltroAvanzado.Text);
                lblPrecio.Text = dllCriterio.Text + " a " + (string)Session["txbFiltroPrecio"];
            }
            Session.Add("txbFiltroAvanzado", txbFiltroAvanzado.Text);
            txbFiltroAvanzado.Text = "";
        }

        protected void btnEFNombre_Click(object sender, EventArgs e)
        {
            Session.Remove("chkNombre");
            chkNombre = false;
        }

        protected void btnEFCodigo_Click(object sender, EventArgs e)
        {
            Session.Remove("chkCodigo");
            chkCodigo = false;
        }

        protected void btnEFCategtoria_Click(object sender, EventArgs e)
        {
            Session.Remove("chkCategoria");
            chkCategoria = false;
        }

        protected void btnEFMarca_Click(object sender, EventArgs e)
        {
            Session.Remove("chkMarca");
            chkMarca = false;
        }

        protected void btnEFPrecio_Click(object sender, EventArgs e)
        {
            Session.Remove("chkPrecio");
            chkPrecio = false;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioArticulo.aspx");
        }
    }
}
