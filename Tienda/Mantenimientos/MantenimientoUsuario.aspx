<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="MantenimientoUsuario.aspx.cs" Inherits="Tienda.Mantenimientos.MantenimientoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
    </br>
    <h4>Mantenimiento de usuarios</h4>
    </br>
    <asp:GridView ID="GridUsuarios" 
        runat="server" class="table" 
        AutoGenerateColumns="False"
        OnRowCancelingEdit="GridUsuario_RowCancelingEdit" 
        OnRowCommand="GridUsuario_RowCommand"
        OnRowDeleting="GridUsuario_RowDeleting" 
        OnRowEditing="GridUsuario_RowEditing" 
        nRowUpdating="GridUsuario_RowUpdating" 
        Width="848px" 
        DataKeyNames="CORREO_ELECTRONICO" 
        OnSelectedIndexChanged="GridUsuario_SelectedIndexChanged" 
        Height="126px" OnRowUpdating="GridUsuario_RowUpdating">
        <Columns >
            <asp:TemplateField HeaderText="Id">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_IdUsuario" runat="server" Text='<%# Eval("ID_USUARIO") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelIdUsuario" runat="server" Text='<%# Eval("ID_USUARIO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Usuario">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Nombre_Usuario" runat="server" Text='<%# Eval("NOMBRE_USUARIO") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Usuario" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelNombre_Usuario" runat="server" Text='<%# Eval("NOMBRE_USUARIO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Contraseña" Visible="false">
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Contrasenna_Usuario" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("CONTRASENNA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Telefono">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Telefono_Usuario" runat="server" Text='<%# Eval("TELEFONO_USUARIO") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Telefono_Usuario" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("TELEFONO_USUARIO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Nombre">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Nombre" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Nombre_Usuario" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Apellido 1">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Apellido_Usuario_1" runat="server" Text='<%# Eval("APELLIDO_1_USUARIO") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Apellido_Usuario_1" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("APELLIDO_1_USUARIO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Apellido 2">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Apellido_Usuario_2" runat="server" Text='<%# Eval("APELLIDO_2_USUARIO") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Apellido_Usuario_2" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("APELLIDO_2_USUARIO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Correo">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Correo_Usuario" runat="server" Text='<%# Eval("CORREO_ELECTRONICO") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Correo_Usuario" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("CORREO_ELECTRONICO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo" Visible="False">
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Tipo_Usuario" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("TIPO_USUARIO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado" Visible="True">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Cuenta_Activa" runat="server" Text='<%# Eval("CUENTA_ACTIVA") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Cuenta_Activa" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelCuentaActiva" runat="server" Text='<%# Eval("CUENTA_ACTIVA") %>'></asp:Label>
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
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <center>
        <asp:Button ID="ButtonExportarUsuarioExcel" class="btn btn-dark" runat="server" OnClick="ButtonExportarUsuarioExcel_Click" Text="Exportar" Width="87px" />
    </center>
</div>
<br />
<asp:Label ID="lblCamposNulos" runat="server" ForeColor="Lime" Text="Los campos  son requeridos ***" Visible="False"></asp:Label>
</center>
</asp:Content>
