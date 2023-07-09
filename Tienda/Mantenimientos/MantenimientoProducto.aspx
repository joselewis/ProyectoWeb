<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="MantenimientoProducto.aspx.cs" Inherits="Tienda.Mantenimientos.MantenimientoProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
<form runat="server">
    <h4>Mantenimiento de Productos</h4>
    </br>
    <asp:GridView ID="GridProductos"
        runat="server" class="table table-dark table-striped"
        AutoGenerateColumns="False"
        OnRowCancelingEdit="GridProductos_RowCancelingEdit"
        OnRowCommand="GridProductos_RowCommand"
        OnRowDeleting="GridProductos_RowDeleting"
        OnRowEditing="GridProductos_RowEditing"
        OnRowUpdating="GridProductos_RowUpdating"
        Width="1000px"
        DataKeyNames="CODIGO_PRODUCTO"
        OnSelectedIndexChanged="GridProductos_SelectedIndexChanged"
        Height="126px" HorizontalAlign="Center">
        <Columns >
            <asp:TemplateField HeaderText="Id">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_IdProducto" runat="server" Text='<%# Eval("ID_PRODUCTO") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelIdAdmin" runat="server" Text='<%# Eval("ID_PRODUCTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Código">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="Txt_Codigo_Producto" runat="server" Text='<%# Eval("CODIGO_PRODUCTO") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Codigo_Producto" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelNombre_Usuario_Admin" runat="server" Text='<%# Eval("CODIGO_PRODUCTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Tipo Prenda">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Tipo_Prenda" runat="server" Text='<%# Eval("TIPO_PRENDA") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Tipo_Prenda" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("TIPO_PRENDA") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Precio">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Precio_Producto" runat="server" Text='<%# Eval("PRECIO_PRODUCTO") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Precio_Producto" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("PRECIO_PRODUCTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Cantidad">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Cantidad_Disponible" runat="server" Text='<%# Eval("CANTIDAD_PRODUCTO") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Cantidad_Disponible" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("CANTIDAD_PRODUCTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Descripción">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Descrip_Producto" runat="server" Text='<%# Eval("DESCRIPCION_PRODUCTO") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Descrip_Producto" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("DESCRIPCION_PRODUCTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Talla">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Talla_Producto" runat="server" Text='<%# Eval("TALLA_PRENDA") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Talla_Producto" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("TALLA_PRENDA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Imagen" Visible="false">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Imagen_Producto" runat="server" Text='<%# Eval("IMAGEN") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Imagen_Producto" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("IMAGEN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Marca" Visible="True">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Marca_Producto" runat="server" Text='<%# Eval("MARCA") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Marca_Producto" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("MARCA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Activo" Visible="True">
                <EditItemTemplate>
                    <asp:TextBox ID="Txt_Producto_Activo" runat="server" Text='<%# Eval("PRODUCTO_ACTIVO") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt_footer_Producto_Activo" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label90" runat="server" Text='<%# Eval("PRODUCTO_ACTIVO") %>'></asp:Label>
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
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <center>
        <asp:Button ID="ButtonExportarProductoExcel" class="btn btn-dark" runat="server" OnClick="ButtonExportarProductoExcel_Click" Text="Exportar a excel" Width="150px" Visible="false"/>
    </center>
    <br />
    <center>
    <asp:Label ID="LblError" runat="server" ForeColor="red" Visible="false"></asp:Label><asp:Label ID="Label2" runat="server" ForeColor="red" Visible="false"></asp:Label><asp:Label ID="Label7" runat="server" ForeColor="red" Visible="false"></asp:Label><asp:Label ID="Label1" runat="server" ForeColor="red" Visible="false"></asp:Label>
        </center>
</form>
</asp:Content>
