<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Vista.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font: 12px;
        }
    </style>
    <script>     
        function Validar() {
            const txbApellido = document.getElementById("txbApellido");
            const txbNombre = document.getElementById("txbNombre");
            const txbImagen = document.getElementById("txbImagen");

            if (txbApellido.value == "" || txbNombre.value == "" || txbImagen.value == "") {
                if (txbApellido.value == "") {
                    txbApellido.classList.add("is-invalid");
                    txbApellido.classList.remove("is-valid");
                }
                else {
                    txbApellido.classList.remove("is-invalid");
                    txbApellido.classList.add("is-valid");
                }

                if (txbNombre.value == "") {
                    txbNombre.classList.add("is-invalid");
                    txbNombre.classList.remove("is-valid");
                }
                else {
                    txbNombre.classList.remove("is-invalid");
                    txbNombre.classList.add("is-valid");
                }

                if (txbImagen.value == "") {
                    txbImagen.classList.add("is-invalid");
                    txbImagen.classList.remove("is-valid");
                }
                else {
                    txbImagen.classList.remove("is-invalid");
                    txbImagen.classList.add("is-valid");
                }
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h3>Mi Perfil</h3>
        <%-- poner si es admin--%>
        <div class="col-6">
            <div class="mb-3">
                <label for="txbEmail" class="form-label">Email</label>
                <asp:TextBox ID="txbEmail" CssClass="form-control" placeholder="name@example.com" TextMode="Email" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txbNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txbNombre" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txbApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txbApellido" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
            <div class="col mt-2">
                <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" OnClientClick="return Validar()" OnClick="btnGuardar_Click" runat="server" />
            </div>
        </div>
        <div class="col">
            <div class="mb-3">
                <label for="formFile" class="form-label">Imagen</label>
                <input id="txbImagen" ClientIDMode="Static" class="form-control" type="file" runat="server">
                <asp:Image ID="imgPerfil" ImageUrl="" Width="400px" CssClass="mt-2" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
