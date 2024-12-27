<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vista.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Ingresa</h3>
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <label for="txbEmail" class="form-label">Email</label>
                <asp:TextBox ID="txbEmail" CssClass="form-control" placeholder="name@example.com" TextMode="Email" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txbContraseña" class="form-label">Contraseña</label>
                <asp:TextBox ID="txbContraseña" CssClass="form-control" placeholder="*******" TextMode="Password" runat="server" />
            </div>
            <asp:Button ID="btnLogin" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" runat="server" />
        </div>
    </div>
</asp:Content>
