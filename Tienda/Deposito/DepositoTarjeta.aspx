<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="DepositoTarjeta.aspx.cs" Inherits="Tienda.Deposito.DepositoTarjeta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="Alertas/css/cssAlertaProducto.css" rel="stylesheet" />
    <script src="Alertas/js/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Formulario" style="margin-left:100px; margin-right:100px;">
        <br />
        <center>
            <h4>Depositar dinero</h4>
        </center>
        <br />
        <div class="input-group mb-3">
          <asp:TextBox runat="server" ID="CajaTarjetaDeposito" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" placeholder="0000000000"></asp:TextBox>
        </div>
        <div class="input-group mb-3">
          <asp:TextBox runat="server" ID="CajaDepositoDinero" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" placeholder="0000000000"></asp:TextBox>
        </div>
        <div class="d-grid gap-2 col-4 mx-auto">
          <asp:Button runat="server" Text="Depositar" class="btn btn-dark" ID="Btn_Depositar" OnClick="Btn_Depositar_Click"></asp:Button>
        </div>
        <asp:Label ID="lblErrorDeposito" runat="server" ForeColor="Lime" Visible="True"></asp:Label>
        <br />
    </div>
</asp:Content>
