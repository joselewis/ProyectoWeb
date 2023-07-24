<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="CarritoCompras.aspx.cs" Inherits="Tienda.CarritoCompras.CarritoCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <asp:Label ID="LblCodigoProducto" runat="server" ForeColor="Red" Text="Error" Visible="True"></asp:Label>
        <asp:Label ID="LblTipoPrenda" runat="server" ForeColor="Red" Text="Error" Visible="True"></asp:Label>
        <asp:Label ID="LblPrecioProducto" runat="server" ForeColor="Red" Text="Error" Visible="True"></asp:Label>
        <asp:Label ID="LblCantidadProducto" runat="server" ForeColor="Red" Text="Error" Visible="True"></asp:Label>
        <asp:Label ID="LblTallaPrenda" runat="server" ForeColor="Red" Text="Error" Visible="True"></asp:Label>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
    </center>
</asp:Content>
