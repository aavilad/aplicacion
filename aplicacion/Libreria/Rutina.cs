using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Libreria
{
    class Rutina
    {
        private string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ToString();
        Entidad entidad = new Entidad();
        public SqlCommand cmd;
        public SqlCommandBuilder cmdb;
        public DataSet ds = new DataSet();

        public bool actualizar(string tabla, string campos, string condicion)
        {
            string query = @"update " + tabla + " set  " + campos + "  where " + condicion;
            using (SqlConnection con = new SqlConnection(conexion))
            using (cmd = new SqlCommand(query, con))
            {
                con.Open();
                entidad.i = cmd.ExecuteNonQuery();
                if (entidad.i > 0)
                    return true;
                else
                    return false;
            }
        }

        public void consultar(string sql, string tabla)
        {
            ds.Tables.Clear();
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
            {
                cmdb = new SqlCommandBuilder(da);
                da.Fill(ds, tabla);
            }
        }

        public string ConsultarCadena(string campo, string tabla, string condicion)
        {
            string query = @"select " + campo + " from " + tabla + " where " + condicion;
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader Leer = cmd.ExecuteReader();
                if (Leer.HasRows)
                {
                    if (Leer.Read())
                    {
                        entidad.codigo = Leer[0].ToString();
                    }
                }
                return entidad.codigo;
            }
        }

        public decimal ConsultarDecimal(string campo, string tabla, string condicion)
        {
            decimal x = 0;
            string query = @"select " + campo + " from " + tabla + " where " + condicion;
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader Leer = cmd.ExecuteReader();
                if (Leer.HasRows)
                {
                    if (Leer.Read())
                    {
                        x = Convert.ToDecimal(Leer[0]);
                    }
                }
                return x;
            }
        }

        public int ConsultarEntero(string campo, string tabla, string condicion)
        {
            var x = 0;
            string query = @"select " + campo + " from " + tabla + " where " + condicion;
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader Leer = cmd.ExecuteReader();
                if (Leer.HasRows)
                {
                    if (Leer.Read())
                    {
                        x = Convert.ToInt32(Leer[0]);
                    }
                }
                return x;
            }

        }

        public DataTable ConsultarTabla(string tabla)
        {
            string query = @"select * from " + tabla;
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }

        public DataTable ConsultarTabla_(string tabla, string condicion)
        {
            string query = @"select * from " + tabla + " where " + condicion;
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }

        public bool ConsultarVerdad(string campo, string tabla, string condicion)
        {
            var x = false;
            string query = @"select " + campo + " from " + tabla + " where " + condicion;
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader Leer = cmd.ExecuteReader();
                if (Leer.HasRows)
                {
                    if (Leer.Read())
                    {
                        x = Convert.ToBoolean(Leer[0]);
                    }
                }
                return x;
            }
        }

        public bool ejecutar(string query)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            using (cmd = new SqlCommand(query, con))
            {
                con.Open();
                entidad.i = cmd.ExecuteNonQuery();
                if (entidad.i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool eliminar(string tabla, string condicion)
        {
            string query = "delete from " + tabla + " where " + condicion;
            using (SqlConnection con = new SqlConnection(conexion))
            using (cmd = new SqlCommand(query, con))
            {
                con.Open();
                entidad.i = cmd.ExecuteNonQuery();
                if (entidad.i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public DataTable EvaluarBonificacion(string where, string having)
        {
            string QUERY = @"
            SELECT
                dbo.Vva_Pedido.NrPedido,
                SUM (dbo.Vva_ItemPedido.Cantidad) AS Cantidad
            FROM
                dbo.Vva_Pedido
                INNER JOIN
                dbo.Vva_ItemPedido
                ON dbo.Vva_Pedido.NrPedido = dbo.Vva_ItemPedido.NrPedido
                INNER JOIN
                dbo.producto
                ON dbo.Vva_ItemPedido.IDProducto = dbo.producto.producto  where " + where + " GROUP BY dbo.Vva_Pedido.NrPedido  having " + having;

            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(QUERY, con))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }

        public bool ExistenciaCampo(string campo, string tabla, string condicion)
        {
            string QUERY = @"select top(1) " + campo + " from " + tabla + " where " + condicion;
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(QUERY, con))
            {
                con.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                if (leer.HasRows)
                {
                    if (leer.Read())
                    {
                        entidad.codigoauxiliar = leer[0].ToString();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ExistenciaStock(string codigo, decimal cantidadvendida, decimal cantidad)
        {
            bool i = false;
            string QUERY = @"select Disponible+" + cantidadvendida + " from Vva_producto where Codigo = '" + codigo + "'";
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(QUERY, con))
            {
                con.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                if (leer.HasRows)
                {
                    if (leer.Read())
                    {
                        entidad.cantidadstock = (decimal)leer[0];
                    }
                }
            }
            if (entidad.cantidadstock != 0)
            {
                if (entidad.cantidadstock >= cantidad)
                {
                    i = true;
                }
                else
                {
                    i = false;
                }
            }
            return i;

        }

        public int ID(string tabla)
        {
            string QUERY = @"SELECT isnull(max(PKID),0)+1 FROM " + tabla;
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(QUERY, con))
            {
                con.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                if (leer.HasRows)
                {
                    if (leer.Read())
                    {
                        entidad.pkid = (int)leer[0];
                    }
                }
            }
            return entidad.pkid;
        }

        public bool insertar(string query)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            using (cmd = new SqlCommand(query, con))
            {
                con.Open();
                entidad.i = cmd.ExecuteNonQuery();
                if (entidad.i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public DialogResult MensageError(string cadena)
        {
            DialogResult result = MessageBox.Show(cadena, "Mensage", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            return result;
        }

        public DialogResult MensagePregunta(string cadena)
        {
            DialogResult result = MessageBox.Show(cadena, "Mensage", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result;
        }

        public string newid()
        {
            string QUERY = @"SELECT newid()";
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(QUERY, con))
            {
                con.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                if (leer.HasRows)
                {
                    if (leer.Read())
                    {
                        entidad.codigo = leer[0].ToString();
                    }
                }
            }
            return entidad.codigo;
        }

        public string Procedimiento(string procedimiento)
        {
            string QUERY = @"exec " + procedimiento;
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(QUERY, con))
            {
                con.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                if (leer.HasRows)
                {
                    if (leer.Read())
                    {
                        entidad.cadena = leer[0].ToString();
                    }
                }
                return entidad.cadena;
            }
        }
    }
}
