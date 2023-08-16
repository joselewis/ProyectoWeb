<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="OrdenCompra.aspx.cs" Inherits="Tienda.PagoFinal.OrdenCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
    <div style="col">
        <asp:Label ID="LblId" runat="server" Visible="true" Text="Id Orden Compra"></asp:Label>
    </div> 
    <div style="col">
        <asp:Label ID="LblCorreo" runat="server" Visible="true" Text="Correo"></asp:Label>
    </div> 
    <div style="col">
        <asp:Label ID="LblCodigoProducto" runat="server" Visible="true" Text="Código Producto"></asp:Label>
    </div> 
    <div style="col">
        <asp:Label ID="LblIdCarrito" runat="server" Visible="true" Text="Id Carrito"></asp:Label>
    </div> 
    <div style="col">
        <asp:Label ID="LblMetodoPago" runat="server" Visible="true" Text="Método Pago"></asp:Label>
    </div> 
    <div style="col">
        <asp:Label ID="LblTotalPago" runat="server" Visible="true" Text="Total a Pagar"></asp:Label>
    </div> 
</center>
<br />
</asp:Content>
