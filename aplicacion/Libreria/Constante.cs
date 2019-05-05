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
                dbo.Vva_Pedido.NrPedido AS [num Pedido],
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
                dbo.Vva_Pedido.NrPedido,
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
                 SELECT Vva_Producto.Codigo, 
                 Vva_Producto.Descripcion, 
                 Vva_Producto.Unidad AS Medida_, 
                 ISNULL(PlantillaUnidad.Abreviacion, '') AS Medida, 
                 Vva_Producto.Fisico, 
                 Vva_Producto.Disponible, 
                 PROVEEDOR.RazonSocial AS Proveedor, 
                 ISNULL(MARCA.Descripcion, '') AS Marca, 
                 ISNULL(LINEA.Descripcion, '') AS Linea, 
                 ISNULL(grupo.descrip, '') AS Grupo, 
                 ISNULL(categoria.descrip, '') AS Categoria, 
                 ISNULL(clase.descrip, '') AS Clase, 
                 Vva_Producto.C_MENOR, 
                 Vva_Producto.C_MAYOR, 
                 Vva_Producto.CR_MENOR, 
                 Vva_Producto.CR_MAYOR, 
                 Vva_Producto.ESPECIAL05, 
                 Vva_Producto.ESPECIAL06, 
                 Vva_Producto.ESPECIAL07, 
                 Vva_Producto.sku, 
                 Vva_Producto.EAN, 
                 Vva_Producto.Web, 
                 Vva_Producto.Dms, 
                 Vva_Producto.Activo
                 FROM PROVEEDOR
                 INNER JOIN Vva_Producto ON PROVEEDOR.Proveedor = Vva_Producto.IDProv
                 LEFT OUTER JOIN PlantillaUnidad ON Vva_Producto.IDUnidad = PlantillaUnidad.PKID
                 LEFT OUTER JOIN clase ON Vva_Producto.IDClase = clase.clase
                 LEFT OUTER JOIN categoria ON Vva_Producto.IDCategoria = categoria.categoria
                 LEFT OUTER JOIN MARCA
                 INNER JOIN LINEA ON MARCA.Linea = LINEA.Linea ON Vva_Producto.IDMarca = MARCA.Marca
                 LEFT OUTER JOIN grupo ON Vva_Producto.IDGrupo = grupo.grupo
                ";
        public const string Mapa_Table = @"SELECT columna.name
                                       FROM sys.columns columna
                                            INNER JOIN sys.tables tabla ON columna.object_id = tabla.object_id
                                       WHERE tabla.name = ";
        public const string Mapa_View = @"SELECT columna.name
                                       FROM sys.columns columna
                                            INNER JOIN sys.views tabla ON columna.object_id = tabla.object_id
                                       WHERE tabla.name = ";
        public const string Marcas = @"
                SELECT PROVEEDOR.RazonSocial AS Proveedor,
                MARCA.Marca AS Codigo, 
                MARCA.Descripcion, 
                LINEA.Descripcion AS Linea
                FROM MARCA
                INNER JOIN PROVEEDOR ON MARCA.Proveedor = PROVEEDOR.Proveedor
                INNER JOIN LINEA ON MARCA.Linea = LINEA.Linea;
                ";
        public const string ProductoEscala = @"
                SELECT        
                PROVEEDOR.RazonSocial AS Proveedor, Vva_ProductoEscala.Codigo, Vva_ProductoEscala.Descripcion, Vva_ProductoEscala.Unidad_, Vva_ProductoEscala.Unidad, Vva_ProductoEscala.C_MENOR, 
                Vva_ProductoEscala.C_MAYOR, Vva_ProductoEscala.CR_MENOR, Vva_ProductoEscala.CR_MAYOR, Vva_ProductoEscala.ESPECIAL05, Vva_ProductoEscala.ESPECIAL06, Vva_ProductoEscala.ESPECIAL07, 
                Vva_ProductoEscala.ValorMinEspecial, Vva_ProductoEscala.ValorMinMayorista
                FROM
                PROVEEDOR INNER JOIN Vva_ProductoEscala ON PROVEEDOR.Proveedor = Vva_ProductoEscala.IDProv";

    }
}
