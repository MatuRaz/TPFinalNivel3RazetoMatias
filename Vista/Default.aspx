<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vista.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scp1" runat="server" />


    <div class="row">
        <div class="col-md-3 mt-20">
            <h3 class="mb-3">Categorias</h3>
            <asp:TextBox ID="txbFiltro" CssClass="form-label form-control" placeholder="Buscá Tu Producto..." runat="server" />
            <div class="col mb-3">
                <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" Text="Buscar" CssClass="btn btn-primary" runat="server" />
            </div>
            <div class="list-group shadow">

                <asp:Button ID="btnCelulares" OnClick="btnCelulares_Click" Text="Celulares" CssClass="list-group-item list-group-item-action bg-body-secondary" runat="server" />
                <asp:Button ID="btnTelevisores" OnClick="btnTelevisores_Click" Text="Televisores" CssClass="list-group-item list-group-item-action bg-body-secondary" runat="server" />
                <asp:Button ID="btnMedia" OnClick="btnMedia_Click" Text="Media" CssClass="list-group-item list-group-item-action bg-body-secondary" runat="server" />
                <asp:Button ID="btnAudio" OnClick="btnAudio_Click" Text="Audio" CssClass="list-group-item list-group-item-action bg-body-secondary" runat="server" />
            </div>
        </div>


        <div class="col">
            <%if (SinResultado)
                {%>
            <div class="content mb-3" style="display: grid; place-items: center">
                <h5 class="mb-3">No hay resultados.</h5>
                <h6 class="mb-3">Por favor intenta con otro criterio.</h6>
            </div>
            <% } %>

            <%else
                {%>
            <div class="content" style="display: grid; place-items: center">
                <h3 class="mb-3">Productos</h3>
            </div>
            <%} %>

            <div class="row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater ID="rep1" runat="server">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card text-bg-light mb-3 shadow alert alert-dark" style="width: 18rem;">
                                <img src="<%# Eval("ImagenUrl")%>" class="card-img-top" height="250" alt="Articulo">
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
                                        <%--<div class="col" style="display: grid; place-items: flex-end">
                                            <asp:Button Text="Comprar" CssClass="btn btn-secondary" runat="server" />
                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="col"></div>
            </div>
        </div>

    </div>
</asp:Content>
