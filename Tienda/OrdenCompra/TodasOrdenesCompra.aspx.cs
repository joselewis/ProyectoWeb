using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.OrdenCompra
{
    public partial class TodasOrdenesCompra : System.Web.UI.Page
    {
        DateTime Fecha;
        string Prenda;
        int Cantidad;
        int PrecioPrenda;

        List<int> Cantidades = new List<int>();
        List<string> Prendas = new List<string>();
        List<DateTime> Fechas = new List<DateTime>();
        List<int> Precios = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ExtraerHistorial(); 
            CrearHistorialCompra();
        }

        void ExtraerHistorial()
        {
            try
            {
                String Rol = Session["TIPO_USUARIO"].ToString();
                String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();

                if (Rol == "Normal")
                {
                    string cs = @"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
                    SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");

                    string Command = "SELECT TIPO_PRENDA, NUMERO_CANTIDAD, ESTADO_PRODUCTO, PRECIO_PRODUCTO, FECHA_ORDEN FROM HISTORIAL_COMPRAS " +
                                        "INNER JOIN PRODUCTO_ROPA ON PRODUCTO_ROPA.CODIGO_PRODUCTO = HISTORIAL_COMPRAS.CODIGO_PRODUCTO " +
                                        "INNER JOIN CARRITO ON CARRITO.ID_CARRITO = HISTORIAL_COMPRAS.ID_CARRITO " +
                                        "INNER JOIN ORDEN_COMPRA ON ORDEN_COMPRA.CORREO_ELECTRONICO = HISTORIAL_COMPRAS.CORREO_ELECTRONICO " +
                                        "WHERE ORDEN_COMPRA.CORREO_ELECTRONICO = '" + CorreoUsuario + "'";

                    SqlConnection SqlServer = new SqlConnection(cs);
                    con.Open();

                    SqlCommand cmd = new SqlCommand(Command, con);

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        Prenda = Convert.ToString(dr["TIPO_PRENDA"]);
                        Cantidad = Convert.ToInt32(dr["NUMERO_CANTIDAD"]);
                        Fecha = Convert.ToDateTime(dr["FECHA_ORDEN"]);
                        PrecioPrenda = Convert.ToInt32(dr["PRECIO_PRODUCTO"]);

                        for (int i = 0; i < Cantidades.Count; i++)
                        {
                            Cantidades.Add(Cantidad);
                            Prendas.Add(Prenda);
                            Fechas.Add(Fecha);
                            Precios.Add(PrecioPrenda);
                        }

                        con.Close();
                    }  
                }
            }
            catch (Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        void CrearHistorialCompra()
        {
            string Historial = "<br/>" +
                        "<div class='accordion' id='accordionPanelsStayOpenExample'>" +
                            "<div class='accordion-item' style='margin-left: 50px; margin-right: 50px;'>" +
                                "<h2 class='accordion-header'  >" +
                                    "<button class='accordion-button collapsed' type='button' data-bs-toggle='collapse' data-bs-target='#panelsStayOpen-collapseThree' aria-expanded='false' aria-controls='panelsStayOpen-collapseThree'>" +
                                    Fechas +
                                    "</button>" +
                                "</h2>" +
                                "<div id='panelsStayOpen-collapseThree' class='accordion-collapse collapse'>" +
                                    "<div class='accordion-body'>" +
                                    "<strong>" +
                                    Prendas + " x " + Cantidades + " " + Precios +
                                    "</strong>" +
                                    "Hablada se shit" +
                                    "</strong>" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +
                        "</div>";

            Cosa.InnerHtml = Historial;
        }
    }
}