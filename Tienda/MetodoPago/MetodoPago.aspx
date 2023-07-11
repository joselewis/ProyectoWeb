<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="MetodoPago.aspx.cs" Inherits="Tienda.MetodoPago.MetodoPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.4.1/dist/css/bootstrap.min.css" 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
</br>
<h4>Método de pago</h4>
<br />

<asp:GridView Visible="false" ID="GridMetodoPago" 
    runat="server" class="table" 
    AutoGenerateColumns="False"
    OnRowCancelingEdit="GridMetodoPago_RowCancelingEdit" 
    OnRowCommand="GridMetodoPago_RowCommand"
    OnRowDeleting="GridMetodoPago_RowDeleting" 
    OnRowEditing="GridMetodoPago_RowEditing" 
    OnRowUpdating="GridMetodoPago_RowUpdating" 
    Width="471px"
    DataKeyNames="NUMERO_TARJETA" 
    OnSelectedIndexChanged="GridMetodoPago_SelectedIndexChanged" 
    Height="126px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
    <Columns >
        <asp:TemplateField HeaderText="Número Tarjeta">
            <EditItemTemplate>
                <asp:TextBox ID="Txt_Numero_Tarjeta" runat="server" Text='<%# Eval("NUMERO_TARJETA") %>'></asp:TextBox>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txt_footer_Numero_Tarjeta" runat="server"></asp:TextBox>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="LabelNumeroTarjeta" runat="server" Text='<%# Eval("NUMERO_TARJETA") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Mes">
            <EditItemTemplate>
                <asp:TextBox ID="Txt_Nombre_Tarjeta_Mes" runat="server" Text='<%# Eval("NUMERO_EXPIRA_1") %>'></asp:TextBox>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txt_footer_Tarjeta_Mes" runat="server"></asp:TextBox>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="LabelNombre_Usuario" runat="server" Text='<%# Eval("NUMERO_EXPIRA_1") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
            
        <asp:TemplateField HeaderText="Año">
            <EditItemTemplate>
                <asp:TextBox ID="Txt_Tarjeta_Anno" runat="server" Text='<%# Eval("NUMERO_EXPIRA_2") %>'></asp:TextBox>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txt_footer_Tarjeta_Anno" runat="server"></asp:TextBox>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="Label18" runat="server" Text='<%# Eval("NUMERO_EXPIRA_2") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Correo" Visible="false">
            <EditItemTemplate>
                <asp:TextBox ID="Txt_Correo_Usuario" runat="server" Text='<%# Eval("CORREO_ELECTRONICO") %>'></asp:TextBox>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txt_Correo_Usuario" runat="server"></asp:TextBox>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="Label11" runat="server" Text='<%# Eval("CORREO_ELECTRONICO") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Estado" Visible="true">
            <EditItemTemplate>
                <asp:CheckBox ID="CheckboxPago" runat="server" Text='<%# Eval("TARJETA_ACTICA")%>'></asp:CheckBox>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:CheckBox ID="txt_CheckBox_Pago" runat="server"></asp:CheckBox>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="Label11" runat="server" Text='<%# Eval("CORREO_ELECTRONICO") %>'></asp:Label>
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
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
</asp:GridView>
<asp:Label ID="lblCamposPagoNulo" runat="server" ForeColor="Red" Visible="False"></asp:Label>
</center>
</asp:Content>
