<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="MetodoPago2.aspx.cs" Inherits="Tienda.MetodoPago.MetodoPago2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
    <br/>
    <h4>Método de pago</h4>
    <br />
    <div style="margin-left:500px; margin-right:500px;">
        <div>
            <div style="margin-top:5px; margin-bottom:5px;">
              <asp:TextBox runat="server" type="text" class="form-control" placeholder="Número de tarjeta" ID="CajaNumeroTarjeta"></asp:TextBox>
            </div >
            <div style="margin-top:5px; margin-bottom:5px;">
              <asp:TextBox runat="server" type="text" class="form-control" placeholder="Mes" ID="CajaMesTarjeta"></asp:TextBox>
            </div>
            <div style="margin-top:5px; margin-bottom:5px;">
              <asp:TextBox runat="server" type="text" class="form-control" placeholder="Año" ID="CajaAnnoTarjeta"></asp:TextBox>
            </div>
            <div style="margin-top:5px; margin-bottom:5px;">
              <asp:TextBox runat="server" type="text" class="form-control" placeholder="Código de seguridad" ID="CajaCódigoTarjeta"></asp:TextBox>
            </div>
            <div style="margin-top:7px; margin-bottom:7px;">
                <div class="form-check">
                  <asp:CheckBox runat="server" class="form-check-input" ID="CheckBoxTarjetaActiva"/>
                  <label class="form-check-label" for="flexCheckChecked">
                    Tarjeta Activa
                  </label>
                </div>
            </div>
            <div style="margin-top:7px; margin-bottom:7px;">
                <asp:Button runat="server" ID="ButtonAnnadirPago" class="btn btn-dark" Text="Añadir nuevo método de pago" OnClick="ButtonAnnadirPago_Click"/>
            </div>
        </div>
    </div>
    <div style="margin-top:60px; margin-bottom:20px;">
        <asp:Label runat="server" Text="Métodos de pago registrados" Visible="false" ID="LabelMetodoPagoRegistrado"></asp:Label>
    </div>
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
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("TARJETA_ACTICA") %>'></asp:Label>
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
