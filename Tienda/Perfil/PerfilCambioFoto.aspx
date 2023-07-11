<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="PerfilCambioFoto.aspx.cs" Inherits="Tienda.Perfil.PerfilCambioFoto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
    </br>
    <h4>Elija la foto de perfil</h4>
    </br>
    <asp:FileUpload runat="server" class="form-control" ID="CajaNuevaFoto" style=" width:300px; margin:20px; text-align:center;"></asp:FileUpload>
    </br>
</center>
    <div class="d-flex justify-content-center mb-2">
        <asp:Button runat="server" type="button" class="btn btn-dark" Text="Cambiar foto de perfil" ID="NuevaFotoPerfil" OnClick="NuevaFotoPerfil_Click"></asp:Button>
    </div>
<asp:Label ID="lblCamposNulo" runat="server" ForeColor="Red" Visible="False"></asp:Label>
</asp:Content>
