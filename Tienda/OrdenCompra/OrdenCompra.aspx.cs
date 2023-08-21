using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.PagoFinal
{
    public partial class OrdenCompra : System.Web.UI.Page
    {
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            SacarOrdenCompra();
            DesplegarMetodoPagoDDL();
            SumarPrecio();
        }

        void SacarOrdenCompra()
        {
            String Rol = Session["TIPO_USUARIO"].ToString();

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

                        cmd.Parameters.AddWithValue("ID", "SP_INFO_PRODUCTO_ORDEN_COMPRA");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(ds);
                        adapter.SelectCommand = cmd;

                        var dt = ds.Tables[0];

                        foreach (DataRow dtRow in dt.Rows)
                        {
                            int Precio = Convert.ToInt32(dtRow["PRECIO_PRODUCTO"].ToString());
                            string Prenda = Convert.ToString(dtRow["TIPO_PRENDA"].ToString()); 

                            LblId.Text = "Id orden: " + dtRow["ID_ORDEN_COMPRA"].ToString();


                            Label newLbl = new Label();

                            int CantidadXProducto = Convert.ToInt32(dtRow["NUMERO_CANTIDAD_ANNADIDA"].ToString()) * Convert.ToInt32(dtRow["PRECIO_PRODUCTO"].ToString());

                            newLbl.ID = "Lbl" + dt;

                            newLbl.Text = "x" + dtRow["NUMERO_CANTIDAD_ANNADIDA"].ToString() + " " + 
                                                dtRow["TIPO_PRENDA"].ToString() + " " + 
                                                CantidadXProducto.ToString() + 
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

        void DesplegarMetodoPagoDDL()
        {
            String Usuario = Session["CORREO_ELECTRONICO"].ToString();

            try
            {
                string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                string Command = "SELECT NUMERO_TARJETA FROM METODO_PAGO WHERE CORREO_ELECTRONICO = '" + Usuario + "'";

                SqlCommand SqlCommand = new SqlCommand(Command, con);

                con.Open();

                SqlDataAdapter Adapter = new SqlDataAdapter(SqlCommand);

                SqlDataReader dr = SqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    string Tarjeta = Convert.ToString(dr["NUMERO_TARJETA"].ToString());
                    
                    DropDownMetPago.Items.Add(new ListItem(Tarjeta.ToString(), Tarjeta.ToString()));

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

                    string Command = "SELECT SUM(PRECIO_PRODUCTO * NUMERO_CANTIDAD) AS TOTAL FROM PRODUCTO_ROPA INNER JOIN CARRITO ON CARRITO.CODIGO_PRODUCTO = PRODUCTO_ROPA.CODIGO_PRODUCTO " +
                                     "INNER JOIN USUARIOS ON USUARIOS.CORREO_ELECTRONICO = CARRITO.CORREO_ELECTRONICO WHERE USUARIOS.CORREO_ELECTRONICO = '" + CorreoUsuario + "'";

                    SqlConnection SqlServer = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Command, con);

                    LblTotalPago.Text = "Total: " + Convert.ToString(cmd.ExecuteScalar());

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void BtnPagar_Click(object sender, EventArgs e)
        {

        }
    }
}