<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="Vista.FromularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font: 12px;
        }
    </style>
    <script>   
        function HayLetras(Elemento) {

            var numeros = "0123456789";

            for (var i = 0; i < Elemento.length; i++) {

                if (numeros.indexOf(Elemento.charAt(i), 0) != -1) {
                    return false;
                }
            }
            return true;
        }

        function Validar() {
            const txbCodigo = document.getElementById("txbCodigo");
            const txbNombre = document.getElementById("txbNombre");
            const txbDescripcion = document.getElementById("txbDescripcion");
            const txbUrlImagen = document.getElementById("txbUrlImagen");
            const txbPrecio = document.getElementById("txbPrecio");

            if (txbCodigo.value == "" || txbNombre.value == "" || txbDescripcion.value == "" || txbUrlImagen.value == "" || txbPrecio.value == "" || HayLetras(txbPrecio.value)) {
                if (txbCodigo.value == "") {
                    txbCodigo.classList.add("is-invalid");
                    txbCodigo.classList.remove("is-valid");
                }
                else {
                    txbCodigo.classList.remove("is-invalid");
                    txbCodigo.classList.add("is-valid");
                }

                if (txbNombre.value == "") {
                    txbNombre.classList.add("is-invalid");
                    txbNombre.classList.remove("is-valid");
                }
                else {
                    txbNombre.classList.remove("is-invalid");
                    txbNombre.classList.add("is-valid");
                }

                if (txbDescripcion.value == "") {
                    txbDescripcion.classList.add("is-invalid");
                    txbDescripcion.classList.remove("is-valid");
                }
                else {
                    txbDescripcion.classList.remove("is-invalid");
                    txbDescripcion.classList.add("is-valid");
                }

                if (txbUrlImagen.value == "") {
                    txbUrlImagen.classList.add("is-invalid");
                    txbUrlImagen.classList.remove("is-valid");
                }
                else {
                    txbUrlImagen.classList.remove("is-invalid");
                    txbUrlImagen.classList.add("is-valid");
                }

                if (txbPrecio.value == "") {
                    txbPrecio.classList.add("is-invalid");
                    txbPrecio.classList.remove("is-valid");
                }
                else {
                    txbPrecio.classList.remove("is-invalid");
                    txbPrecio.classList.add("is-valid");
                }

                if (HayLetras(txbPrecio.value)) {
                    txbPrecio.classList.add("is-invalid");
                    txbPrecio.classList.remove("is-valid");
                }
                else {
                    txbPrecio.classList.remove("is-invalid");
                    txbPrecio.classList.add("is-valid");
                }

                return false;
            }
            return true;
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="mb-3">
                <label for="txbId" class="form-label">Id</label>
                <asp:TextBox ID="txbId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txbCodigo" class="form-label">Codigo</label>
                <asp:TextBox ID="txbCodigo" ClientIDMode="Static" CssClass="form-control" MaxLength="20" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txbNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txbNombre" ClientIDMode="Static" CssClass="form-control" MaxLength="20" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txbDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txbDescripcion" ClientIDMode="Static" CssClass="form-control" MaxLength="50" runat="server" />
            </div>
            <div class="mb-3">
                <label for="dllMarca" class="form-label">Marca</label>
                <br />
                <asp:DropDownList ID="dllMarca" CssClass="btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="dllCategoria" class="form-label">Categoria</label>
                <br />
                <asp:DropDownList ID="dllCategoria" CssClass="btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txbUrlImagen" class="form-label">Url imagen</label>
                <asp:TextBox ID="txbUrlImagen" ClientIDMode="Static" CssClass="form-control" MaxLength="999" AutoPostBack="true" OnTextChanged="txbUrlImagen_TextChanged" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txbPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txbPrecio" ClientIDMode="Static" CssClass="form-control" MaxLength="7" runat="server" />
                <%--     <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="*Solo numeros " ControlToValidate="txbPrecio" ValidationExpression="^[0-9]+$" runat="server" />
                <asp:RangeValidator CssClass="validacion" ErrorMessage="*Fuera de rango" ControlToValidate="txbPrecio" Type="Integer" MinimumValue="1" MaximumValue="9999999" runat="server" />--%>
            </div>
            <div class="mb-3">

                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-primary me-2" OnClick="btnAceptar_Click" OnClientClick="return Validar()" runat="server" />


                <%if ((string)Session["id"] != "")
                    {%>
                <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#exampleModal">Eliminar</button>
                <% }%>
                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Eliminar</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body m-lg-auto">
                                ¿Realmente desea eliminar el articulo?
                            </div>
                            <div class="col m-lg-auto">
                                <asp:Label CssClass="h5" ID="lblEliminar" Text="" runat="server" />
                            </div>
                            <div class="modal-footer mt-3">
                                <div class="row">
                                    <div class="col">
                                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                        <asp:Button ID="btnEliminar" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="col">
            <div class="text-center">
                <asp:Image ID="urlImagen" Height="400px" CssClass="rounded mt-4" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
