<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="OrdenCompra.aspx.cs" Inherits="Tienda.PagoFinal.OrdenCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<center>
    <h4>Orden de Compra</h4>
    <div style="col">
        <br />
        <asp:Label ID="LblId" runat="server" Visible="true" Text="Id Orden Compra"></asp:Label>
    </div> 
    <div style="col">
        <asp:Panel runat="server" ID="PanelLbl">
            <asp:Label ID="LblTipoPrenda" runat="server" Visible="true" Text="Prenda"></asp:Label>
            <br />
        </asp:Panel>
    </div> 
    <div style="col">
        <br />
        <asp:Label runat="server" Text="Seleccione el método de pago"></asp:Label>
        <br />
        <asp:DropDownList runat="server" ID="DropDownMetPago"></asp:DropDownList>
        
    </div> 
    <br />
    <div style="col">
        <asp:Label ID="LblTotalPago" runat="server" Visible="true" Text="Total a Pagar"></asp:Label>
    </div>
</center>
<br />
<center>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
    <asp:Button runat="server" ID="BtnPagar" OnClick="BtnPagar_Click" class="btn btn-dark" Text="Pagar"/>
</center>
    <br />
</asp:Content>
