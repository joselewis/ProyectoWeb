<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ProductoEspecifico2.aspx.cs" Inherits="Tienda.Productos.ProductoEspecifico.ProductoEspecifico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/Productos/ProductoEspecifico/ProductoEspecificoCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <h5>Color-Rose Gold</h5>
        <div class="color flex1">
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          <span></span>
        </div>
        <asp:Label runat="server" ID="LabelCantidad" CssClass="Cantidad"></asp:Label>
        <div class="add flex1">
          <span>-</span>
          <label>1</label>
          <span>+</span>
        </div>

        <button>Add to Bag</button>
      </div>
    </div>
</section>		
<center>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
</center>
<br />
</asp:Content>
