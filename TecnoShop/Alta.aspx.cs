using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TecnoShop
{
    public partial class Alta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            string nombre = txtNombre.Text.Trim();
            decimal precio;
            int idCategoria;

            if (nombre == "")
            {
                lblMensaje.Text = "Ingresá el nombre del producto.";
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio < 0)
            {
                lblMensaje.Text = "Ingresá un precio válido.";
                return;
            }

            if (!int.TryParse(ddlCategoria.SelectedValue, out idCategoria))
            {
                lblMensaje.Text = "Seleccioná una categoría válida.";
                return;
            }

            string cadena = ConfigurationManager
                .ConnectionStrings["TecnoShopConnection"]
                .ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = @"INSERT INTO productos
                    (nombre, precio, idCategoria)
                    VALUES (@nombre, @precio, @idCategoria)";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@precio", precio);
                    comando.Parameters.AddWithValue("@idCategoria", idCategoria);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();

                        lblMensaje.Text = "¡Producto registrado correctamente!";

                        txtNombre.Text = "";
                        txtPrecio.Text = "";
                        ddlCategoria.SelectedIndex = 0;
                    }
                    catch (Exception)
                    {
                        lblMensaje.Text = "No se pudo guardar el producto. Verificá la conexión y los datos.";
                    }
                }
            }
        }
    }
}