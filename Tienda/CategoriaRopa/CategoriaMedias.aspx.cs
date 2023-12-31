﻿using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tienda.CategoriaRopa
{
    public partial class CategoriaMedias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarCargarRopa();
        }

        void CargarCategoriaRopa()
        {
            SqlConnection con = new SqlConnection(@"DATA SOURCE = JOSELEWIS; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM PRODUCTO_ROPA INNER JOIN CLASIFICAR_ROPA ON PRODUCTO_ROPA.CODIGO_PRODUCTO = CLASIFICAR_ROPA.CODIGO_PRODUCTO WHERE CATEGORIA_PRENDA = 'Medias'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            DataListCategoriaRopa.DataSource = dt;
            DataListCategoriaRopa.DataBind();
            con.Close();
        }

        void ValidarCargarRopa()
        {
            try
            {
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    var ListadoProductos = ContextoDB.CLASIFICAR_ROPA.Where(s => s.CATEGORIA_PRENDA == "Medias").ToList();

                    if (ListadoProductos.Count >= 1)
                    {
                        CargarCategoriaRopa();
                    }
                    else
                    {
                        LblNoHayNada.Visible = true;
                        LblNoHayNada.Text = "No hay medias disponibles";
                    }
                }
            }
            catch (Exception ex)
            {
                LblNoHayNada.Visible = true;
                LblNoHayNada.Text = ex.Message;
            }
        }
    }
}