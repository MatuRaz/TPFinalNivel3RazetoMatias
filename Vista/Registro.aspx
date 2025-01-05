<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Vista.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font: 12px;
        }
    </style>
    <script>     
        function Validar() {
            const txbContraseña = document.getElementById("txbContraseña");
            const txbEmail = document.getElementById("txbEmail");

            if (txbContraseña.value == "" || txbEmail.value == "") {
                if (txbContraseña.value == "") {
                    txbContraseña.classList.add("is-invalid");
                    txbContraseña.classList.remove("is-valid");
                }
                else {
                    txbContraseña.classList.remove("is-invalid");
                    txbContraseña.classList.add("is-valid");
                }

                if (txbEmail.value == "") {
                    txbEmail.classList.add("is-invalid");
                    txbEmail.classList.remove("is-valid");
                }
                else {
                    txbEmail.classList.remove("is-invalid");
                    txbEmail.classList.add("is-valid");
                }
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Registrate</h3>
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <label for="txbEmail" class="form-label">Email</label>
                <asp:TextBox ID="txbEmail" CssClass="form-control" placeholder="name@example.com" TextMode="Email" ClientIDMode="Static" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txbContraseña" class="form-label">Contraseña</label>
                <asp:TextBox ID="txbContraseña" CssClass="form-control" placeholder="*******" TextMode="Password" ClientIDMode="Static" AutoPostBack="false" runat="server" />
            </div>
            <asp:Button ID="btnRegistro" Text="Registrate" CssClass="btn btn-primary" OnClick="btnRegistro_Click" OnClientClick="return Validar()" runat="server" />
        </div>
    </div>
</asp:Content>
