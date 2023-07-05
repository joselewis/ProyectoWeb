<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ProductoEspecifico.aspx.cs" Inherits="Tienda.Productos.ProductoEspecifico.ProductoEspecifico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/Productos/ProductoEspecifico/ProductoEspecificoCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Repeater runat="server" ID="d1">
    <ItemTemplate>
	    <form runat="server">
            <section>
                <div class="container flex">
                  <div class="left">
                    <div class="main_image">
                        <image id="ImagenEspecifica" class="card-img-top" src="data:image/jpg;base64,<%#Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"IMAGEN"))%>" alt="" OnRowDataBound="ImagenEspecifica_RowDataBound" class="slide"/>
				     </div>
                  </div>
                  <div class="right">
                    <h3><%#Eval("TIPO_PRENDA") %></h3>
                    <h4> <small>₡</small><%#Eval("PRECIO_PRODUCTO")%></h4>
                    <p><%#Eval("DESCRIPCION_PRODUCTO")%></p>
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
                    <h5>Cantidad disponible:<%#Eval("CANTIDAD_PRODUCTO")%></h5>
                    <div class="add flex1">
                      <span>-</span>
                      <label>1</label>
                      <span>+</span>
                    </div>
                    <asp:Button runat="server" ID="BotonAnnadirCarrito" OnClick="BotonAnnadirCarrito_Click1" Text="Añadir Al Carrito" class="button"/>
                  </div>
                </div>
            </section>
	    </form>
	</ItemTemplate>
</asp:Repeater>
<center>
</center>
<asp:Label ID="lblError" runat="server" ForeColor="Lime" Text="Error" Visible="False"></asp:Label>
</asp:Content>
