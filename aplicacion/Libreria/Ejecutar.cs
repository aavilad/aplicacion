using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace xtraForm.Libreria
{
    class Ejecutar
    {
        string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ToString();
        Libreria.Proceso proceso = new Proceso();
        public void savepedido(DataGridView detalle, string pedido, string Personal, string Cliente, string FormaPago, string Fecha, string rsocial,
            string ruc, string direccion, string dni, string gestion, string tipodoc)
        {
            string sql00 = @"
                            UPDATE [dbo].[PEDIDO]
                             SET 
                                 [Personal] = @Personal
                                ,[Cliente] = @Cliente
                                ,[FormaPago] = @FormaPago
                                ,[Fecha] = @Fecha
                                ,[rsocial] = @rsocial
                                ,[ruc] = @ruc
                                ,[direccion] = @direccion
                                ,[dni] = @dni
                                ,[encargado] = @encargado
                                ,[npersonal] = @npersonal
                                ,[nencargado] = @nencargado
                                ,[gestion] = @gestion
                                ,[ptollegada] = @ptollegada
                                ,[distllegada] = @distllegada
                                ,[tipodoc] = @tipodoc
                                ,[flagCobertura] = @flagCobertura
                            WHERE pedido = @pedido";
            string sql01 = @"
                           INSERT INTO [dbo].[DETPEDIDO]
                                 ([Pedido]
                                 ,[Producto]
                                 ,[PrecUnit]
                                 ,[Cantidad]
                                 ,[Estado]
                                 ,[TipoPrecio]
                                 ,[TranGratuita]
                                 ,[lote]
                                 ,[fvctolote]
                                 ,[flgSurtido]
                                 ,[IDBonificacion]
                                 ,[PrecioUnitario]
                                 ,[PrecioNeto]
                                 ,[Descuento]
                                 ,[Recargo]
                                 ,[Afecto]
                                 ,[Bonif])
                           VALUES
                                 (@pedido
                                 ,@Producto
                                 ,@PrecUnit
                                 ,@Cantidad
                                 ,@Estado
                                 ,@TipoPrecio
                                 ,@TranGratuita
                                 ,@lote
                                 ,@fvctolote
                                 ,@flgSurtido
                                 ,@IDBonificacion
                                 ,@PrecioUnitario
                                 ,@PrecioNeto
                                 ,@Descuento
                                 ,@Recargo
                                 ,@Afecto
                                 ,@Bonif)
                                  ";
            string sql02 = @"delete detadoc  where documento = (select documento from documento where pedido = @pedido) and tipodoc =(select tipodoc from documento where pedido = @pedido);
                             delete documento  where pedido = @pedido;
                             delete detpedido  where pedido = @pedido;";
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction transaccion = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmdA = new SqlCommand(sql00, con))
                    {
                        cmdA.Parameters.AddWithValue("@pedido", pedido);
                        cmdA.Parameters.AddWithValue("@Personal", Personal);
                        cmdA.Parameters.AddWithValue("@Cliente", Cliente);
                        cmdA.Parameters.AddWithValue("@FormaPago", FormaPago);
                        cmdA.Parameters.AddWithValue("@Fecha", Fecha);
                        cmdA.Parameters.AddWithValue("@rsocial", rsocial);
                        cmdA.Parameters.AddWithValue("@ruc", ruc);
                        cmdA.Parameters.AddWithValue("@direccion", direccion);
                        cmdA.Parameters.AddWithValue("@dni", dni);
                        cmdA.Parameters.AddWithValue("@encargado", Personal);
                        cmdA.Parameters.AddWithValue("@npersonal", proceso.ConsultarCadena("Nombre", "personal", "personal = '" + Personal + "'"));
                        cmdA.Parameters.AddWithValue("@nencargado", proceso.ConsultarCadena("Nombre", "personal", "personal = '" + Personal + "'"));
                        cmdA.Parameters.AddWithValue("@gestion", gestion);
                        cmdA.Parameters.AddWithValue("@ptollegada", direccion);
                        cmdA.Parameters.AddWithValue("@distllegada", proceso.ConsultarCadena("iddistrito", "cliente", "cliente = '" + Cliente + "'"));
                        cmdA.Parameters.AddWithValue("@tipodoc", tipodoc);
                        cmdA.Parameters.AddWithValue("@flagCobertura", DBNull.Value);
                        cmdA.Transaction = transaccion;
                        cmdA.ExecuteNonQuery();
                    }
                    using (SqlCommand cmdC = new SqlCommand(sql02, con))
                    {
                        cmdC.Parameters.AddWithValue("@pedido", pedido);
                        cmdC.Transaction = transaccion;
                        cmdC.ExecuteNonQuery();
                    }
                    //proceso.eliminar("detpedido", "pedido = '" + pedido + "'");
                    foreach (DataGridViewRow F00 in detalle.Rows)
                    {
                        using (SqlCommand cmdB = new SqlCommand(sql01, con))
                        {
                            cmdB.Parameters.AddWithValue("@pedido", pedido);
                            cmdB.Parameters.AddWithValue("@Producto", F00.Cells["Codigo"].Value);
                            cmdB.Parameters.AddWithValue("@PrecUnit", Convert.ToDecimal(F00.Cells["PrecioUnitario"].Value));
                            cmdB.Parameters.AddWithValue("@Cantidad", Convert.ToDecimal(F00.Cells["Cantidad"].Value));
                            cmdB.Parameters.AddWithValue("@Estado", "P");
                            cmdB.Parameters.AddWithValue("@TipoPrecio", F00.Cells["TpPrecio"].Value);
                            cmdB.Parameters.AddWithValue("@TranGratuita", 0.00);
                            cmdB.Parameters.AddWithValue("@lote", DBNull.Value);
                            cmdB.Parameters.AddWithValue("@fvctolote", DBNull.Value);
                            cmdB.Parameters.AddWithValue("@flgSurtido", DBNull.Value);
                            cmdB.Parameters.AddWithValue("@IDBonificacion", F00.Cells["IDBonificacion"].Value);
                            cmdB.Parameters.AddWithValue("@PrecioUnitario", Convert.ToDecimal(F00.Cells["PrecioUnitario"].Value));
                            cmdB.Parameters.AddWithValue("@PrecioNeto", Convert.ToDecimal(F00.Cells["PrecioNeto"].Value));
                            cmdB.Parameters.AddWithValue("@Descuento", Convert.ToDecimal(F00.Cells["Descuento"].Value));
                            cmdB.Parameters.AddWithValue("@Recargo", Convert.ToDecimal(F00.Cells["Recargo"].Value));
                            cmdB.Parameters.AddWithValue("@Afecto", Convert.ToBoolean(F00.Cells["Afecto"].Value));
                            cmdB.Parameters.AddWithValue("@Bonif", Convert.ToBoolean(F00.Cells["Bonif"].Value));
                            cmdB.Transaction = transaccion;
                            cmdB.ExecuteNonQuery();
                        }
                    }
                    transaccion.Commit();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    transaccion.Rollback();
                }
            }

        }
        public string deletepedido(string pedido)
        {
            string resultado;
            string queryA = @"delete detpedido where pedido = @pedido";
            string queryB = @"delete pedido where pedido = @pedido";
            string queryC = @"delete detadoc where documento in (select documento from documento where pedido = @pedido) and tipodoc in (select tipodoc from documento where pedido = @pedido)";
            string queryD = @"delete documento where pedido = @pedido";
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction transaccion = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd0 = new SqlCommand(queryA, con))
                    {
                        cmd0.Parameters.AddWithValue("@pedido", pedido);
                        cmd0.Transaction = transaccion;
                        cmd0.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd1 = new SqlCommand(queryB, con))
                    {
                        cmd1.Parameters.AddWithValue("@pedido", pedido);
                        cmd1.Transaction = transaccion;
                        cmd1.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd2 = new SqlCommand(queryC, con))
                    {
                        cmd2.Parameters.AddWithValue("@pedido", pedido);
                        cmd2.Transaction = transaccion;
                        cmd2.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd3 = new SqlCommand(queryD, con))
                    {
                        cmd3.Parameters.AddWithValue("@pedido", pedido);
                        cmd3.Transaction = transaccion;
                        cmd3.ExecuteNonQuery();
                    }
                    transaccion.Commit();
                    resultado = "pedido fue eliminado con exito";
                }
                catch (SqlException e)
                {
                    resultado = e.Message;

                    transaccion.Rollback();
                }
                return resultado;
            }
        }
        public string DeleteBonificacion(int pkid)
        {
            string resultado;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction transaccion = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd3 = new SqlCommand("delete bonificacion where pkid = @PKID", con))
                    {
                        cmd3.Parameters.AddWithValue("@PKID", pkid);
                        cmd3.Transaction = transaccion;
                        cmd3.ExecuteNonQuery();
                    }
                    transaccion.Commit();
                    resultado = "Bonificacion fue eliminada con exito";
                }
                catch (SqlException e)
                {
                    resultado = e.Message;
                    transaccion.Rollback();
                }
                return resultado;
            }
        }
    }
}
