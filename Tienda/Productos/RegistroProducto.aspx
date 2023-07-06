<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="RegistroProducto.aspx.cs" Inherits="Tienda.Productos.RegistroProducto.RegistroProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="Alertas/css/cssAlertaProducto.css" rel="stylesheet" />
    <script src="Alertas/js/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">
    </br>
    <h4>Registrar nuevo producto</h4>
    </br>
    <div class="input-group mb-3">
      <asp:FileUpload runat="server" class="form-control" ID="ImagenProducto" ></asp:FileUpload>
    </div>
    <div class="input-group mb-3">
      <asp:TextBox runat="server" ID="CajaCodigoProducto" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" placeholder="Código del producto"></asp:TextBox>
    </div>
    <div class="input-group mb-3">
      <asp:TextBox runat="server" ID="CajaTipoPrenda" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" placeholder="Tipo Prenda"></asp:TextBox>
    </div>
    <div class="input-group mb-3">
      <asp:TextBox runat="server" ID="CajaPrecioProducto" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" placeholder="Precio"></asp:TextBox>
    </div>
    <div class="input-group mb-3">
      <asp:TextBox runat="server" ID="CajaCantidadProducto" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" placeholder="Cantidad"></asp:TextBox>
    </div>
    <div class="input-group mb-3">
      <asp:TextBox runat="server" ID="CajaDescripcionProducto" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" placeholder ="Descripción"></asp:TextBox>
    </div>
    <div class="input-group mb-3">
      <asp:TextBox runat="server" ID="CajaTallaPrenda" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" placeholder ="Talla Prenda"></asp:TextBox>
    </div>
    <div class="input-group mb-3">
      <asp:TextBox runat="server" ID="CajaMarcaProducto" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" placeholder ="Marca"></asp:TextBox>
    </div>
    <div class="form-check">
      <asp:CheckBox runat="server" class="form-check-input" type="checkbox" value="" ID="CheckBoxProductoActivo"></asp:CheckBox>
      <asp:label runat="server" class="form-check-label" for="flexCheckDefault">
        Disponible
      </asp:label>
    </div>
    <div class="d-grid gap-2 col-4 mx-auto">
      <asp:Button runat="server" Text="Registrar producto" class="btn btn-dark" ID="Btn_Registar_Producto" OnClick="Btn_Registar_Producto_Click"></asp:Button>
    </div>
    <asp:Label ID="lblAlamacenado" runat="server" ForeColor="Lime" Visible="True"></asp:Label>
    </br>
</form>
</asp:Content>
