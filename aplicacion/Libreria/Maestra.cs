using System.Data;
using System.Data.SqlClient;

namespace xtraForm.Libreria
{
    class Maestra
    {
        string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ToString();

        public DataTable pedido()
        {
            string sql =
            @"
            SELECT top(0)
                dbo.Vva_Pedido.Gestion,
                dbo.Vva_Pedido.FechaEmision,
                dbo.Vva_Pedido.Hora,
                dbo.Vva_Pedido.IDVend AS [cod Vendedor],
                dbo.PERSONAL.Nombre AS [nom Vendedor],
                dbo.Vva_Cliente.Codigo AS [cod Cliente],
                dbo.Vva_Cliente.Nombre AS [nom Cliente],
                dbo.Vva_Cliente.Documento AS [doc Identidad],
                dbo.Vva_ItemPedido.NrPedido AS [num Pedido],
                ISNULL (dbo.DOCUMENTO.TipoDoc,
                        '') AS [Tipo Documento],
                ISNULL (dbo.DOCUMENTO.Generado,
                        '') AS [num Comprobante],
                dbo.Vva_Pedido.TpPago AS [Tipo Condicion],
                dbo.Vva_Pedido.Credito,
                SUM (dbo.Vva_ItemPedido.Precio * dbo.Vva_ItemPedido.Cantidad) AS [Valor Total],
                SUM (dbo.Vva_ItemPedido.Precio * dbo.Vva_ItemPedido.Cantidad - dbo.Vva_ItemPedido.Precio * dbo.Vva_ItemPedido.Cantidad * 0.18) AS 
                    [Valor Venta],
                SUM (dbo.Vva_ItemPedido.Precio * dbo.Vva_ItemPedido.Cantidad * 0.18) AS Igv,
                SUM (dbo.Vva_ItemPedido.Descuento) AS Descuento,
                SUM (dbo.Vva_ItemPedido.Recargo) AS Recargo,
                dbo.Vva_Pedido.Procesado,
                dbo.Vva_Pedido.Bajado,
                dbo.ZONA.Descripcion AS [Zona Venta],
                dbo.Vva_Pedido.Aprobado
            FROM
                dbo.Vva_ItemPedido
                INNER JOIN
                dbo.Vva_Pedido
                ON dbo.Vva_ItemPedido.NrPedido = dbo.Vva_Pedido.NrPedido
                INNER JOIN
                dbo.PERSONAL
                ON dbo.Vva_Pedido.IDVend = dbo.PERSONAL.Personal
                INNER JOIN
                dbo.Vva_Cliente
                ON dbo.Vva_Pedido.IDClient = dbo.Vva_Cliente.Codigo
                INNER JOIN
                dbo.ZONA
                ON dbo.Vva_Cliente.Zona = dbo.ZONA.Zona
                LEFT OUTER JOIN
                dbo.DOCUMENTO
                ON dbo.Vva_Pedido.NrPedido = dbo.DOCUMENTO.Pedido
            GROUP BY
                dbo.Vva_Pedido.Gestion,
                dbo.Vva_Pedido.FechaEmision,
                dbo.Vva_Pedido.Hora,
                dbo.Vva_Pedido.IDVend,
                dbo.PERSONAL.Nombre,
                dbo.Vva_Cliente.Codigo,
                dbo.Vva_Cliente.Nombre,
                dbo.Vva_Cliente.Documento,
                dbo.Vva_ItemPedido.NrPedido,
                ISNULL (dbo.DOCUMENTO.TipoDoc,
                        ''),
                ISNULL (dbo.DOCUMENTO.Generado,
                        ''),
                dbo.Vva_Pedido.TpPago,
                dbo.Vva_Pedido.Credito,
                dbo.ZONA.Descripcion,
                dbo.Vva_Pedido.Bajado,
                dbo.Vva_Pedido.Procesado,
                dbo.Vva_Pedido.Aprobado
            ";
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }
        public DataTable bonificacion()
        {
            string sql =
            @"SELECT DISTINCT top(0)
            dbo.Bonificacion.PKID, dbo.Bonificacion.Mecanica, dbo.Bonificacion.TipoMecanica, dbo.Bonificacion.cdProductoRegalo, dbo.Bonificacion.CantidadMinima, 
            dbo.Bonificacion.CantidadMaxima, dbo.Bonificacion.CantidadRegalo, dbo.Bonificacion.CantidadMaximaPorCliente, dbo.Bonificacion.Stock, 
            dbo.Bonificacion.StockEntregado, dbo.Bonificacion.TieneExclusion, dbo.Bonificacion.IDBonifcacionExcluida, dbo.Bonificacion.cdProductoVenta, 
            dbo.Bonificacion.IDProveedor, dbo.Bonificacion.Desde, dbo.Bonificacion.Hasta, dbo.Bonificacion.Activo, dbo.PROVEEDOR.RazonSocial AS Proveedor, 
            dbo.TipoAsociado.Codigo AS Asociado
            FROM
            dbo.Bonificacion INNER JOIN
            dbo.PROVEEDOR ON dbo.Bonificacion.IDProveedor = dbo.PROVEEDOR.Proveedor INNER JOIN
            dbo.ItemBonificacion ON dbo.Bonificacion.PKID = dbo.ItemBonificacion.IDBonificacion INNER JOIN
            dbo.TipoAsociado ON dbo.ItemBonificacion.IDAsociado = dbo.TipoAsociado.PKID";
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }
        public DataTable Pesos(string fecha, string vendedor, string ruta, bool procesado)
        {
            string sql =
            @"
            SELECT    DISTINCT    
            Documento.TipoDoc,DOCUMENTO.Pedido,Documento.documento, DOCUMENTO.Cliente, CLIENTE.Alias As Nombre, PRODUCTO.Producto, PRODUCTO.Descripcion, PRODUCTO.UniMed, DETADOC.Cantidad
            FROM            
            DOCUMENTO INNER JOIN
            DETADOC ON DOCUMENTO.Documento = DETADOC.Documento AND DOCUMENTO.TipoDoc = DETADOC.TipoDoc INNER JOIN
            PRODUCTO ON DETADOC.Producto = PRODUCTO.Producto INNER JOIN
            CLIENTE ON DOCUMENTO.Cliente = CLIENTE.Cliente INNER JOIN
            MARCA ON PRODUCTO.Marca = MARCA.Marca INNER JOIN
            REPARTO ON DOCUMENTO.Personal = REPARTO.Personal
            WHERE        
            (DOCUMENTO.Procesado = @Procesado) AND (PRODUCTO.linea IN ('B1', 'B4')) AND (DOCUMENTO.TipoDoc IN ('9', '0', 'F', 'B')) AND 
            (DOCUMENTO.Fecha = @Fecha) AND (MARCA.Proveedor = '264') AND (Ruta = @Ruta or @Ruta = '*') AND (Dia = DATEPART(DW,@Fecha)) AND ((documento.personal = @Vendedor)or(@Vendedor = '*'))
            union all
            SELECT   DISTINCT     
            Documento.TipoDoc,DOCUMENTO.Pedido,Documento.documento, DOCUMENTO.Cliente, CLIENTE.Alias As Nombre, PRODUCTO.Producto, PRODUCTO.Descripcion, PRODUCTO.UniMed, DETADOC.Cantidad
            FROM           
            DOCUMENTO INNER JOIN
            DETADOC ON DOCUMENTO.Documento = DETADOC.Documento AND DOCUMENTO.TipoDoc = DETADOC.TipoDoc INNER JOIN
            PRODUCTO ON DETADOC.Producto = PRODUCTO.Producto INNER JOIN
            CLIENTE ON DOCUMENTO.Cliente = CLIENTE.Cliente INNER JOIN
            MARCA ON PRODUCTO.Marca = MARCA.Marca INNER JOIN
            REPARTO ON DOCUMENTO.Personal = REPARTO.Personal
            WHERE        
            (DOCUMENTO.Procesado = @Procesado) AND (PRODUCTO.Producto = '35068') AND (DOCUMENTO.TipoDoc IN ('9', '0', 'F', 'B')) AND 
            (DOCUMENTO.Fecha = @Fecha) AND (MARCA.Proveedor = '264') AND (Ruta = @Ruta or @Ruta = '*') AND (Dia = DATEPART(DW,@Fecha)) AND ((documento.personal = @Vendedor)or(@Vendedor = '*'))";
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                cmd.Parameters.AddWithValue("@Ruta", ruta);
                cmd.Parameters.AddWithValue("@Vendedor", vendedor);
                cmd.Parameters.AddWithValue("@Procesado", procesado);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }
        public DataTable Comprobantes()
        {
            string sql =
            @"
            SELECT   top(0)     
            dbo.Vva_Cp.Gestion, dbo.Vva_Cp.Fecha, dbo.Vva_Cp.hora, dbo.Vva_Cp.TpDoc As [Tipo Docum], dbo.Vva_Cp.NrDoc as [Num Documento], dbo.Vva_Cp.IDVendedor AS [Codigo Vendedor], 
            RTRIM(dbo.PERSONAL.Nombre) AS [nombre Vendedor], dbo.Vva_Cp.IDCliente AS [Codigo Cliente], RTRIM(dbo.Vva_Cliente.Nombre) AS [Nombre Cliente], 
            dbo.Vva_Cliente.Documento AS [Docum Identidad], RTRIM(dbo.Vva_Cliente.Direccion) AS Direccion, RTRIM(dbo.ZONA.Descripcion) AS [Zona Venta], 
            dbo.Vva_Cp.IDpedido AS [Num Pedido], dbo.Vva_Cp.NrDocRef AS [Docum Referencia], dbo.Vva_Cp.Comprobante, dbo.Vva_Cp.Credito, 
            SUM(dbo.Vva_ItemCp.Cantidad * dbo.Vva_ItemCp.Precio - dbo.Vva_ItemCp.igv) AS [Valor Venta], SUM(dbo.Vva_ItemCp.Cantidad * dbo.Vva_ItemCp.Precio) 
            AS [Valor Total], dbo.Vva_Cp.afecto, dbo.Vva_Cp.inafecto, dbo.Vva_Cp.igv, dbo.Vva_Cp.Anulado
            FROM            
            dbo.Vva_Cp INNER JOIN
            dbo.Vva_ItemCp ON dbo.Vva_Cp.NrDoc = dbo.Vva_ItemCp.NrDoc AND dbo.Vva_Cp.TpDoc = dbo.Vva_ItemCp.TpDoc INNER JOIN
            dbo.PERSONAL ON dbo.Vva_Cp.IDVendedor = dbo.PERSONAL.Personal INNER JOIN
            dbo.Vva_Cliente ON dbo.Vva_Cp.IDCliente = dbo.Vva_Cliente.Codigo INNER JOIN
            dbo.ZONA ON dbo.Vva_Cliente.Zona = dbo.ZONA.Zona
            GROUP BY 
            dbo.Vva_Cp.Gestion, dbo.Vva_Cp.Fecha, dbo.Vva_Cp.hora, dbo.Vva_Cp.TpDoc, dbo.Vva_Cp.NrDoc, dbo.Vva_Cp.IDVendedor, RTRIM(dbo.PERSONAL.Nombre), 
            dbo.Vva_Cp.IDCliente, RTRIM(dbo.Vva_Cliente.Nombre), dbo.Vva_Cliente.Documento, RTRIM(dbo.Vva_Cliente.Direccion), RTRIM(dbo.ZONA.Descripcion), 
            dbo.Vva_Cp.IDpedido, dbo.Vva_Cp.NrDocRef, dbo.Vva_Cp.Comprobante, dbo.Vva_Cp.Credito, dbo.Vva_Cp.afecto, dbo.Vva_Cp.inafecto, dbo.Vva_Cp.igv, 
            dbo.Vva_Cp.Anulado
           ";
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }

    }
}
