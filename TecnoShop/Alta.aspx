
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alta.aspx.cs" Inherits="TecnoShop.Alta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Alta de productos - TecnoShop</title>
    <link href="Content/Estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor alta-producto">

            <h1>TecnoShop - Alta de productos</h1>

            <p>Completá los datos para registrar un nuevo producto.</p>

            <div class="campo">
                <label for="txtNombre">Nombre del producto</label>

                <asp:TextBox ID="txtNombre" runat="server" />

                <asp:RequiredFieldValidator
                    ID="valNombre"
                    runat="server"
                    ControlToValidate="txtNombre"
                    ErrorMessage="Ingresá el nombre."
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>

            <div class="campo">
                <label for="txtPrecio">Precio</label>

                <asp:TextBox ID="txtPrecio" runat="server" />

                <asp:RequiredFieldValidator
                    ID="valPrecio"
                    runat="server"
                    ControlToValidate="txtPrecio"
                    ErrorMessage="Ingresá el precio."
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>

            <div class="campo">
                <label for="ddlCategoria">Categoría</label>

                <asp:DropDownList ID="ddlCategoria" runat="server"
                    DataSourceID="sqlCategorias"
                    DataTextField="descripcion"
                    DataValueField="idCategoria">
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnGuardar" runat="server"
                Text="Guardar producto"
                OnClick="btnGuardar_Click" />

            <p>
                <asp:Label ID="lblMensaje" runat="server" />
            </p>

            <p>
                <asp:HyperLink ID="lnkInicio" runat="server"
                    NavigateUrl="~/Default.aspx"
                    Text="Volver al inicio" />
            </p>

            <asp:SqlDataSource ID="sqlCategorias" runat="server"
                ConnectionString="<%$ ConnectionStrings:TecnoShopConnection %>"
                SelectCommand="SELECT idCategoria, descripcion FROM categorias ORDER BY descripcion">
            </asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
