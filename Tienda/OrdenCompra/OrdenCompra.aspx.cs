using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.PagoFinal
{
    public partial class OrdenCompra : System.Web.UI.Page
    {
        int id;
        int Cantidad = 0;
        long Tarjeta;
        int Validar = 0;
        long TotalPago;

        protected void Page_Load(object sender, EventArgs e)
        {
            SacarOrdenCompra();
            SumarPrecio();

            if (!IsPostBack)
            {
                DesplegarMetodoPagoDDL();
            }
        }

        void SacarOrdenCompra()
        {
            String Rol = Session["TIPO_USUARIO"].ToString();
            String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

            try
            {
                if (Rol == "Normal")
                {
                    string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                    SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

                    using (SqlConnection connection = new SqlConnection(cs))
                    {
                        DataSet ds = new DataSet();

                        SqlCommand cmd = new SqlCommand("SP_INFO_PRODUCTO_ORDEN_COMPRA", connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CORREO_ELECTRONICO", CorreoUsuario);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(ds);
                        adapter.SelectCommand = cmd;

                        var dt = ds.Tables[0];

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            int Precio = Convert.ToInt32(dtRow["PRECIO_PRODUCTO"].ToString());
                            string Prenda = Convert.ToString(dtRow["TIPO_PRENDA"].ToString());

                            //LblId.Text = "Id orden: " + dtRow["ID_ORDEN_COMPRA"].ToString();

                            Label newLbl = new Label();

                            int CantidadXProducto = Convert.ToInt32(dtRow["NUMERO_CANTIDAD_ANNADIDA"].ToString()) * Convert.ToInt32(dtRow["PRECIO_PRODUCTO"].ToString());

                            Cantidad = Convert.ToInt32(dtRow["NUMERO_CANTIDAD_ANNADIDA"].ToString());
                            id = Convert.ToInt32(dtRow["ID_PRODUCTO"].ToString());
                            
                            newLbl.ID = "Lbl" + dt;

                            newLbl.Text = "x" + dtRow["NUMERO_CANTIDAD_ANNADIDA"].ToString() + " " +
                                                dtRow["TIPO_PRENDA"].ToString() + " " +
                                                "₡ " + CantidadXProducto.ToString() +
                                                "<br/>";

                            PanelLbl.Controls.Add(newLbl);    
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void UpdateStock()
        {
            String Rol = Session["TIPO_USUARIO"].ToString();
            String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

            string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
            SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

            try
            {
                if (Rol == "Normal")
                {
                    using (SqlConnection connection = new SqlConnection(cs))
                    {
                        DataSet ds = new DataSet();

                        SqlCommand cmd = new SqlCommand("SP_INFO_PRODUCTO_ORDEN_COMPRA", connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CORREO_ELECTRONICO", CorreoUsuario);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(ds);
                        adapter.SelectCommand = cmd;

                        var dt = ds.Tables[0];

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            Cantidad = Convert.ToInt32(dtRow["NUMERO_CANTIDAD_ANNADIDA"].ToString());
                            id = Convert.ToInt32(dtRow["ID_PRODUCTO"].ToString());

                            List<int> Cantidades = new List<int>();
                            List<int> Identificadores = new List<int>();

                            for (int i = 0; i < Cantidades.Count; i++)
                            {
                                Cantidades.Add(Cantidad);

                                for (int j = 0; j < Identificadores.Count; j++)
                                {
                                    Identificadores.Add(id);   
                                }
                            }

                            SqlConnection conn = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                            conn.Open();

                            SqlCommand Command = conn.CreateCommand();
                            Command.CommandType = System.Data.CommandType.Text;
                            Command.CommandText = "UPDATE PRODUCTO_ROPA SET CANTIDAD_PRODUCTO = CANTIDAD_PRODUCTO - '" + Cantidad + "'" + "WHERE ID_PRODUCTO = '" + id + "'";
                            Command.ExecuteNonQuery();

                            conn.Close();
                        }    
                    }    
                }

                Validar = 3;
            }
            catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void UpdateEstadoCarrtio()
        {
            String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

            try
            {
                SqlConnection conn = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                conn.Open();

                SqlCommand Command = conn.CreateCommand();
                Command.CommandType = System.Data.CommandType.Text;
                Command.CommandText = "UPDATE DETALLE_CARRITO SET ESTADO_PRODUCTO = '" + "Pagado" + "'" + "WHERE CORREO_ELECTRONICO = '" + CorreoUsuario + "'";
                Command.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void DesplegarMetodoPagoDDL()
        {
            String Usuario = Session["CORREO_ELECTRONICO"].ToString();

            try
            {
                string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                string Command = "SELECT NUMERO_TARJETA , NUMERADOR_TARJETA FROM METODO_PAGO WHERE CORREO_ELECTRONICO = '" + Usuario + "'";

                SqlCommand SqlCommand = new SqlCommand(Command, con);

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(Command, con);

                DataTable dt = new DataTable();

                if (adapter.Fill(dt) != 0)
                {
                    DropDownMetPago.DataSource = dt;
                    DropDownMetPago.DataValueField = "NUMERADOR_TARJETA";
                    DropDownMetPago.DataTextField = "NUMERO_TARJETA";
                    DropDownMetPago.DataBind();
                }
                else
                {
                    DropDownMetPago.Visible = false;
                    lblNoMetPago.Visible = true;
                    lblNoMetPago.Text = "Tiene que ingresar un método de pago";
                    BtnPagar.Visible = false;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void SumarPrecio()
        {
            String Rol = Session["TIPO_USUARIO"].ToString();

            try
            {
                if (Rol == "Normal")
                {
                    String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

                    string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                    SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

                    string Command = "SELECT SUM(PRECIO_PRODUCTO * NUMERO_CANTIDAD_ANNADIDA) AS TOTAL FROM PRODUCTO_ROPA " +
                                     "INNER JOIN DETALLE_CARRITO ON DETALLE_CARRITO.CODIGO_PRODUCTO = PRODUCTO_ROPA.CODIGO_PRODUCTO " +
                                     "INNER JOIN USUARIOS ON USUARIOS.CORREO_ELECTRONICO = DETALLE_CARRITO.CORREO_ELECTRONICO WHERE USUARIOS.CORREO_ELECTRONICO = '" + CorreoUsuario + "'";

                    SqlConnection SqlServer = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Command, con);

                    LblTotalPago.Text = Convert.ToString(cmd.ExecuteScalar());

                    TotalPago = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void CrearOrdenCompra()
        {
            try
            {
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    String Usuario = Session["CORREO_ELECTRONICO"].ToString();

                    ORDEN_COMPRA oOrdenCompra = new ORDEN_COMPRA();

                    oOrdenCompra.CORREO_ELECTRONICO = Usuario;
                    oOrdenCompra.TOTAL = Convert.ToInt32(TotalPago);
                    oOrdenCompra.FECHA_ORDEN = DateTime.Now;
                    oOrdenCompra.NUMERADOR_TARJETA_ORDEN = Convert.ToInt64(DropDownMetPago.SelectedValue);
                    oOrdenCompra.NUMERO_TARJETA = Convert.ToInt64(DropDownMetPago.SelectedValue);
                    
                    //RebajarDinero();

                    ContextoDB.ORDEN_COMPRA.Add(oOrdenCompra);
                    ContextoDB.SaveChanges();

                    Validar = 1;
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void RebajarDinero()
        {
            try
            {
                Tarjeta = Convert.ToInt64(DropDownMetPago.SelectedValue);

                SqlConnection conn = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                conn.Open();

                SqlCommand Command = conn.CreateCommand();
                Command.CommandType = System.Data.CommandType.Text;
                Command.CommandText = "UPDATE DINERO_PAGO SET CANTIDAD_DISPONIBLE = CANTIDAD_DISPONIBLE - '" + TotalPago + "'" + "WHERE NUMERO_TARJETA = '" + Tarjeta + "'";
                Command.ExecuteNonQuery();

                conn.Close();

                Validar = 2;
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void GuardarHistorialCompra()
        {
            String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

            try
            {
                SqlConnection conn = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                conn.Open();

                SqlCommand Command = conn.CreateCommand();
                Command.CommandType = System.Data.CommandType.Text;
                Command.CommandText = "INSERT INTO HISTORIAL_COMPRAS SELECT * FROM DETALLE_CARRITO WHERE CORREO_ELECTRONICO = '" + CorreoUsuario + "'";
                Command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        void BorrarCarrito()
        {
            try
            {
                String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

                SqlConnection conn = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                conn.Open();

                SqlCommand Command = conn.CreateCommand();
                Command.CommandType = System.Data.CommandType.Text;
                Command.CommandText = "DELETE FROM DETALLE_CARRITO WHERE CORREO_ELECTRONICO = '" + CorreoUsuario + "'";
                Command.ExecuteNonQuery();

                conn.Close();
            }
            catch(Exception ex) 
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void BtnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                CrearOrdenCompra();
                RebajarDinero();
                UpdateStock();
                UpdateEstadoCarrtio();

                if (Validar == 3)
                {
                    GuardarHistorialCompra();
                    BorrarCarrito();
                    Response.Redirect("../OrdenCompra/TodasOrdenesCompra.aspx");
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Ha ocurrido un error";
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }    
    }
}