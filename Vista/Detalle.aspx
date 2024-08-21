<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Vista.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="conteiner" style="display: grid; place-items: center">

        <div class="row">
            <div class="col mt-4">
                <div class="col">
                    <div class="col">
                        <asp:Image ID="imgArticulo" Width="300px" runat="server" />
                    </div>

                </div>

            </div>
            <div class="col mt-4">
                <asp:Label ID="lblNombre" Text="text" runat="server" />
            </div>

        </div>
    </div>
</asp:Content>
