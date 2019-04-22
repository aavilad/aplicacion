using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xtraForm.Libreria
{
    class Constante
    {
        public const string Bonificacion =
                    @"SELECT DISTINCT
                    dbo.Bonificacion.PKID,dbo.Bonificacion.Mecanica, dbo.Bonificacion.TipoMecanica, dbo.Bonificacion.cdProductoRegalo, dbo.Bonificacion.CantidadMinima, 
                    dbo.Bonificacion.CantidadMaxima, dbo.Bonificacion.CantidadRegalo, dbo.Bonificacion.CantidadMaximaPorCliente, dbo.Bonificacion.Stock, 
                    dbo.Bonificacion.StockEntregado, dbo.Bonificacion.TieneExclusion, dbo.Bonificacion.IDBonifcacionExcluida, dbo.Bonificacion.cdProductoVenta, 
                    dbo.Bonificacion.IDProveedor, dbo.Bonificacion.Desde, dbo.Bonificacion.Hasta, dbo.Bonificacion.Activo, dbo.PROVEEDOR.RazonSocial AS Proveedor, 
                    dbo.TipoAsociado.Codigo AS Asociado
                    FROM
                    dbo.Bonificacion INNER JOIN
                    dbo.PROVEEDOR ON dbo.Bonificacion.IDProveedor = dbo.PROVEEDOR.Proveedor INNER JOIN
                    dbo.ItemBonificacion ON dbo.Bonificacion.PKID = dbo.ItemBonificacion.IDBonificacion INNER JOIN
                    dbo.TipoAsociado ON dbo.ItemBonificacion.IDAsociado = dbo.TipoAsociado.PKID";
        public const string MaestroDetalle = @"";
        public const string Pedidos = @"
            SELECT
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
                dbo.Vva_Pedido.Aprobado";
        public const string Existencias = @"
                SELECT  dbo.Vva_Producto.Codigo, dbo.Vva_Producto.Descripcion, dbo.Vva_Producto.Unidad AS Medida, dbo.Vva_Producto.Fisico, dbo.Vva_Producto.Disponible, 
                dbo.PROVEEDOR.RazonSocial AS Proveedor, ISNULL(dbo.MARCA.Descripcion, '') AS Marca, ISNULL(dbo.LINEA.Descripcion, '') AS Linea, ISNULL(dbo.grupo.descrip, 
                '') AS Grupo, ISNULL(dbo.categoria.descrip, '') AS Categoria, ISNULL(dbo.clase.descrip, '') AS Clase, dbo.Vva_Producto.C_MENOR, dbo.Vva_Producto.C_MAYOR, 
                dbo.Vva_Producto.CR_MENOR, dbo.Vva_Producto.CR_MAYOR, dbo.Vva_Producto.ESPECIAL05, dbo.Vva_Producto.ESPECIAL06, dbo.Vva_Producto.ESPECIAL07, 
                dbo.Vva_Producto.sku, dbo.Vva_Producto.EAN, dbo.Vva_Producto.Web, dbo.Vva_Producto.Dms, dbo.Vva_Producto.Activo
                FROM    dbo.PROVEEDOR INNER JOIN
                dbo.Vva_Producto ON dbo.PROVEEDOR.Proveedor = dbo.Vva_Producto.IDProv RIGHT OUTER JOIN
                dbo.grupo ON dbo.Vva_Producto.IDGrupo = dbo.grupo.grupo LEFT OUTER JOIN
                dbo.clase ON dbo.Vva_Producto.IDClase = dbo.clase.clase RIGHT OUTER JOIN
                dbo.MARCA INNER JOIN
                dbo.LINEA ON dbo.MARCA.Linea = dbo.LINEA.Linea ON dbo.Vva_Producto.IDMarca = dbo.MARCA.Marca LEFT OUTER JOIN
                dbo.categoria ON dbo.Vva_Producto.IDCategoria = dbo.categoria.categoria                
                ";
        public const string Mapa_Table = @"SELECT columna.name
                                       FROM sys.columns columna
                                            INNER JOIN sys.tables tabla ON columna.object_id = tabla.object_id
                                       WHERE tabla.name = ";
        public const string Mapa_View = @"SELECT columna.name
                                       FROM sys.columns columna
                                            INNER JOIN sys.views tabla ON columna.object_id = tabla.object_id
                                       WHERE tabla.name = ";

    }
}
