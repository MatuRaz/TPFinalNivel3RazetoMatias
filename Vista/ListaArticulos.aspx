<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="Vista.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scp1" runat="server" />

    <div class="row">
        <div class="col-2">
            <div class="col mt-4" style="display: flex">
                <asp:TextBox ID="txbFiltro" CssClass="form-label form-control" OnTextChanged="txbFiltro_TextChanged" AutoPostBack="true" placeholder="Buscá por nombre..." runat="server" />
            </div>
            <div class="container-2">
                <label class="col-form-label" for="chkFiltroAvanzado">Filtro Avanzado</label>
                <asp:CheckBox ID="chkFiltroAvanzado" AutoPostBack="true" Text="" runat="server" />
            </div>
            <%if (chkFiltroAvanzado.Checked)
                {%>

            <div class="row mt-1">
                <div class="col">
                    <label class="me-2">Campo:</label>
                    <asp:DropDownList ID="dllCampo" CssClass="btn btn-secondary dropdown-toggle" OnTextChanged="dllCampo_TextChanged" AutoPostBack="true" runat="server">
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Codigo" />
                        <asp:ListItem Text="Categoria" />
                        <asp:ListItem Text="Marca" />
                        <asp:ListItem Text="Precio" />
                    </asp:DropDownList>
                </div>
                <div class="dropdown mt-3">
                    <label class="me-2">Criterio:</label>
                    <asp:DropDownList ID="dllCriterio" CssClass="btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
                </div>
                <div class="col">
                    <label class="col-form-label mt-2" for="chkFiltroAvanzado">Aplicar mas de un filtro</label>
                    <asp:CheckBox ID="chkFiltros" AutoPostBack="true" Text="" runat="server" />
                    <%if (chkFiltros.Checked)
                        { %>

                    <div>
                        <div class="row col-6">
                            <div class="col">
                                <asp:Button ID="btnAplicarFiltro" CssClass="btn btn-warning mt-2" Text="Aplicar filtro" OnClick="btnAplicarFiltro_Click" runat="server" />
                            </div>
                        </div>
                        <div class="col">
                            <label class="h5 mt-2">Filtros activos:</label>
                            <%if (chkNombre == true)
                                { %>
                            <div class="container-2 mt-1" style="display: flex">
                                <asp:Button CssClass="btn btn-sm" ID="btnEFNombre" Text="❌" OnClick="btnEFNombre_Click" runat="server" />
                                <label class="me-2">Nombre:</label>
                                <asp:Label CssClass="" ID="lblNombre" Text="" runat="server" />
                            </div>
                            <%} %>
                            <%if (chkCodigo == true)
                                { %>
                            <div class="container-2" style="display: flex">
                                <asp:Button CssClass="btn btn-sm" ID="btnEFCodigo" Text="❌" OnClick="btnEFCodigo_Click" runat="server" />
                                <label class="me-2">Codigo:</label>
                                <asp:Label ID="lblCodigo" Text="" runat="server" />
                            </div>
                            <%} %>
                            <%if (chkCategoria == true)
                                { %>
                            <div class="container-2" style="display: flex">
                                <asp:Button CssClass="btn btn-sm" ID="btnEFCategtoria" Text="❌" OnClick="btnEFCategtoria_Click" runat="server" />
                                <label class="me-2">Categoria:</label>
                                <asp:Label ID="lblCategoria" Text="" runat="server" />
                            </div>
                            <%} %>
                            <%if (chkMarca == true)
                                { %>
                            <div class="container-2" style="display: flex">
                                <asp:Button CssClass="btn btn-sm" ID="btnEFMarca" Text="❌" OnClick="btnEFMarca_Click" runat="server" />
                                <label class="me-2">Marca:</label>
                                <asp:Label ID="lblMarca" Text="" runat="server" />
                            </div>
                            <%} %>
                            <%if (chkPrecio == true)
                                { %>
                            <div class="container-2" style="display: flex">
                                <asp:Button CssClass="btn btn-sm" ID="btnEFPrecio" Text="❌" OnClick="btnEFPrecio_Click" runat="server" />
                                <label class="me-2">Precio:</label>
                                <asp:Label ID="lblPrecio" Text="" runat="server" />
                            </div>
                            <%} %>
                        </div>
                    </div>
                    <%} %>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:TextBox ID="txbFiltroAvanzado" CssClass="form-control mt-2" placeholder="Filtro..." runat="server" />
                        <asp:Button ID="btnBuscar" Text="Buscar" CssClass="btn btn-primary mt-3" OnClick="btnBuscar_Click" runat="server" />
                    </div>
                </div>
            </div>

            <% } %>
        </div>
        <%if (SinResultado)
            {%>
        <div class="ccontent mt-1" style="display: grid; place-items: center">
            <div style="display: flex">
                <h5 class="mb-3 me-2">No hay resultados para</h5>
                <asp:Label CssClass="h5" ID="lblResultado" Text="" runat="server" />
            </div>
            <h6 class="mb-3">Por favor intenta con otro criterio.</h6>
        </div>
        <% } %>
        <div class="col">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvArticulos" CssClass="table table-bordered table-dark mt-4" AutoGenerateColumns="false" runat="server"
                        OnSelectedIndexChanged="gvArticulos_SelectedIndexChanged" OnPageIndexChanging="gvArticulos_PageIndexChanging"
                        AllowPaging="true" PageSize="15" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca" />
                            <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="⚙️" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


</asp:Content>
