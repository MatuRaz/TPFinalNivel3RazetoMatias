<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Vista.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .lead {
            font-size: 1.80rem;
            font-weight: 500;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scm1" runat="server" />
    <div class="conteiner" style="display: grid; place-items: center">
        <div class="row mt-5 row-cols-sm-auto">
            <div class="col mt-4">
                <div class="col">
                    <div class="col">
                        <asp:Image ID="imgArticulo" Style="height: 400px; width: 400px" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col mt-5">
                <asp:Label ID="lblNombre" CssClass="lead" Text="text" runat="server" />
                <div class="col mt-4 shadow alert alert-dark">
                    <label class="me-0">Codigo:  </label>
                    <asp:Label class="me-2" ID="lblCodigo" Text="hola" runat="server" />
                    <label class="me-0">Categoria: </label>
                    <asp:Label class="me-2" ID="lblCategoria" Text="text" runat="server" />
                    <label class="me-0">Marca: </label>
                    <asp:Label ID="lblMarca" Text="text" runat="server" />
                </div>
                <div class="col border-top">
                    <div class="col mt-1 ">
                        <label>Descripcion:</label>
                    </div>
                    <div class="col">
                        <asp:Label ID="lblDescripcion" Text="text" runat="server" />
                    </div>
                    <div class="mt-1">
                    </div>
                    <div class="col">
                        <%if (Negocio.SeguridadNegocio.SesionActiva(Session["Usuario"]))
                            {%>
                        <div class="col mb-3">
                            <label class="form-check-label" for="chkFavorito">⭐ Agregar a Favorito</label>
                            <asp:CheckBox ID="chkFavorito" OnCheckedChanged="chkFavorito_CheckedChanged" AutoPostBack="true" Text="" runat="server" />
                        </div>
                        <%} %>
                    </div>
                </div>
                <div class="col mt-5 shadow alert alert-dark">
                    <label class="me-2">Precio Web: </label>
                    <asp:Label ID="lblPrecio" Text="text" runat="server" />
                </div>
            </div>
        </div>
        <div class="col">
            <label class="me-4">Garantia de 1 año</label><label class="me-4">Caja y accesorios incluidos</label><label>Cuenta con seguro de envio</label>
        </div>
        <div class="col mt-5">
            <h5>Productos Relacionados:</h5>
        </div>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="carouselExample" class="carousel carousel-dark slide">
                    <div class="carousel-inner">
                        <div class="carousel-item active" style="display: flex">
                            <asp:Repeater ID="rep1" runat="server">
                                <ItemTemplate>
                                    <div class="card border-dark card text-bg-light mb-3 me-2 shadow alert alert-dark" style="height: 23rem; width: 200px">
                                        <div style="display: grid; grid-auto-rows: 150px;">
                                            <img src="<%# Eval("ImagenUrl")%>" class="card-img-top" height="150" alt="Articulo">
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col mb-3">
                                                    <div style="display: grid; grid-auto-rows: 60px;">
                                                        <h5 class="card-title"><%# Eval("Nombre")%></h5>
                                                    </div>
                                                    <p class="card-text mb-4">Marca: <%# Eval("Marca") %></p>
                                                    <p class="card-text blockquote-footer">Precio: <%# Eval("Precio") %></p>
                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:Button Text="Detalle" CssClass="btn btn-primary" ID="DetalleId" CommandArgument='<%# Eval("Id")%>' CommandName="ArticuloId" OnClick="DetalleId_Click" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>


                    <div class="col" style="display: grid; place-items: center;">
                        <div class="col" style="display: flex">
                            <asp:Button ID="brnPrevio" Text="⬅️" CssClass="btn" OnClick="brnPrevio_Click" runat="server" />
                            <asp:Button ID="btnSiguiente" Text="➡️" CssClass="btn" OnClick="btnSiguiente_Click" runat="server" />
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>





    <%--        <div class="row row-cols-1 row-cols-md-4 g-0">
            <asp:Repeater ID="rep1" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card border-dark card text-bg-light mb-3 me-2 shadow alert alert-dark" style="height: 20rem">
                            <img src="<%# Eval("ImagenUrl")%>" class="card-img-top" height="150" alt="Articulo">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col mb-3">
                                        <h5 class="card-title"><%# Eval("Nombre")%></h5>
                                        <p class="card-text mb-4">Marca: <%# Eval("Marca") %></p>
                                        <p class="card-text blockquote-footer">Precio: <%# Eval("Precio") %></p>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:Button Text="Detalle" CssClass="btn btn-primary" ID="DetalleId" CommandArgument='<%# Eval("Id")%>' CommandName="ArticuloId" OnClick="DetalleId_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>--%>
</asp:Content>
