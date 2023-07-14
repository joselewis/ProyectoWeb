﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="CategoriaProductoEspecifico.aspx.cs" Inherits="Tienda.CategoriaRopa.CategoriaProductoEspecifico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/Productos/ProductoEspecifico/ProductoEspecificoCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Repeater runat="server" ID="d2">
    <ItemTemplate>
            <section>
                <div class="container flex">
                  <div class="left">
                    <div class="main_image">
                        <image id="ImagenEspecifica" class="card-img-top" src="data:image/jpg;base64,<%#Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"IMAGEN"))%>" alt="" OnRowDataBound="ImagenEspecifica_RowDataBound" class="slide"/>
                    </div>
                  </div>
                  <div class="right">
                    <h3><%#Eval("TIPO_PRENDA") %></h3>
                    <h4> <small style="color:#000;">₡</small><%#Eval("PRECIO_PRODUCTO")%></h4>
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
                    <div <%--class="add flex1"--%>>
                        <span>
                            <asp:ImageButton runat="server" ID="BotonMenosCantidad" src="../Css/ProductoCarrito/Menos.png" OnClick="BotonMenosCantidad_Click" Width="25" Height="25" />
                        </span>
                        <span style="margin-left:10px; margin-right:10px;">
                            <asp:Label runat="server" ID="LabelCantidad" Text="0"></asp:Label>
                        </span>
                        <span>
                            <asp:ImageButton runat="server" ID="BotonMasCantidad" src="../Css/ProductoCarrito/Mas.png" OnClick="BotonMasCantidad_Click" Width="25" Height="25" />
                        </span>
                    </div>
                  </div>
                </div>
            </section>
	</ItemTemplate>
</asp:Repeater>
<asp:Button runat="server" ID="BotonAnnadirCarrito" OnClick="BotonAnnadirCarrito_Click1" Text="Añadir Al Carrito" class="button"/>
<center>
</center>
<asp:Label ID="lblError" runat="server" ForeColor="Lime" Text="Error" Visible="False"></asp:Label>
</asp:Content>
