<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ProductoEspecifico2.aspx.cs" Inherits="Tienda.Productos.ProductoEspecifico.ProductoEspecifico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/Productos/ProductoEspecifico/ProductoEspecificoCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Label runat="server" Visible="false" ForeColor="Black" ID="LblEstadoCarrito"></asp:Label>
<asp:Label runat="server" Visible="true" ForeColor="Black" ID="LblIdCarrito"></asp:Label>
<br />
<section>
    <div class="container flex">
      <div class="left">
        <div class="main_image">
            <asp:Image runat="server" ID="ImagenProductoEspec" CssClass="Imagen_Pendeja"/>
        </div>
      </div>
      <div class="right">
        <asp:Label runat="server" ID="LabelNombre" CssClass="Nombre"></asp:Label><br />
        <small><asp:Label runat="server" Cssclass="Colones" Text="₡"></asp:Label><asp:Label runat="server" ID="LabelPrecio" CssClass="Precio"></asp:Label></small><br />
        <asp:Label runat="server" ID="LabelDescripcion" CssClass="Descripcion"></asp:Label>
        <div class="color flex1">
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          <span></span>
        </div>
        <span>
            <asp:Label runat="server" ID="Label1" CssClass="Cantidad" Text="Cantidad:"></asp:Label>
        </span>
        <asp:Label runat="server" ID="LabelCantidad" CssClass="Cantidad"></asp:Label>
        <div class="add flex1">
            <span>
                <asp:Label runat="server" ID="LblCantidad" Visible="false" ForeColor="Red"></asp:Label>
                <asp:DropDownList runat="server" ID="DropDownCantidadProducto"></asp:DropDownList>
            </span>
        </div>
        <asp:Button runat="server" ID="BotonAnnadirCarrito" OnClick="BotonAnnadirCarrito_Click1" Text="Añadir Al Carrito" class="button" Visible="false"/>
      </div>
    </div>
</section>		
<center>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
</center>
<br />
</asp:Content>