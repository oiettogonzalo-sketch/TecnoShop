
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TecnoShop
{
    public partial class Modificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(txtId.Text, out id))
            {
                lblMensaje.Text = "Ingresá un código válido.";
                return;
            }

            string s = ConfigurationManager
                .ConnectionStrings["TecnoShopConnection"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(s))
            {
                string consulta = "SELECT nombre, precio, idCategoria FROM productos WHERE idProducto=@id";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();
                SqlDataReader registro = comando.ExecuteReader();

                if (registro.Read())
                {
                    txtNombre.Text = registro["nombre"].ToString();
                    txtPrecio.Text = registro["precio"].ToString();
                    ddlCategoria.SelectedValue =
                        registro["idCategoria"].ToString();

                    lblMensaje.Text = "Artículo encontrado.";
                }
                else
                {
                    txtNombre.Text = "";
                    txtPrecio.Text = "";
                    lblMensaje.Text = "No existe un artículo con ese código.";
                }

                registro.Close();
                conexion.Close();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int id;
            decimal precio;

            if (!int.TryParse(txtId.Text, out id))
            {
                lblMensaje.Text = "Ingresá un código válido.";
                return;
            }

            if (txtNombre.Text.Trim() == "")
            {
                lblMensaje.Text = "Ingresá el nombre.";
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio < 0)
            {
                lblMensaje.Text = "Ingresá un precio válido.";
                return;
            }

            string s = ConfigurationManager
                .ConnectionStrings["TecnoShopConnection"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(s))
            {
                conexion.Open();

                string consulta = "SELECT nombre, precio, idCategoria FROM productos WHERE idProducto=@id";
                SqlCommand buscar = new SqlCommand(consulta, conexion);
                buscar.Parameters.AddWithValue("@id", id);

                SqlDataReader registro = buscar.ExecuteReader();

                if (!registro.Read())
                {
                    registro.Close();
                    lblMensaje.Text = "No existe ese artículo.";
                    return;
                }

                string nombreAnterior = registro["nombre"].ToString();
                decimal precioAnterior = Convert.ToDecimal(registro["precio"]);
                int categoriaAnterior = Convert.ToInt32(registro["idCategoria"]);

                registro.Close();

                int categoriaNueva = Convert.ToInt32(ddlCategoria.SelectedValue);

                if (nombreAnterior == txtNombre.Text.Trim()
                    && precioAnterior == precio
                    && categoriaAnterior == categoriaNueva)
                {
                    lblMensaje.Text = "Modificá al menos un campo.";
                    return;
                }

                SqlCommand modificar = new SqlCommand(
                    "UPDATE productos SET nombre=@nombre, precio=@precio, idCategoria=@categoria WHERE idProducto=@id",
                    conexion);

                modificar.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                modificar.Parameters.AddWithValue("@precio", precio);
                modificar.Parameters.AddWithValue("@categoria", categoriaNueva);
                modificar.Parameters.AddWithValue("@id", id);

                int cantidad = modificar.ExecuteNonQuery();

                if (cantidad > 0)
                    lblMensaje.Text = "Artículo modificado correctamente.";
                else
                    lblMensaje.Text = "No se modificó el artículo.";

                conexion.Close();
            }
        }
    }
}
