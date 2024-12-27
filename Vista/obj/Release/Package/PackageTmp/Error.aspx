<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Vista.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <h1>Error</h1>
            <asp:Label ID="lblError" Text="text" runat="server" />
            <div class="col mt-2">
                <asp:Button ID="btnRegresar" Text="Regresar" CssClass="btn btn-primary" OnClick="btnRegresar_Click" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
