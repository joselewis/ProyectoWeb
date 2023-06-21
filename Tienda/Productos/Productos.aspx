<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Tienda.Productos.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../MasterPage/css/styles.css" rel="stylesheet" />
    <script src="../MasterPage/js/scripts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:DataList ID="DataListRopa" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" >
    <ItemTemplate>
        <div style="border: 2px solid #000000; width:225px; height:600px; margin-left:25px; margin-top:50px; margin-right:25px; margin-bottom:50px;" 
            <div class="card h-100">
                <!-- Product image-->
                    <img class="card-img-top" src="data:image/jpg;base64,<%#Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"IMAGEN"))%>" style="width:221px; height:200px;" alt=""/>
                <!-- Product details-->
                <div class="card-body p-4">
                    <div class="text-center">
                        <!-- Product name-->
                        <h5 class="fw-bolder"><%#Eval("TIPO_PRENDA")%></h5>
                        <!-- Product price-->
                        ₡<%#Eval("PRECIO_PRODUCTO")%>
                    </div>
                </div>
                <!-- Product actions-->
                <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                    <div class="text-center">
                        <a class="btn btn-outline-dark mt-auto" href="ProductoEspecifico/ProductoEspecifico.aspx?id=<%#Eval("CODIGO_PRODUCTO")%>">Ver detalles</a>
                    </div>
                </div>
                </div>
            </div>
    </ItemTemplate>
</asp:DataList>
<asp:Label ID="lblError" runat="server" ForeColor="Lime" Text="Error" Visible="False"></asp:Label>
</asp:Content>