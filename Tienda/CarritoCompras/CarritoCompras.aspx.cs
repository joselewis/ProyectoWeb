using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            CargarCarrito();
        }

        void CargarCarrito()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10");
                string cs = @"DATA SOURCE = LAPTOP-VEC1I0DC; INITIAL CATALOG = TIENDA_VIERNES; USER = JoseLewis10; PASSWORD = joselewis10";

                using (SqlConnection Connection = new SqlConnection(cs))
                {
                    
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}