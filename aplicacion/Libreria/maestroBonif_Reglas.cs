using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace xtraForm.Libreria
{
    class maestroBonif_Reglas
    {
        string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ToString();
        //
        public void Descargar_Pedidos_Web(string fecha)
        {
            string QUERY = @"
             DECLARE @PEDIDOS VARCHAR(20),@TIPOPER INT,@TIPODOC CHAR(1)
             DECLARE PEDIDOS CURSOR FOR SELECT  Pedido, TipoPersona, tipodoc FROM PEDIDO WHERE (Fecha = @Fecha) and Personal not in ('18','13','27','42') and (gestion = '01') and (Procesado = 0) and (statusweb = 0) 
             OPEN PEDIDOS FETCH FROM PEDIDOS INTO @PEDIDOS,@TIPOPER,@TIPODOC
             WHILE @@FETCH_STATUS = 0
             BEGIN
             	EXEC sp_genera_documento @PEDIDOS,@TIPOPER,@TIPODOC
                update pedido set statusweb = 1 where pedido = @PEDIDOS and tipodoc = @TIPODOC
             	FETCH NEXT FROM PEDIDOS INTO @PEDIDOS,@TIPOPER,@TIPODOC
             END
             CLOSE PEDIDOS
             DEALLOCATE PEDIDOS
                            ";
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction transaccion = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(QUERY, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Fecha", fecha);
                        cmd.Transaction = transaccion;
                        cmd.ExecuteNonQuery();
                    }
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void precioBonificacion()
        {
            string QUERY = @"
            UPDATE DETPEDIDO 
            SET PrecUnit = 0.00
            FROM            
            DETPEDIDO INNER JOIN PRODUCTO ON DETPEDIDO.Producto = PRODUCTO.Producto INNER JOIN PEDIDO ON DETPEDIDO.Pedido = PEDIDO.Pedido
            WHERE
            PEDIDO.Fecha = REPLACE(CONVERT(varchar(10),GETDATE(),120),'-','') AND DETPEDIDO.PrecUnit = 0.01 and Producto.Descripcion like 'oft%'
                            ";
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction transaccion = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(QUERY, con))
                    {
                        cmd.Transaction = transaccion;
                        cmd.ExecuteNonQuery();
                    }
                    transaccion.Commit();
                }
                catch (Exception exc)
                {
                    transaccion.Rollback();
                    MessageBox.Show(exc.Message);
                }

            }
        }
        public void horasBonificacion()
        {
            string QUERY = @"UPDATE PEDIDO SET FECHA = REPLACE(CONVERT(VARCHAR(10),Fecha,120),'-','')";
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction transaccion = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(QUERY, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaccion;
                        cmd.ExecuteNonQuery();
                    }
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void deleteBonificacion(string Fecha)
        {
            string QUERY = @"
            DECLARE @PRODUCTO VARCHAR(20)
            DECLARE OFERTAS CURSOR FOR SELECT cdProductoRegalo FROM Bonificacion WHERE (Activo = 1) AND (@FechaProceso >= Desde AND @FechaProceso <= Hasta)
            OPEN OFERTAS FETCH FROM OFERTAS INTO @PRODUCTO
            WHILE @@FETCH_STATUS = 0
            BEGIN
            DELETE DETPEDIDO
            FROM            
            PEDIDO INNER JOIN DETPEDIDO ON PEDIDO.Pedido = DETPEDIDO.Pedido
            WHERE        
            (PEDIDO.Fecha = @FechaProceso) AND (DETPEDIDO.Producto = @PRODUCTO) AND pedido.Procesado = 0
            FETCH NEXT FROM OFERTAS INTO @PRODUCTO
            END
            CLOSE OFERTAS
            DEALLOCATE OFERTAS
                            ";
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction transaccion = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(QUERY, con))
                    {
                        cmd.Parameters.AddWithValue("@FechaProceso", Fecha);
                        cmd.Transaction = transaccion;
                        cmd.ExecuteNonQuery();
                    }
                    transaccion.Commit();
                }
                catch (Exception exc)
                {
                    transaccion.Rollback();
                    MessageBox.Show(exc.Message);
                }

            }
        }
        public void deleteDocumento(string Fecha)
        {

            string sql00 =
            @"delete DETADOC
            FROM DOCUMENTO INNER JOIN DETADOC ON DOCUMENTO.Documento = DETADOC.Documento AND DOCUMENTO.TipoDoc = DETADOC.TipoDoc
            WHERE (DOCUMENTO.Fecha = @Fecha) and gestion = '01' and generado is  null and documento.TipoDoc in ('B','F') and Personal not in ('18','42','13','27') and Procesado = 0";
            string sql01 =
            @"delete DOCUMENTO 
            where Fecha = @Fecha and gestion = '01' and TipoDoc in ('F','B') and Personal not in ('18','42','13','27') and generado is  null and Procesado = 0";
            string sql02 =
            @"update pedido statusweb = 0 
            where Fecha = @Fecha and gestion = '01' and TipoDoc in ('F','B') and Personal not in ('18','42','13','27') and Procesado = 0";

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql00, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Fecha", Fecha);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(sql01, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Fecha", Fecha);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(sql02, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Fecha", Fecha);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public DataTable ListaBonificacion(string Fecha)
        {
            string QUERY = @"SELECT PKID FROM Bonificacion WHERE (Activo = 1) AND (@FechaProceso >= Desde AND @FechaProceso <= Hasta)";
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(QUERY, con))
            {
                cmd.Parameters.AddWithValue("@FechaProceso", Fecha);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }
        public DataTable detalleBonificacion(int IDBonificacion)
        {
            string QUERY =
            @"SELECT        
              dbo.Bonificacion.cdProductoRegalo, dbo.Bonificacion.CantidadMinima, dbo.Bonificacion.CantidadMaxima, dbo.Bonificacion.CantidadRegalo, 
              dbo.Bonificacion.CantidadMaximaPorCliente, dbo.Bonificacion.Stock, dbo.Bonificacion.TieneExclusion, dbo.Bonificacion.IDBonifcacionExcluida, 
              dbo.Bonificacion.TipoMecanica, dbo.ItemBonificacion.IDAsociado
              FROM dbo.Bonificacion INNER JOIN
              dbo.ItemBonificacion ON dbo.Bonificacion.PKID = dbo.ItemBonificacion.PKID
              WHERE (dbo.Bonificacion.PKID = @IDBonificacion)";
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(QUERY, con))
            {
                cmd.Parameters.AddWithValue("@IDBonificacion", IDBonificacion);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }
        public DataTable detallePedido(string numPedido)
        {
            string QUERY = @"SELECT IDBonificacion FROM DETPEDIDO WHERE Pedido = @numPedido";
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(QUERY, con))
            {
                cmd.Parameters.AddWithValue("@numPedido", numPedido);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }
        public bool insertObsequio(int IDBonificacion, string numPedido, string cdProductoRegalo, decimal CantidadRegaloFinal)
        {
            string QUERY =
            @"INSERT INTO DETPEDIDO (Pedido,Producto,PrecUnit,Cantidad,Estado,TipoPrecio,TranGratuita,lote,fvctolote,flgSurtido,IDBonificacion,PrecioNeto,Descuento,Recargo,Afecto,Bonif) 
            VALUES (@numPedido,@cdProductoRegalo,0.00,@CantidadRegaloFinal,'P',1,0.00,NULL,NULL,NULL,@IDBonificacion,0.00,0.00,0.00,1,1)
		    UPDATE Bonificacion SET StockEntregado = StockEntregado+@CantidadRegaloFinal WHERE PKID = @IDBonificacion";
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(QUERY, con))
            {
                cmd.Parameters.AddWithValue("@IDBonificacion", IDBonificacion);
                cmd.Parameters.AddWithValue("@numPedido", numPedido);
                cmd.Parameters.AddWithValue("@cdProductoRegalo", cdProductoRegalo);
                cmd.Parameters.AddWithValue("@CantidadRegaloFinal", CantidadRegaloFinal);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void insertBonificacion(int PKID, string Mecanica, int TipoMecanica, string cdProductoRegalo, decimal CantidadMinima, int CantidadMaxima, int CantidadRegalo,
                                     int CantidadMaximaPorCliente, decimal Stock, bool TieneExclusion, int IDBonifcacionExcluida, string cdProductoVenta,
                                     string IDProveedor, string Desde, string Hasta, bool Activo, DataGridView dgv0, int PKIDItemBonificacion, int IDAsociado)
        {
            string sql00 =
            @"INSERT INTO [dbo].[Bonificacion]
            ([PKID]
            ,[Mecanica]
            ,[TipoMecanica]
            ,[cdProductoRegalo]
            ,[CantidadMinima]
            ,[CantidadMaxima]
            ,[CantidadRegalo]
            ,[CantidadMaximaPorCliente]
            ,[Stock]
            ,[StockEntregado]
            ,[TieneExclusion]
            ,[IDBonifcacionExcluida]
            ,[cdProductoVenta]
            ,[IDProveedor]
            ,[Desde]
            ,[Hasta]
            ,[Activo])
            VALUES
            (@PKID
            ,@Mecanica
            ,@TipoMecanica
            ,@cdProductoRegalo
            ,@CantidadMinima
            ,@CantidadMaxima
            ,@CantidadRegalo
            ,@CantidadMaximaPorCliente
            ,@Stock
            ,@StockEntregado
            ,@TieneExclusion
            ,@IDBonifcacionExcluida
            ,@cdProductoVenta
            ,@IDProveedor
            ,@Desde
            ,@Hasta
            ,@Activo)";
            string sql01 =
            @"INSERT INTO [dbo].[ItemBonificacion]
            ([PKID]
            ,[IDBonificacion]
            ,[cdProductoColeccion]
            ,[IDAsociado])
            VALUES
            (@PKIDItemBonificacion
            ,@IDBonificacion
            ,@cdProductoColeccion
            ,@IDAsociado)";
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction transaccion = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd0 = new SqlCommand(sql00, con))
                    {
                        cmd0.Parameters.AddWithValue("@PKID", PKID);
                        cmd0.Parameters.AddWithValue("@Mecanica", Mecanica);
                        cmd0.Parameters.AddWithValue("@TipoMecanica", TipoMecanica);
                        cmd0.Parameters.AddWithValue("@cdProductoRegalo", cdProductoRegalo);
                        cmd0.Parameters.AddWithValue("@CantidadMinima", CantidadMinima);
                        cmd0.Parameters.AddWithValue("@CantidadMaxima", CantidadMaxima);
                        cmd0.Parameters.AddWithValue("@CantidadRegalo", CantidadRegalo);
                        cmd0.Parameters.AddWithValue("@CantidadMaximaPorCliente", CantidadMaximaPorCliente);
                        cmd0.Parameters.AddWithValue("@Stock", Stock);
                        cmd0.Parameters.AddWithValue("@StockEntregado", 0);
                        cmd0.Parameters.AddWithValue("@TieneExclusion", TieneExclusion);
                        cmd0.Parameters.AddWithValue("@IDBonifcacionExcluida", IDBonifcacionExcluida);
                        cmd0.Parameters.AddWithValue("@cdProductoVenta", cdProductoVenta);
                        cmd0.Parameters.AddWithValue("@IDProveedor", IDProveedor);
                        cmd0.Parameters.AddWithValue("@Desde", Desde);
                        cmd0.Parameters.AddWithValue("@Hasta", Hasta);
                        cmd0.Parameters.AddWithValue("@Activo", Activo);
                    cmd0.Transaction = transaccion;
                    cmd0.ExecuteNonQuery();
                    }
                    foreach (DataGridViewRow Fila in dgv0.Rows)
                    {
                        using (SqlCommand cmd1 = new SqlCommand(sql01, con))
                        {
                            cmd1.Parameters.AddWithValue("@PKIDItemBonificacion", PKIDItemBonificacion);
                            cmd1.Parameters.AddWithValue("@IDBonificacion", PKID);
                            cmd1.Parameters.AddWithValue("@cdProductoColeccion", Fila.Cells["Codigo"].Value.ToString());
                            cmd1.Parameters.AddWithValue("@IDAsociado", IDAsociado);
                        cmd1.Transaction = transaccion;
                        cmd1.ExecuteNonQuery();
                        }
                        PKIDItemBonificacion++;
                    }
                transaccion.Commit();
            }
                catch (Exception f)
            {
                transaccion.Rollback();
                MessageBox.Show(f.Message);
            }
        }

        }
        public void saveBonificacion(int PKID, string Mecanica, int TipoMecanica, string cdProductoRegalo, decimal CantidadMinima, int CantidadMaxima,
                                     int CantidadRegalo, int CantidadMaximaPorCliente, decimal Stock, bool TieneExclusion, int IDBonifcacionExcluida,
                                     string cdProductoVenta, string IDProveedor, string Desde, string Hasta, bool Activo, DataGridView dgv0, int PKIDItemBonificacion,
                                     int IDAsociado)
        {
            string query0 = @"
                            UPDATE [dbo].[Bonificacion]
                            SET 
                                  [Mecanica] = @Mecanica
                                 ,[TipoMecanica] = @TipoMecanica
                                 ,[cdProductoRegalo] = @cdProductoRegalo
                                 ,[CantidadMinima] = @CantidadMinima
                                 ,[CantidadMaxima] = @CantidadMaxima
                                 ,[CantidadRegalo] = @CantidadRegalo
                                 ,[CantidadMaximaPorCliente] = @CantidadMaximaPorCliente
                                 ,[Stock] = @Stock
                                 ,[TieneExclusion] = @TieneExclusion
                                 ,[IDBonifcacionExcluida] = @IDBonifcacionExcluida
                                 ,[cdProductoVenta] = @cdProductoVenta
                                 ,[IDProveedor] = @IDProveedor
                                 ,[Desde] = @Desde
                                 ,[Hasta] = @Hasta
                                 ,[Activo] = @Activo
                            WHERE PKID = @PKID
                            ";
            string query1 = @"delete ItemBonificacion where IDBonificacion = @PKID";
            string query2 = @"
                             INSERT INTO [dbo].[ItemBonificacion]
                                   ([PKID]
                                   ,[IDBonificacion]
                                   ,[cdProductoColeccion]
                                   ,[IDAsociado])
                             VALUES
                                   (@PKIDItemBonificacion
                                   ,@IDBonificacion
                                   ,@cdProductoColeccion
                                   ,@IDAsociado)
                            ";
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction transaccion = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd0 = new SqlCommand(query0, con))
                    {
                        cmd0.CommandType = CommandType.Text;
                        cmd0.Parameters.AddWithValue("@PKID", PKID);
                        cmd0.Parameters.AddWithValue("@Mecanica", Mecanica);
                        cmd0.Parameters.AddWithValue("@TipoMecanica", TipoMecanica);
                        cmd0.Parameters.AddWithValue("@cdProductoRegalo", cdProductoRegalo);
                        cmd0.Parameters.AddWithValue("@CantidadMinima", CantidadMinima);
                        cmd0.Parameters.AddWithValue("@CantidadMaxima", CantidadMaxima);
                        cmd0.Parameters.AddWithValue("@CantidadRegalo", CantidadRegalo);
                        cmd0.Parameters.AddWithValue("@CantidadMaximaPorCliente", CantidadMaximaPorCliente);
                        cmd0.Parameters.AddWithValue("@Stock", Stock);
                        cmd0.Parameters.AddWithValue("@TieneExclusion", TieneExclusion);
                        cmd0.Parameters.AddWithValue("@IDBonifcacionExcluida", IDBonifcacionExcluida);
                        cmd0.Parameters.AddWithValue("@cdProductoVenta", cdProductoVenta);
                        cmd0.Parameters.AddWithValue("@IDProveedor", IDProveedor);
                        cmd0.Parameters.AddWithValue("@Desde", Desde);
                        cmd0.Parameters.AddWithValue("@Hasta", Hasta);
                        cmd0.Parameters.AddWithValue("@Activo", Activo);
                        cmd0.Transaction = transaccion;
                        cmd0.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd1 = new SqlCommand(query1, con))
                    {
                        cmd1.CommandType = CommandType.Text;
                        cmd1.Parameters.AddWithValue("@PKID", PKID);
                    cmd1.Transaction = transaccion;
                    cmd1.ExecuteNonQuery();
                    }

                    foreach (DataGridViewRow Fila in dgv0.Rows)
                    {
                        using (SqlCommand cmd2 = new SqlCommand(query2, con))
                        {
                            cmd2.CommandType = CommandType.Text;
                            cmd2.Parameters.AddWithValue("@PKIDItemBonificacion", PKIDItemBonificacion);
                            cmd2.Parameters.AddWithValue("@IDBonificacion", PKID);
                            cmd2.Parameters.AddWithValue("@cdProductoColeccion", Fila.Cells["Codigo"].Value.ToString());
                            cmd2.Parameters.AddWithValue("@IDAsociado", IDAsociado);
                            cmd2.Transaction = transaccion;
                            cmd2.ExecuteNonQuery();
                        }
                        PKIDItemBonificacion++;
                    }
                    transaccion.Commit();
                }
                catch (Exception f)
                {
                    transaccion.Rollback();
                    MessageBox.Show(f.Message);
                }
            }
        }
    }
}
