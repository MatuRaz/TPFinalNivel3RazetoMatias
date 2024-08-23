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
    <div class="conteiner" style="display: grid; place-items: center">
        <div class="row mt-5 row-cols-sm-auto">
            <div class="col mt-4">
                <div class="col">
                    <div class="col">
                        <asp:Image ID="imgArticulo" Width="300px" runat="server" />
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
                        <div class="col mb-3">
                            <label class="form-check-label" for="flexCheckDefault">⭐ Agregar a Favorito</label>
                            <asp:CheckBox ID="chkFavorito" Text="" runat="server" />
                        </div>
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
    </div>
</asp:Content>
