<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="TodasOrdenesCompra.aspx.cs" Inherits="Tienda.OrdenCompra.TodasOrdenesCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <center>
        <h4>Mis Ordenes de Compra</h4>
        <asp:Label runat="server" ID="LblFecha" Text="Fecha" Visible="true"></asp:Label>
        <ul runat="server" id="Cosa">
               
        </ul>
        <asp:Label ID="LblError" runat="server" ForeColor="red" Visible="false"></asp:Label>
    </center>
    <br />
</asp:Content>
