<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ProductoEspecifico.aspx.cs" Inherits="Tienda.Productos.ProductoEspecifico.ProductoEspecifico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/ProductosCss/ProductoEspecificoCss/ProductoEspecificoCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Repeater runat="server" ID="d1">
    <ItemTemplate>
		<form runat="server">
		<section class="product">
			<div class="product__photo">
				<div class="photo-container">
					<div class="photo-main">
						<image id="ImagenEspecifica" class="card-img-top" src="data:image/jpg;base64,<%#Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"IMAGEN"))%>" alt="" OnRowDataBound="ImagenEspecifica_RowDataBound"/>
					</div>
				</div>
			</div>
			<div class="product__info">
				<div class="title">
					<h1><%#Eval("TIPO_PRENDA") %></h1>
					<span>Código: <h7><%#Eval("CODIGO_PRODUCTO")%></h7></span>
				</div>
				<div class="description">
					<h6>Talla:<%#Eval("TALLA_PRENDA")%></h6>
					<h6><%#Eval("DESCRIPCION_PRODUCTO")%></h6>
				</div>
				<div class="description">
					<h8>Cantidad disponible: <%#Eval("CANTIDAD_PRODUCTO")%></h8>
				</div>
				<div class="price">
					<span><h7>Precio: ₡<%#Eval("PRECIO_PRODUCTO")%></h7></span>
				</div>
				<div class="price">
					<input id="CajaCantidad"/> 
					<%--<asp:TextBox ID="CajaCantidadProducto"  runat="server"  Text='<%#DataBinder.Eval(Container.DataItem, "SALARY")%>'></asp:TextBox>--%>
				</div>
				<asp:Button runat="server" ID="BotonAnnadirCarrito" OnClick="BotonAnnadirCarrito_Click" Text="Añadir al carrito" class="buy--btn" />
				
				
				<%--<a> , </a><span><a href="PaginaPrincipal.aspx?marca"<%#Eval("MARCA")%>></a></span>--%>
			</div>
		</section>
			</form>
	</ItemTemplate>
</asp:Repeater>
<center>
</center>
<asp:Label ID="lblError" runat="server" ForeColor="Lime" Text="Error" Visible="False"></asp:Label>
</asp:Content>
