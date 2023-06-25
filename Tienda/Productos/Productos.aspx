<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Tienda.Productos.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../MasterPage/css/styles.css" rel="stylesheet" />
    <script src="../MasterPage/js/scripts.js"></script>
    <link href="../Css/Productos/ProductosCss/ProductosCss.css" rel="stylesheet" />
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel="stylesheet" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="search-box">
        <i class="bx bx-search"></i>
        <input type="text" placeholder="Buscar"/>
    </div>
</div>
<asp:DataList ID="DataListRopa" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
    <ItemTemplate>
        <div class="container">
            <div class="images">
                <div class ="image-box" data-name="ImagenPaisaje">
                    <a href="ProductoEspecifico/ProductoEspecifico.aspx?id=<%#Eval("CODIGO_PRODUCTO")%>">
                        <img src="data:image/jpg;base64,<%#Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"IMAGEN"))%>" alt=""/>
                    </a>
                    <h6><%#Eval("TIPO_PRENDA")%></h6>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>
<script src="../Css/Productos/ProductosJs/ProductosJs.js"></script>
</asp:Content>