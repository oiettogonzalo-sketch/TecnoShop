
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modificacion.aspx.cs" Inherits="TecnoShop.Modificacion" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Modificación de productos</title>
    <link href="Content/estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <h1>TecnoShop - Modificación de productos</h1>

            <asp:TextBox ID="txtId" runat="server"
                placeholder="Código del Artículo" />

            <br />

            <asp:Button ID="btnBuscar" runat="server"
                Text="Buscar Artículo"
                OnClick="btnBuscar_Click" />

            <br /><br />

            <asp:TextBox ID="txtNombre" runat="server"
                placeholder="Nuevo Nombre" />

            <br />

            <asp:TextBox ID="txtPrecio" runat="server"
                placeholder="Nuevo Precio" />

            <br />

            <asp:DropDownList ID="ddlCategoria" runat="server"
                DataSourceID="sqlCategorias"
                DataTextField="descripcion"
                DataValueField="idCategoria">
            </asp:DropDownList>

            <br />

            <asp:Button ID="btnGuardar" runat="server"
                Text="Guardar Cambios"
                OnClick="btnGuardar_Click" />

            <br /><br />

            <asp:SqlDataSource ID="sqlCategorias" runat="server"
                ConnectionString="<%$ ConnectionStrings:TecnoShopConnection %>"
                SelectCommand="SELECT idCategoria, descripcion FROM categorias ORDER BY descripcion">
            </asp:SqlDataSource>

            <asp:Label ID="lblMensaje" runat="server"
                 CssClass="mensaje"  />

            <br />

            <asp:HyperLink ID="lnkInicio" runat="server"
                NavigateUrl="~/Default.aspx"
                Text="Volver a la página principal" />
        </div>
    </form>
</body>
</html>
