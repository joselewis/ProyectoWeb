<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="MantenimientoAdmin.aspx.cs" Inherits="Tienda.Mantenimientos.MantenimientoAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
    <br/>
    <h4>Mantenimiento de administradores</h4>
    <br/>
<div class="table-responsive-xl">
    <asp:GridView ID="GridAdministrador"
        runat="server" CssClass="table"
        AutoGenerateColumns="False"
        OnRowCancelingEdit="GridAdmin_RowCancelingEdit"
        OnRowCommand="GridAdmin_RowCommand"
        OnRowDeleting="GridAdmin_RowDeleting"
        OnRowEditing="GridAdmin_RowEditing"
        nRowUpdating="GridAdmin_RowUpdating"
        Width="1000px"
        DataKeyNames="CORREO_ELECTRONICO_ADMIN"
        OnSelectedIndexChanged="GridAdmin_SelectedIndexChanged"
        Height="126px" OnRowUpdating="GridAdmin_RowUpdating" HorizontalAlign="Center">
        <Columns >
            <asp:TemplateField HeaderText="Id">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_IdAdministrador" runat="server" Text='<%# Eval("ID_USUARIO_ADMIN") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelIdAdmin" runat="server" Text='<%# Eval("ID_USUARIO_ADMIN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Usuario">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Nombre_Usuario_Admin" runat="server" Text='<%# Eval("NOMBRE_USUARIO_ADMIN") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_UsuarioAdmin" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelNombre_Usuario_Admin" runat="server" Text='<%# Eval("NOMBRE_USUARIO_ADMIN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Contraseña" Visible="false">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Contrasenna_Admin" runat="server" Text='<%# Eval("CONTRASENNA_ADMIN") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Contrasenna_Admin" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("CONTRASENNA_ADMIN") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Telefono">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Telefono_Admin" runat="server" Text='<%# Eval("TELEFONO_ADMIN") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Telefono_Admin" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("TELEFONO_ADMIN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Nombre">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Nombre_Administador" runat="server" Text='<%# Eval("NOMBRE_ADMIN") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_NombreAdmin" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("NOMBRE_ADMIN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Apellido 1">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Apellido_Admin_1" runat="server" Text='<%# Eval("APELLIDO_1_ADMIN") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Apellido1Admin" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("APELLIDO_1_ADMIN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Apellido 2">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Apellido_Admin_2" runat="server" Text='<%# Eval("APELLIDO_2_ADMIN") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Apellido2Admin" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("APELLIDO_2_ADMIN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Correo">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Correo_Administrador" runat="server" Text='<%# Eval("CORREO_ELECTRONICO_ADMIN") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_CorreoAdmin" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("CORREO_ELECTRONICO_ADMIN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Tipo_Administrador" runat="server" Text='<%# Eval("TIPO_USUARIO") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Tipo_Admin" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("TIPO_USUARIO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:ImageButton runat="server" ID="ImageButton1" class="auto-style1" ImageUrl="../Css/ImgMantenimiento/guardar.png" CommandName="Update" Height="20px" ToolTip="Guardar" Width="20px" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton runat="server" ID="BtnAgregarAdministrador" class="auto-style1" ImageUrl="../Css/ImgMantenimiento/nuevo.png" CommandName="AddNew" Height="20px" ToolTip="Nuevo" Width="20px" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="ImageButton4" class="auto-style1" ImageUrl="../Css/ImgMantenimiento/editar.png" CommandName="Edit" Height="20px" ToolTip="Editar" Width="20px"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:ImageButton runat="server" ID="ImageButton3" class="auto-style1" ImageUrl="../Css/ImgMantenimiento/cancel2.png" CommandName="Cancel" Height="20px" ToolTip="Cancelar" Width="20px"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:ImageButton runat="server"  ID="ImageButton5" class="auto-style1" ImageUrl="../Css/ImgMantenimiento/delete2.png" CommandName="Delete" Height="20px" ToolTip="Borrar" Width="20px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <center>
        <asp:Button ID="ButtonExportarAdminExcel" class="btn btn-dark" runat="server" OnClick="ButtonExportarAdminExcel_Click" Text="Exportar a excel" Width="150px"/>
    </center>
    <br />
<asp:Label ID="lblCamposNulos" runat="server" ForeColor="Lime" Visible="false"></asp:Label>
</center>
</asp:Content>
