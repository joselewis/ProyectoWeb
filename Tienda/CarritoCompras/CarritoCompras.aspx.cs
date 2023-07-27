﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.CarritoCompras
{
    public partial class CarritoCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCarrito();
                LabelCarrito();
            }
        }

        void CargarCarrito()
        {
            String CorreoUsuario = Session["CORREO_ELECTRONICO"].ToString();
            string cs = @"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";
            SqlConnection con = new SqlConnection(@"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
            string Command = "SELECT TIPO_PRENDA, PRECIO_PRODUCTO, CANTIDAD_PRODUCTO, TALLA_PRENDA, MARCA, NUMERO_CANTIDAD, ID_CARRITO  FROM PRODUCTO_ROPA " +
                             "INNER JOIN CARRITO ON CARRITO.CODIGO_PRODUCTO = PRODUCTO_ROPA.CODIGO_PRODUCTO " +
                             "INNER JOIN USUARIOS ON USUARIOS.CORREO_ELECTRONICO = CARRITO.CORREO_ELECTRONICO WHERE USUARIOS.CORREO_ELECTRONICO ='" + CorreoUsuario + "'";

            SqlCommand SqlCommand = new SqlCommand(Command, con);

            con.Open();

            SqlDataAdapter Adapter = new SqlDataAdapter(SqlCommand);

            DataTable dt = new DataTable();

            Adapter.Fill(dt);
            GridViewCarrito.DataSource = dt;
            GridViewCarrito.DataBind();
            con.Close();
        }

        void LabelCarrito()
        {
            try
            {
                if (GridViewCarrito.Rows.Count <= 0)
                {
                    LblCarritoVacio.Visible = true;
                    LblCarritoVacio.Text = "No hay productos añadidos al carrito";
                }
                else
                {
                    LblCarritoVacio.Visible = false;
                }
            }
            catch(Exception ex)
            {
                LblError.Visible = true;
                LblError.Text = ex.Message;
            }
        }

        protected void GridViewCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (TIENDA_VIERNESEntities ContextoDB = new TIENDA_VIERNESEntities())
                {
                    int CarritoId = Convert.ToInt32(GridViewCarrito.DataKeys[e.RowIndex].Value);

                    CARRITO objCarrito = ContextoDB.CARRITOes.First(x => x.ID_CARRITO == CarritoId);
                    ContextoDB.CARRITOes.Remove(objCarrito);
                    ContextoDB.SaveChanges();
                    LblCarritoVacio.Visible = false;
                    CargarCarrito();

                    Response.Redirect("../CarritoCompras/CarritoCompras.aspx");
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