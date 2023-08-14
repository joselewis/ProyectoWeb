using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Tienda.Deposito
{
    public partial class DepositoTarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void Deposito()
        {
            try
            {
                using (TIENDA_VIERNESEntities1 ContextoDB = new TIENDA_VIERNESEntities1())
                {
                    DINERO_PAGO oDinero = new DINERO_PAGO();

                    oDinero.CANTIDAD_DISPONIBLE = Convert.ToInt32(CajaDepositoDinero.Text);
                    oDinero.NUMERO_TARJETA = Convert.ToInt64(CajaTarjetaDeposito.Text);
                    
                    ContextoDB.DINERO_PAGO.Add(oDinero);
                    ContextoDB.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                lblErrorDeposito.Visible = true;
                lblErrorDeposito.Text = ex.Message;
            }
        }

        protected void Btn_Depositar_Click(object sender, EventArgs e)
        {
            Deposito();
        }
    }
}