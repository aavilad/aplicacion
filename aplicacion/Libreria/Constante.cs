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
        public const string EntidadRutasAsignacion = @"
        SELECT RUTAS.codigo, 
               RUTAS.descripcion
        FROM RUTAS
             FULL OUTER JOIN REPARTO ON RUTAS.codigo = REPARTO.Ruta
        WHERE(REPARTO.Ruta IS NULL);";
        public const string PedidoRecalculo = @"
                UPDATE detpedido
          SET 
              PrecioNeto = PrecUnit
        WHERE PrecioNeto IS NULL;
        --
        UPDATE detpedido
          SET 
              PrecioUnitario =
        (
            SELECT CASE
                       WHEN DETPEDIDO.TipoPrecio = 1
                       THEN PrecMenContado
                       WHEN DETPEDIDO.TipoPrecio = 2
                       THEN PrecMayContado
                       WHEN DETPEDIDO.TipoPrecio = 3
                       THEN PrecMenCredito
                       WHEN DETPEDIDO.TipoPrecio = 4
                       THEN PrecMayCredito
                       WHEN DETPEDIDO.TipoPrecio = 5
                       THEN PrecEspecial
                       WHEN DETPEDIDO.TipoPrecio = 6
                       THEN PrecSEspecial
                       WHEN DETPEDIDO.TipoPrecio = 7
                       THEN PrecSSEspecial
                   END
            FROM PRODUCTO
            WHERE Producto = DETPEDIDO.Producto
        )
        WHERE PrecioUnitario IS NULL;
        --
        UPDATE detpedido
          SET 
              Descuento = IIF((PrecioUnitario - PrecioNeto) < 0, 0, (PrecioUnitario - PrecioNeto))
        WHERE Descuento IS NULL;
        --
        UPDATE detpedido
          SET 
              Recargo = IIF((PrecioNeto - PrecioUnitario) < 0, 0, (PrecioNeto - PrecioUnitario))
        WHERE Recargo IS NULL;
        --
        UPDATE detpedido
          SET 
              Afecto =
        (
            SELECT conigv
            FROM PRODUCTO
            WHERE Producto = DETPEDIDO.Producto
        )
        WHERE Afecto IS NULL;
        --
        UPDATE detpedido
          SET 
              Bonif = CASE
                          WHEN PrecUnit = 0.00
                          THEN 1
                          WHEN IDBonificacion > 0
                          THEN 1
                          ELSE 0
                      END
        WHERE Bonif IS NULL;
        --
        UPDATE pedido
          SET 
              Aprobado = 1
        WHERE Aprobado IS NULL;
        ";
        public const string Cliente = @"select Codigo,Nombre,Documento,Direccion from Vva_Cliente where Estado = 'A'";
        public const string ClienteVendedor = @"SELECT Codigo, Nombre, Documento,Direccion FROM Vva_Clientevendedor WHERE (Dia = DATEPART(dw, '@Fecha')) AND (Personal = '@Vendedor')";
        public const string Filtro = @"SELECT campo, condicion, valor,[union] from filtro WHERE tabla = '@Tabla' ORDER BY Orden ASC";
        public const string Cartera = @"
        SELECT DISTINCT 
               dbo.Vva_Cliente.Codigo, 
               dbo.Vva_Cliente.Nombre, 
               dbo.Vva_Cliente.Direccion
        FROM dbo.Vva_Cliente
             INNER JOIN dbo.ZONA ON dbo.Vva_Cliente.Zona = dbo.ZONA.Zona
        WHERE(dbo.Vva_Cliente.Zona = @Zona);";

        public const string Cobertura = @"
        SELECT DISTINCT 
               Vva_Cliente_1.Codigo, 
               Vva_Cliente_1.Nombre, 
               Vva_Cliente_1.Direccion
        FROM Vva_Cp
             INNER JOIN Vva_Cliente AS Vva_Cliente_1 ON Vva_Cp.IDCliente = Vva_Cliente_1.Codigo
             INNER JOIN Vva_ItemCp ON Vva_Cp.NrDoc = Vva_ItemCp.NrDoc
                                      AND Vva_Cp.TpDoc = Vva_ItemCp.TpDoc
             INNER JOIN Vva_Producto ON Vva_ItemCp.IDProducto = Vva_Producto.Codigo
             INNER JOIN ZONA AS ZONA_1 ON Vva_Cliente_1.Zona = ZONA_1.Zona
        WHERE(Vva_Cp.Anulado = 0)
             AND (Vva_Cp.Fecha BETWEEN @Desde AND @Hasta) AND (Vva_Cliente_1.Zona = @IDZONA) AND (Vva_Producto.@variable)
        GROUP BY Vva_Cliente_1.Codigo, 
                 Vva_Cliente_1.Nombre,
                 Vva_Cliente_1.Direccion";
        public const string AvanceCobertura = @"
                    WITH CTE_Zonas
                                  AS (SELECT DISTINCT 
                                             ZONA.Zona, 
                                             ZONA.Descripcion, 
                                             COUNT(DISTINCT Vva_Cliente.Codigo) AS Cartera, 
                                             0.00 AS Cobertura
                                      FROM Vva_Cliente
                                           INNER JOIN ZONA ON Vva_Cliente.Zona = ZONA.Zona
                                      GROUP BY ZONA.Zona, 
                                               ZONA.Descripcion
                                      UNION ALL
                                      SELECT DISTINCT 
                                             ZONA_1.Zona, 
                                             ZONA_1.Descripcion, 
                                             0.00 AS Cartera, 
                                             COUNT(DISTINCT Vva_Cliente_1.Codigo) AS Cobertura
                                      FROM Vva_Cp
                                           INNER JOIN Vva_Cliente AS Vva_Cliente_1 ON Vva_Cp.IDCliente = Vva_Cliente_1.Codigo
                                           INNER JOIN Vva_ItemCp ON Vva_Cp.NrDoc = Vva_ItemCp.NrDoc
                                                                    AND Vva_Cp.TpDoc = Vva_ItemCp.TpDoc
                                           INNER JOIN Vva_Producto ON Vva_ItemCp.IDProducto = Vva_Producto.Codigo
                                           INNER JOIN ZONA AS ZONA_1 ON Vva_Cliente_1.Zona = ZONA_1.Zona
                                      WHERE(Vva_Cp.Anulado = 0)
                                           AND (Vva_Cp.Fecha BETWEEN @Desde AND @Hasta) AND (Vva_Producto.@variable)
                                      GROUP BY ZONA_1.Zona, 
                                               ZONA_1.Descripcion)
                                         SELECT RTRIM(Zona) AS Codigo, 
                                                RTRIM(Descripcion) AS Descripcion, 
                                                SUM(Cartera) AS Cartera, 
                                                SUM(Cobertura) / SUM(Cartera) AS Avance, 
                                                SUM(Cobertura) AS Cobertura,
                                                SUM(Cartera)-SUM(Cobertura) As Diferencia
                                         FROM CTE_Zonas AS CTE_Zonas_1
                                         GROUP BY Zona, 
                                                  Descripcion;
                    ";
        public const string Diferencia = @"
                            DECLARE @Universo TABLE
                (Codigo    VARCHAR(20), 
                 Nombre    VARCHAR(70), 
                 Direccion VARCHAR(70)
                );
                
                DECLARE @Visitados TABLE
                (Codigo    VARCHAR(20), 
                 Nombre    VARCHAR(70), 
                 Direccion VARCHAR(70)
                );
                
                INSERT INTO @Universo
                       SELECT DISTINCT 
                              dbo.Vva_Cliente.Codigo, 
                              dbo.Vva_Cliente.Nombre, 
                              dbo.Vva_Cliente.Direccion
                       FROM dbo.Vva_Cliente
                            INNER JOIN dbo.ZONA ON dbo.Vva_Cliente.Zona = dbo.ZONA.Zona
                       WHERE(dbo.Vva_Cliente.Zona = @IDZONA);
                INSERT INTO @Visitados
                       SELECT DISTINCT 
                              Vva_Cliente.Codigo, 
                              Vva_Cliente.Nombre, 
                              Vva_Cliente.Direccion
                       FROM Vva_Cp
                            INNER JOIN Vva_Cliente ON Vva_Cp.IDCliente = Vva_Cliente.Codigo
                            INNER JOIN Vva_ItemCp ON Vva_Cp.NrDoc = Vva_ItemCp.NrDoc
                                                     AND Vva_Cp.TpDoc = Vva_ItemCp.TpDoc
                            INNER JOIN Vva_Producto ON Vva_ItemCp.IDProducto = Vva_Producto.Codigo
                       WHERE(Vva_Cp.Anulado = 0)
                            AND (Vva_Cp.Fecha BETWEEN @Desde AND @Hasta)
                            AND (Vva_Cliente.Zona = @IDZONA)
                            AND (Vva_Producto.@variable);
                SELECT u.*
                FROM @Universo U
                     FULL OUTER JOIN @Visitados V ON u.Codigo = V.Codigo
                WHERE v.Codigo IS NULL";
        public const string SinStock = "Cantidad de stock es insuficiente :";
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
        public const string Compras = @"
                            SELECT
                            TOP (100) PERCENT 
                              FechaEmision		=	DOCUMENTO.Fecha
                            , NroDocumento		=	DOCUMENTO.Documento
                            , Referencia		=	referencia.tdrefer + '-' + referencia.ndrefer
                            , Proveedor			=	RTRIM(PROVEEDOR.RazonSocial)
                            , Ingreso			=	DOCUMENTO.TipoIng
                            , PLinea			=	ISNULL(grupo.descorta, '')
                            , PCodigo			=	RTRIM(PRODUCTO.Producto)
                            , PDescripcion		=	RTRIM(PRODUCTO.Descripcion)
                            , PMedida			=	PRODUCTO.UniMed
                            , PCantidad			=	DETADOC.Cantidad
                            , PPeso				=	PRODUCTO.Peso
                            , PCosto			=	DETADOC.PrecUnit
                            , PCostoPromedio	=	PRODUCTO.Costo
                            , ValorIGV  		=	DETADOC.Igv
                            , ValorTotal		=	DETADOC.Cantidad * DETADOC.PrecUnit
                            , DETADOC.Estado
                            , DOCUMENTO.observacion
                            FROM            
                            DOCUMENTO INNER JOIN
                            DETADOC ON DOCUMENTO.Documento = DETADOC.Documento AND DOCUMENTO.TipoDoc = DETADOC.TipoDoc INNER JOIN
                            PRODUCTO ON DETADOC.Producto = PRODUCTO.Producto INNER JOIN
                            MARCA ON PRODUCTO.Marca = MARCA.Marca INNER JOIN
                            PROVEEDOR ON MARCA.Proveedor = PROVEEDOR.Proveedor INNER JOIN
                            referencia ON DOCUMENTO.TipoDoc = referencia.tipodoc AND DOCUMENTO.Documento = referencia.documento LEFT OUTER JOIN
                            grupo ON PRODUCTO.grupo = grupo.grupo
                            WHERE DOCUMENTO.TipoDoc IN ('A', '3') and documento.fecha between '@FechaInicio' and '@FechaFin' AND (PROVEEDOR.Proveedor IN('@Prov'))
                            ORDER BY FechaEmision, NroDocumento";
    }
}
