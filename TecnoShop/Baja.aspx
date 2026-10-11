
<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Baja.aspx.cs"
    Inherits="TecnoShop.Baja" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Baja de productos - TecnoShop</title>
    <link href="Content/estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <h1>TecnoShop - Baja de productos</h1>

            <p>
                Buscar producto:
                <asp:TextBox ID="txtBuscar" runat="server" />

                <asp:Button ID="btnBuscar" runat="server"
                    Text="Buscar"
                    OnClick="btnBuscar_Click" />

                <asp:Button ID="btnLimpiar" runat="server"
                    Text="Limpiar"
                    OnClick="btnLimpiar_Click"
                    CausesValidation="false" />
            </p>

            <asp:Label ID="lblMensaje" runat="server"
                ForeColor="Red" />

            <br /><br />

            <asp:GridView ID="gvProductos" runat="server"
                AutoGenerateColumns="False"
                DataSourceID="sqlProductos"
                DataKeyNames="idProducto"
                EmptyDataText="No se encontraron productos."
                CellPadding="5"
                OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">

                <Columns>
                    <asp:CommandField ShowSelectButton="True"
                        SelectText="Seleccionar" />

                    <asp:BoundField DataField="idProducto"
                        HeaderText="ID" />

                    <asp:BoundField DataField="nombre"
                        HeaderText="Producto" />

                    <asp:BoundField DataField="precio"
                        HeaderText="Precio"
                        DataFormatString="{0:C2}" />

                    <asp:BoundField DataField="categoria"
                        HeaderText="Categoría" />
                </Columns>
            </asp:GridView>

            <br />

            <asp:Label ID="lblSeleccionado" runat="server" />

            <br /><br />

            <asp:Button ID="btnEliminar" runat="server"
                Text="Eliminar producto seleccionado"
                OnClick="btnEliminar_Click"
                OnClientClick="return confirm('¿Estás seguro de que querés eliminar el producto seleccionado?');"
                Enabled="false" />

            <br /><br />

            <asp:HyperLink ID="lnkInicio" runat="server"
                NavigateUrl="~/Default.aspx"
                Text="Volver al inicio" />

            <asp:SqlDataSource ID="sqlProductos" runat="server"
                ConnectionString="<%$ ConnectionStrings:TecnoShopConnection %>"
                SelectCommand="
                    SELECT p.idProducto, p.nombre, p.precio,
                           c.descripcion AS categoria
                    FROM productos p
                    INNER JOIN categorias c
                        ON p.idCategoria = c.idCategoria
                    WHERE p.nombre LIKE '%' + @nombre + '%'
                    ORDER BY p.nombre">

                <SelectParameters>
                    <asp:Parameter Name="nombre" Type="String"
                        DefaultValue="" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
