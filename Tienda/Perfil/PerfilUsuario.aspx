<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="Tienda.Perfil.PerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">
<br />
<section style="background-color: #ffff;">
  <div class="container py-2">
    <div class="row">
      <div class="col-lg-3">
        <div class="card mb-3">
            <div class="card-body text-center">
                <asp:Image runat="server" ID="ImagenDefault" src="../Css/Perfil/PerfilUsuario/Img/ImagenBase.png" Visible="false" class="rounded-circle img-fluid" style="width: 170px; height:250px;"/>
            </div>
        <asp:DataList ID="DataListFotoPerfil" runat="server" GroupItemCount="4" RepeatDirection="Horizontal" RepeatColumns="3">
            <ItemTemplate>
                <div class="card-body text-center">
                  <img src="data:image/jpg;base64,<%#Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"IMAGEN_USUARIO"))%>" class="rounded-circle img-fluid" style="width: 170px; height:170px;"/>
                  <br />
                  <br />
                </div>
            </ItemTemplate>
        </asp:DataList>
        <div class="d-flex justify-content-center mb-2">
            <span style="margin-left:5px; margin-right: 5px;">
                <asp:Button runat="server" type="button" class="btn btn-dark" Text="Cambiar foto" ID="CambiarFoto" OnClick="CambiarFoto_Click"></asp:Button>
            </span>
            <span style="margin-left:5px; margin-right: 5px;">
                <asp:Button runat="server" type="button" class="btn btn-dark" Text="Añadir tarjeta" ID="AnnadirTarjeta" OnClick="AnnadirTarjeta_Click"></asp:Button>
            </span>
        </div>
        </div> 
      </div>
      <div class="col-lg-8">
        <div class="card mb-4">
          <div class="card-body">
             <div class="row">
              <div class="col-sm-2">
                <p class="mb-0">Nombre:</p>
              </div>
              <div class="col-sm-9">
                <!------------------------------------NOMBRE PERFIL------------------------------------------------------------>
                <div runat="server" id="Nombre"></div>
                <!-------------------------------------FIN NOMBRE PERFIL----------------------------------------------------------->
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-2">
                <p class="mb-0">Usuario:</p>
              </div>
              <div class="col-sm-9">
                <div runat="server" id="NombreUsuario"></div>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-2">
                <p class="mb-0">Correo:</p>
              </div>
              <div class="col-sm-9">
                <div runat="server" id="Correo"></div>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-2">
                <p class="mb-0">Teléfono:</p>
              </div>
              <div class="col-sm-9">
                <div runat="server" id="Telefono"></div>
              </div>
            </div>
               <hr>
            <div class="row"> 
            </div>
          </div>
      </div>
    </div>
  </div>
</section>
</form>
<asp:Label ID="lblError" runat="server" ForeColor="Lime" Visible="false"></asp:Label>
</asp:Content>
