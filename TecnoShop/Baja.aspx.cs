
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TecnoShop
{
    public partial class Baja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvProductos.SelectedIndex = -1;
            btnEliminar.Enabled = false;
            lblSeleccionado.Text = "";
            lblMensaje.Text = "";

            sqlProductos.SelectParameters["nombre"].DefaultValue =
                txtBuscar.Text.Trim();

            gvProductos.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            lblMensaje.Text = "";
            lblSeleccionado.Text = "";
            gvProductos.SelectedIndex = -1;
            btnEliminar.Enabled = false;

            sqlProductos.SelectParameters["nombre"].DefaultValue = "";

            gvProductos.DataBind();
        }

        protected void gvProductos_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (gvProductos.SelectedDataKey == null)
                return;

            string nombre = gvProductos.SelectedRow.Cells[2].Text;

            lblSeleccionado.Text =
                "Producto seleccionado: " + nombre;

            btnEliminar.Enabled = true;
            lblMensaje.Text = "";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gvProductos.SelectedDataKey == null)
            {
                lblMensaje.Text = "Primero seleccioná un producto.";
                return;
            }

            int idProducto =
                Convert.ToInt32(gvProductos.SelectedDataKey.Value);

            string cadena = ConfigurationManager
                .ConnectionStrings["TecnoShopConnection"]
                .ConnectionString;

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    string consulta =
                        "DELETE FROM productos WHERE idProducto = @idProducto";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@idProducto", idProducto);

                        conexion.Open();

                        int filas = comando.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            lblMensaje.Text =
                                "Producto eliminado correctamente.";

                            gvProductos.SelectedIndex = -1;
                            lblSeleccionado.Text = "";
                            btnEliminar.Enabled = false;

                            gvProductos.DataBind();
                        }
                        else
                        {
                            lblMensaje.Text =
                                "El producto ya no existe.";
                        }
                    }
                }
            }
            catch (Exception)
            {
                lblMensaje.Text =
                    "No se pudo eliminar el producto. Verificá si tiene registros relacionados.";
            }
        }
    }
}
