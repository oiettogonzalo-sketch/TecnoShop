
using System;
using System.Web.UI.WebControls;

namespace TecnoShop
{
    public partial class Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text.Trim();

            if (nombre == "")
            {
                lblMensaje.Text = "Ingresá el nombre de un producto.";
                gvProductos.Visible = false;
                return;
            }

            lblMensaje.Text = "";
            gvProductos.Visible = true;

            sqlProductos.SelectParameters["nombre"].DefaultValue = nombre;

            gvProductos.DataBind();
        }


        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            lblMensaje.Text = "";

            sqlProductos.SelectParameters["nombre"].DefaultValue = "";

            gvProductos.DataBind();
        }
    }
}
