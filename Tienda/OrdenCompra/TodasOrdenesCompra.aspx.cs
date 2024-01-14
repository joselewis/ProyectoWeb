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
        string Fecha;
        string Prenda;
        string Cantidad;
        string PrecioPrenda;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ExtraerHistorial();
                //CrearHistorialCompra();  
            }
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

                    SqlCommand cmd = new SqlCommand(Command, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        Label LblPrenda;
                        Label LblCantidad;
                        Label LblFecha;
                        Label LblPrecioPrenda;

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int Contador = 0;

                            LblPrenda = new Label();
                            LblCantidad = new Label();
                            LblFecha = new Label();
                            LblPrecioPrenda = new Label();

                            LblPrenda.Text = dr["TIPO_PRENDA"].ToString();
                            LblCantidad.Text = dr["NUMERO_CANTIDAD"].ToString();
                            LblFecha.Text = dr["FECHA_ORDEN"].ToString();
                            LblPrecioPrenda.Text = dr["PRECIO_PRODUCTO"].ToString();

                            List<int> Cantidades = new List<int>();
                            List<string> Prendas = new List<string>();
                            List<string> Fechas = new List<string>();
                            List<int> Precios = new List<int>();

                            for (int i = 0; i < Fechas.Count; i++)
                            {
                                Cantidades.Add(Convert.ToInt32(LblCantidad));
                                Prendas.Add(Convert.ToString(LblPrenda));
                                Fechas.Add(Convert.ToString(LblFecha));
                                Precios.Add(Convert.ToInt32(LblPrecioPrenda));

                                for (int j = 0; j < Fechas.Count; j++)
                                {
                                    //Falta sacar los datos de las listas
                                }
                            }

                            Fecha = LblFecha.Text;
                            Prenda = LblPrenda.Text;
                            Cantidad = LblCantidad.Text;
                            PrecioPrenda = LblPrecioPrenda.Text;

                            string Historial = "<br/>" +
                            "<div class='accordion' id='accordionPanelsStayOpenExample'>" +
                                "<div class='accordion-item' style='margin-left: 50px; margin-right: 50px;'>" +
                                    "<h2 class='accordion-header'  >" +
                                        "<button class='accordion-button collapsed' type='button' data-bs-toggle='collapse' data-bs-target='#panelsStayOpen-collapseThree' aria-expanded='false' aria-controls='panelsStayOpen-collapseThree'>" +
                                        Fecha +
                                        "</button>" +
                                    "</h2>" +
                                    "<div id='panelsStayOpen-collapseThree' class='accordion-collapse collapse'>" +
                                        "<div class='accordion-body'>" +
                                        "<strong>" +
                                        Prenda + " " + Cantidad + " " + PrecioPrenda +
                                        "</strong>" +
                                        "</strong>" +
                                        "</div>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";

                            Cosa.InnerHtml = Historial;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }
    }
}