<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="Vista.FromularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <asp:TextBox ID="txbCodigo" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txbNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txbNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txbDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txbDescripcion" CssClass="form-control" runat="server" />
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
                <asp:TextBox ID="txbUrlImagen" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txbPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txbPrecio" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-primary me-2" runat="server" />
                <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#exampleModal">Eliminar</button>
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
                                        <asp:CheckBox CssClass="me-1" Text="" runat="server" />
                                        <label class="me-2">Si, deseo eliminar</label>
                                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                        <asp:Button ID="btnEliminar" Text="Eliminar" CssClass="btn btn-danger" runat="server" />
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
                <asp:Image ID="urlImagen" Height="400px" ImageUrl="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" CssClass="rounded mt-4" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
