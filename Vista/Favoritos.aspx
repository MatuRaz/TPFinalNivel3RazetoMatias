<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Vista.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Favoritos</h1>
    <asp:ScriptManager ID="scp1" runat="server" />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="rep1" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card border-dark card text-bg-light mb-3 me-2 shadow alert alert-dark" style="width: 18rem;">
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
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="col"></div>
    </div>
</asp:Content>
