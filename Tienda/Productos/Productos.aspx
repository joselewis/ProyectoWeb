﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Tienda.Productos.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../MasterPage/css/styles.css" rel="stylesheet" />
    <script src="../MasterPage/js/scripts.js"></script>
    <link href="../Css/Productos/ProductosCss/ProductosCss.css" rel="stylesheet" />
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel="stylesheet" /> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
<center>
<asp:DataList ID="DataListRopa" runat="server" GroupItemCount="4" RepeatDirection="Horizontal" RepeatColumns="4">
    <ItemTemplate>
        <div class="gallery">
                <div class="content">
                    <a href="../Productos/ProductoEspecifico2.aspx?id=<%#Eval("CODIGO_PRODUCTO")%>">
                        <img src="data:image/jpg;base64,<%#Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"IMAGEN"))%>" alt=""/>
                    </a>
                    <h3><%#Eval("TIPO_PRENDA")%></h3>
                    <p><%#Eval("DESCRIPCION_PRODUCTO")%></p>
                    <%--<h6>₡<%#Eval("PRECIO_PRODUCTO")%></h6>--%>
                    <ul>
                        <li><i class="fa fa-star checked"></i></li>
                        <li><i class="fa fa-star checked"></i></li>
                        <li><i class="fa fa-star checked"></i></li>
                        <li><i class="fa fa-star checked"></i></li>
                        <li><i class="fa fa-star checked"></i></li>
                    </ul>
                </div> 
            </div>
    </ItemTemplate>
</asp:DataList>
</center>
</asp:Content>