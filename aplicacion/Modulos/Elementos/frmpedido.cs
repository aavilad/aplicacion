using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmpedido : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Entidad entidad = new Libreria.Entidad();
        int index = 0;
        decimal cantidadpedido = 0;
        Libreria.Pedido pedido = new Libreria.Pedido();
        Libreria.Proceso proceso = new Libreria.Proceso();
        Libreria.Producto producto = new Libreria.Producto();
        Libreria.Formato formato = new Libreria.Formato();
        public int tipoprecio;
        public bool Existe;

        public frmpedido()
        {
            InitializeComponent();
            entidad.tabla = "nuevoPedido";
            txtcdVendedor.Select();
        }

        public delegate void varaible(string CdPedido, string TpDoc, string CdVendedor, string CdCliente, string CdFP, DateTime Fecha, string NmCliente, string Ruc, string Direccion, string Dni, string NmVendedor,
            string Gestion, string IdDistrito, DataGridView dgv);

        public event varaible pasar;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Libreria.Pedido CpPedido = new Libreria.Pedido();
            CpPedido.NumeroPedido = txtcdDocumento.Text.Trim();
            CpPedido.CodigoVendedor = txtcdVendedor.Text.Trim();
            CpPedido.CodigoCliente = txtcdCLiente.Text.Trim();
            CpPedido.FormaPago = CodigoFP.Text;
            CpPedido.NombreCliente = txtnmCliente.Text;
            CpPedido.DocumentoCliente = txtdocCliente.Text.Trim();
            CpPedido.DireccionCliente = txtnmDireccion.Text;
            CpPedido.NombreVendedor = txtnmVendedor.Text;
            CpPedido.Gestion = txtcdGestion.Text.Trim();
            CpPedido.DistritoCliente = txtcdDistrito.Text.Trim();
            CpPedido.TipoPedido = txtdocCliente.Text.Trim().Length == 8 || txtdocCliente.Text.Trim() == "S/D" ? "B" : "F";
            if (!proceso.ConsultarVerdad("Procesado", "Pedido", "pedido = '" + CpPedido.NumeroPedido + "'"))
            {
                try
                {
                    if (dxValidationProvider1.Validate())
                {
                    pasar(CpPedido.NumeroPedido, CpPedido.TipoPedido, CpPedido.CodigoVendedor, CpPedido.CodigoCliente, CpPedido.FormaPago, Convert.ToDateTime(dateEmision.EditValue),
                    CpPedido.NombreCliente, CpPedido.DocumentoCliente.Length == 8 ? string.Empty : CpPedido.DocumentoCliente, CpPedido.DireccionCliente,
                    CpPedido.DocumentoCliente.Length == 8 ? CpPedido.DocumentoCliente : string.Empty, CpPedido.NombreVendedor, CpPedido.Gestion, CpPedido.DistritoCliente, dataGridView1);
                    this.Close();
                }
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                }
            }
            else
            {
                MessageBox.Show("Pedido se encuentra procesado.");
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtcdCLiente.Text.Length > 0 && txtnmCliente.Text.Length > 0)
            {
                pedido.TipoLista = proceso.ConsultarEntero("TpLista", "Vva_vendedor", "[Codigo vendedor] = '" + txtcdVendedor.Text.Trim() + "'");
                dataGridView1.Rows.Add();
                btnCredito.Enabled = true;
            }
            else
                MessageBox.Show("pedido no cuenta datos de cliente");
        }

        private void btnBonificar_Click(object sender, EventArgs e)
        {
            using (var Context = new LiderEntities())
            {
                Context.Database.SqlQuery<string>("exec sp_stock_sistema @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                Context.Database.SqlQuery<string>("exec sp_stock_sistema_web @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(System.Int32));
            dt.Columns.Add("Cantidad", typeof(System.Decimal));
            List<string> lista = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Bonif"].Value))
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Bonif"].Value))
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
            }
            entidad.fecha = Convert.ToDateTime(dateEmision.EditValue).ToString("yyyyMMdd");
            if (dateEmision.EditValue != null)
            {
                var bonificacion = proceso.ConsultarTabla_("Bonificacion", "(Activo = 1) AND ('" + entidad.fecha + "' >= Desde AND '" + entidad.fecha + "' <= Hasta)");
                //
                foreach (DataRow drb in bonificacion.Rows)
                {
                    lista.Clear();
                    var coleccion = proceso.ConsultarTabla_("itembonificacion", "idbonificacion = " + Convert.ToInt32(drb["PKID"]));
                    foreach (DataRow F00 in coleccion.Rows)
                    {
                        lista.Add(F00["cdProductoColeccion"].ToString());
                    }
                    string query = string.Join(",", lista.ToArray());
                    var sql = (from pedido in dataGridView1.Rows.Cast<DataGridViewRow>()
                               where query.Contains(pedido.Cells["Codigo"].Value.ToString())
                               select Convert.ToDecimal(pedido.Cells["Cantidad"].Value)).Sum();
                    //
                    var sql1 = (from pedido in dataGridView1.Rows.Cast<DataGridViewRow>()
                                where query.Contains(pedido.Cells["Codigo"].Value.ToString())
                                select Convert.ToDecimal(pedido.Cells["Total"].Value)).Sum();
                    entidad.idbonificacion = Convert.ToInt32(drb["PKID"]);
                    entidad.codigoregalo = drb["cdProductoRegalo"].ToString();
                    entidad.cantidadminima = Convert.ToDecimal(drb["CantidadMinima"]);
                    entidad.cantidadmaxima = Convert.ToInt32(drb["CantidadMaxima"]);
                    entidad.cantidadobsequio = Convert.ToInt32(drb["CantidadRegalo"]);
                    entidad.cantidadmaximacliente = Convert.ToInt32(drb["CantidadMaximaPorCliente"]);
                    entidad.cantidadstock = Convert.ToInt32(drb["Stock"]);
                    entidad.cantidadstockentregado = Convert.ToInt32(drb["StockEntregado"]);
                    entidad.exclusion = Convert.ToBoolean(drb["TieneExclusion"]);
                    entidad.codigoexclusion = Convert.ToInt32(drb["IDBonifcacionExcluida"]);
                    entidad.tipomecanica = Convert.ToInt32(drb["TipoMecanica"]);
                    entidad.idasociado = proceso.ConsultarEntero("IDAsociado", "ItemBonificacion", "IDBonificacion = " + entidad.idbonificacion);
                    foreach (DataGridViewRow F01 in dataGridView1.Rows)
                    {
                        if (Convert.ToInt32(F01.Cells["IDBonificacion"].Value == string.Empty ? 0 : F01.Cells["IDBonificacion"].Value) > 0)
                        {
                            if (entidad.codigoexclusion == Convert.ToInt32(F01.Cells["IDBonificacion"].Value))
                            {
                                entidad.existe = true;
                            }
                        }
                    }
                    //
                    if (sql > 0)
                    {
                        Existe = true;
                        entidad.i = (int)(sql / entidad.cantidadminima) * entidad.cantidadobsequio;
                        entidad.x = (int)(sql1 / entidad.cantidadminima) * entidad.cantidadobsequio;
                        if (entidad.idasociado == 4)
                        {
                            if (entidad.tipomecanica == 1)
                            {
                                if (sql >= entidad.cantidadminima)
                                {
                                    if (!entidad.exclusion)
                                    {
                                        if (entidad.cantidadmaximacliente > 0 && entidad.i <= entidad.cantidadmaximacliente)
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.i))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.i, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                        else if (entidad.cantidadmaximacliente > 0 && entidad.i > entidad.cantidadmaximacliente)
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.cantidadmaximacliente))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.cantidadmaximacliente, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                        else
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.i))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.i, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!entidad.existe)
                                        {
                                            if (entidad.cantidadmaximacliente > 0 && entidad.i <= entidad.cantidadmaximacliente)
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.i))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.i, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                            else if (entidad.cantidadmaximacliente > 0 && entidad.i > entidad.cantidadmaximacliente)
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.cantidadmaximacliente))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.cantidadmaximacliente, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                            else
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.i))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.i, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (entidad.tipomecanica == 2)
                            {
                                if (sql >= entidad.cantidadminima && sql < entidad.cantidadmaxima)
                                {
                                    if (!entidad.exclusion)
                                    {
                                        if (entidad.cantidadmaximacliente > 0 && entidad.i <= entidad.cantidadmaximacliente)
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.i))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.i, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                        else if (entidad.cantidadmaximacliente > 0 && entidad.i > entidad.cantidadmaximacliente)
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.cantidadmaximacliente))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.cantidadmaximacliente, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                        else
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.i))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.i, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!entidad.existe)
                                        {
                                            if (entidad.cantidadmaximacliente > 0 && entidad.i <= entidad.cantidadmaximacliente)
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.i))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.i, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                            else if (entidad.cantidadmaximacliente > 0 && entidad.i > entidad.cantidadmaximacliente)
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.cantidadmaximacliente))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.cantidadmaximacliente, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                            else
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.i))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.i, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (entidad.tipomecanica == 3)
                            {
                                if (sql1 >= entidad.cantidadminima)
                                {
                                    if (!entidad.exclusion)
                                    {
                                        if (entidad.cantidadmaximacliente > 0 && entidad.x <= entidad.cantidadmaximacliente)
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.x))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.x, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                        else if (entidad.cantidadmaximacliente > 0 && entidad.x > entidad.cantidadmaximacliente)
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.cantidadmaximacliente))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.cantidadmaximacliente, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                        else
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.x))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.x, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!entidad.existe)
                                        {
                                            if (entidad.cantidadmaximacliente > 0 && entidad.x <= entidad.cantidadmaximacliente)
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.i))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.x, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                            else if (entidad.cantidadmaximacliente > 0 && entidad.x > entidad.cantidadmaximacliente)
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.cantidadmaximacliente))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.cantidadmaximacliente, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                            else
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.x))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.x, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (entidad.tipomecanica == 4)
                            {
                                if (sql1 >= entidad.cantidadminima && sql1 < entidad.cantidadmaxima)
                                {
                                    if (!entidad.exclusion)
                                    {
                                        if (entidad.cantidadmaximacliente > 0 && entidad.x <= entidad.cantidadmaximacliente)
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.x))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.x, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                        else if (entidad.cantidadmaximacliente > 0 && entidad.x > entidad.cantidadmaximacliente)
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.cantidadmaximacliente))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.cantidadmaximacliente, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                        else
                                        {
                                            if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.x))
                                            {
                                                dataGridView1.Rows.Add(
                                                    entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                    entidad.x, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                    0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!entidad.existe)
                                        {
                                            if (entidad.cantidadmaximacliente > 0 && entidad.x <= entidad.cantidadmaximacliente)
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.x))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.x, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                            else if (entidad.cantidadmaximacliente > 0 && entidad.x > entidad.cantidadmaximacliente)
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.cantidadmaximacliente))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.cantidadmaximacliente, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                            else
                                            {
                                                if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.x))
                                                {
                                                    dataGridView1.Rows.Add(
                                                        entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                        entidad.x, 0, proceso.ConsultarCadena("UniMed", "producto", "producto = '" + entidad.codigoregalo + "'"), 1,
                                                        0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, entidad.idbonificacion);
                                                    dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Precioneto"].ReadOnly = true;
                                                    dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("stock insuficiente para el codigo :" + entidad.codigoregalo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Existe = false;
            using (var Context = new LiderEntities())
            {
                Context.Database.SqlQuery<string>("exec sp_stock_sistema @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                Context.Database.SqlQuery<string>("exec sp_stock_sistema_web @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) { if (proceso.MensageError("Cancelar Proceso") == DialogResult.Yes) this.Close(); }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Filtros.frmConsultar frmconsultar = new Filtros.frmConsultar();
            proceso.consultar(@"
            SELECT
            dbo.Vva_Cp.Fecha, dbo.Vva_Cp.NrDoc AS Codigo, dbo.Vva_Cp.TpDoc AS Tipo, dbo.Vva_Cp.Comprobante, SUM(dbo.Vva_ItemCp.Cantidad * dbo.Vva_ItemCp.Precio) 
            AS Importe, dbo.PROVEEDOR.RazonSocial AS Proveedor
            FROM
            dbo.Vva_Cp INNER JOIN
            dbo.Vva_ItemCp ON dbo.Vva_Cp.TpDoc = dbo.Vva_ItemCp.TpDoc AND dbo.Vva_Cp.NrDoc = dbo.Vva_ItemCp.NrDoc INNER JOIN
            dbo.PROVEEDOR ON dbo.Vva_ItemCp.IDProveedor = dbo.PROVEEDOR.Proveedor
            WHERE        (dbo.Vva_Cp.IDCliente = '" + txtcdCLiente.Text.Trim() + @"')
            GROUP BY dbo.Vva_Cp.Fecha, dbo.Vva_Cp.NrDoc, dbo.Vva_Cp.TpDoc, dbo.Vva_Cp.Comprobante, dbo.PROVEEDOR.RazonSocial
            ", "consultar");
            frmconsultar.gridControl1.DataSource = proceso.ds.Tables["consultar"];
            formato.Grilla(frmconsultar.gridView1);
            frmconsultar.StartPosition = FormStartPosition.CenterScreen;
            frmconsultar.ShowDialog();
        }
        private void btnCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
                if (proceso.ConsultarVerdad("credito", "Vva_Cliente", "Codigo = '" + txtcdCLiente.Text.Trim() + "'"))
                    switch (btnCredito.Checked)
                    {
                        case true:
                            Maestro.frmCondicion frmcondicion = new Maestro.frmCondicion();
                            frmcondicion.dataGridView1.DataSource = proceso.ConsultarTabla_("FormaPago", "Contado != 1");
                            frmcondicion.pasar += new Maestro.frmCondicion.variable(formapago);
                            frmcondicion.StartPosition = FormStartPosition.CenterScreen;
                            frmcondicion.ShowDialog();
                            break;
                        case false:
                            foreach (DataGridViewRow dr in dataGridView1.Rows)
                                if (dr.Cells["Codigo"].Value != null && dr.Cells["Descripcion"] != null)
                                {
                                    switch (dr.Cells["TpPrecio"].Value)
                                    {
                                        case 3:
                                            producto.CodigoPrecio = "C_MENOR";
                                            dr.Cells["TpPrecio"].Value = 1;
                                            break;
                                        case 4:
                                            producto.CodigoPrecio = "C_MAYOR";
                                            dr.Cells["TpPrecio"].Value = 2;
                                            break;
                                        case 5:
                                            producto.CodigoPrecio = "ESPECIAL06";
                                            dr.Cells["TpPrecio"].Value = 6;
                                            break;
                                    }
                                    txtformaPago.Text = "CONTADO";
                                    string codigo = dr.Cells["Codigo"].Value.ToString();
                                    dr.Cells["Credito"].Value = false;
                                    dr.Cells["PrecioUnitario"].Value = proceso.ConsultarCadena(producto.CodigoPrecio, "Vva_Producto", "Codigo = '" + codigo + "'");
                                    dr.Cells["PrecioNeto"].Value = proceso.ConsultarCadena(producto.CodigoPrecio, "Vva_Producto", "Codigo = '" + codigo + "'");
                                    dr.Cells["Total"].Value = Convert.ToDecimal(dr.Cells["Cantidad"].Value) * Convert.ToDecimal(dr.Cells["PrecioNeto"].Value);
                                }
                            break;
                    }
                else
                    MessageBox.Show("Cliente no tiene habilitado condicion de credito");

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog();
            xtraOpenFileDialog1.InitialDirectory = "C:\\";
            xtraOpenFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                entidad.directorio = xtraOpenFileDialog1.FileName;
                string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + entidad.directorio + ";Extended Properties=Excel 12.0;";
                OleDbConnection conn = new OleDbConnection(connstr);
                string strSQL = "SELECT * FROM [Sheet1$]";
                OleDbCommand cmd = new OleDbCommand(strSQL, conn);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
            }
            //OpenFileDialog dialogo = new OpenFileDialog();
            //dialogo.InitialDirectory = "C:\\";
            //if (dialogo.ShowDialog() == DialogResult.OK)
            //{
            //}
            //string path = Server.MapPath("File/MyExcel.xlsx");
        }

        private void btnPrecio_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Maestro.frmPrecios frmprecio = new Maestro.frmPrecios();
                proceso.consultar(@"select [PrecMenContado],[PrecMayContado],[PrecMenCredito],[PrecMayCredito],[PrecEspecial],[PrecSEspecial],[PrecSSEspecial] 
                    from producto where producto = '" + dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString() + "'", "Precio");
                frmprecio.vGridControl1.DataSource = proceso.ds.Tables["Precio"];
                frmprecio.pasar += new Maestro.frmPrecios.variables(campoprecio);
                frmprecio.vGridControl1.OptionsBehavior.Editable = false;
                frmprecio.vGridControl1.BestFit();
                frmprecio.StartPosition = FormStartPosition.CenterScreen;
                frmprecio.vGridControl1.OptionsSelectionAndFocus.EnableAppearanceFocusedRow = false;
                frmprecio.ShowDialog();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                calculartotal();
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Maestro.frmStock frmstock = new Maestro.frmStock();
                proceso.consultar(@"
                select stockac StockFisico,StockDia Disponible ,UniMed Medida 
                from producto where producto = '" + dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString() + "'", "stock");
                frmstock.gridControl1.DataSource = proceso.ds.Tables["stock"];
                formato.Grilla(frmstock.gridView1);
                frmstock.StartPosition = FormStartPosition.CenterScreen;
                frmstock.ShowDialog();
            }
        }

        void campoprecio(decimal precio, string cadena)
        {
            dataGridView1.CurrentRow.Cells["PrecioUnitario"].Value = precio;
            dataGridView1.CurrentRow.Cells["PrecioNeto"].Value = precio;
            dataGridView1.CurrentRow.Cells["TpPrecio"].Value = cadena;
        }
        void campos(string codigo, string nombre, string documento)
        {
            txtcdCLiente.Text = codigo;
            txtnmCliente.Text = nombre;
            txtdocCliente.Text = documento;
            txtnmDireccion.Text = proceso.ConsultarCadena("Direccion", "Vva_Cliente", "Codigo = '" + codigo + "'");
            txtnmZona.Text = proceso.ConsultarCadena("Zona.Descripcion", @"Vva_Cliente INNER JOIN
                         ZONA ON Vva_Cliente.Zona = ZONA.Zona INNER JOIN
                         Distrito ON Vva_Cliente.IDDistrito = Distrito.iddistrito INNER JOIN
                         provincia ON Distrito.idprovincia = provincia.idprovincia", "Vva_Cliente.Codigo = '" + codigo + "'");
            txtnmDistrito.Text = proceso.ConsultarCadena("Distrito.descrip", @"Vva_Cliente INNER JOIN
                         ZONA ON Vva_Cliente.Zona = ZONA.Zona INNER JOIN
                         Distrito ON Vva_Cliente.IDDistrito = Distrito.iddistrito INNER JOIN
                         provincia ON Distrito.idprovincia = provincia.idprovincia", "Vva_Cliente.Codigo = '" + codigo + "'");
            txtnmProvincia.Text = proceso.ConsultarCadena("provincia.descrip", @"Vva_Cliente INNER JOIN
                         ZONA ON Vva_Cliente.Zona = ZONA.Zona INNER JOIN
                         Distrito ON Vva_Cliente.IDDistrito = Distrito.iddistrito INNER JOIN
                         provincia ON Distrito.idprovincia = provincia.idprovincia", "Vva_Cliente.Codigo = '" + codigo + "'");
        }
        void camposalmacen(string codigo, string nombre)
        {
            txtcdAlmacen.Text = codigo;
            txtnmAlmacen.Text = nombre;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.BeginEdit(true);
            }
            catch
            {
            }

        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            cantidadpedido = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantpedido"].Value);
            if (!Existe)
            {
                switch (pedido.TipoLista)
                {
                    case 1:
                        producto.TipoPrecio = btnCredito.Checked == true ? 5 : 6;
                        producto.CodigoPrecio = btnCredito.Checked == true ? "Especial05" : "Especial06";
                        break;
                    case 2:
                        //no se usa aun
                        break;
                    case 3:
                        producto.TipoPrecio = btnCredito.Checked == true ? 3 : 1; ;
                        producto.CodigoPrecio = btnCredito.Checked == true ? "CR_MENOR" : "C_MENOR";
                        break;
                }
                switch (dataGridView1.Columns[e.ColumnIndex].Name)
                {
                    case "Codigo":
                        if (dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value == null)
                            Productos("select  Codigo,Descripcion,Unidad,Fisico,Disponible from Vva_producto where activo = 1");
                        else if (proceso.ExistenciaCampo("Codigo", "Vva_Producto", "Codigo = '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "'"))
                            if (proceso.ExistenciaStock(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value), cantidadpedido, 0))
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].Value = proceso.ConsultarCadena("Descripcion", "Vva_producto", "Codigo = '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "'");
                                dataGridView1.Rows[e.RowIndex].Cells["Unidad"].Value = proceso.ConsultarCadena("Unidad", "Vva_producto", "Codigo = '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "'");
                                dataGridView1.Rows[e.RowIndex].Cells["TpPrecio"].Value = producto.TipoPrecio;
                                dataGridView1.Rows[e.RowIndex].Cells["Afecto"].Value = proceso.ConsultarCadena("Afecto", "Vva_producto", "Codigo = '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "'");
                                dataGridView1.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = proceso.ConsultarDecimal(producto.CodigoPrecio, "Vva_Producto", "Codigo = '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "'");
                                dataGridView1.Rows[e.RowIndex].Cells["PrecioNeto"].Value = proceso.ConsultarDecimal(producto.CodigoPrecio, "Vva_Producto", "Codigo = '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "'");
                                dataGridView1.Rows[e.RowIndex].Cells["Total"].Value = 0.00;
                                dataGridView1.Rows[e.RowIndex].Cells["Descuento"].Value = 0.00;
                                dataGridView1.Rows[e.RowIndex].Cells["Recargo"].Value = 0.00;
                                dataGridView1.Rows[e.RowIndex].Cells["Bonif"].Value = proceso.ConsultarDecimal(producto.CodigoPrecio, "Vva_Producto", "Codigo = '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "'") <= (decimal)0.01 ? true : false;
                                dataGridView1.Rows[e.RowIndex].Cells["Credito"].Value = btnCredito.Checked;
                                dataGridView1.Rows[e.RowIndex].Cells["Afecto"].Value = proceso.ConsultarVerdad("Afecto", "Vva_Producto", "Codigo = '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "'");
                                dataGridView1.Rows[e.RowIndex].Cells["IDBonificacion"].Value = string.Empty;
                                dataGridView1.Rows[e.RowIndex].Cells["Codigo"].ReadOnly = true;
                                dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].ReadOnly = true;
                                dataGridView1.Rows[e.RowIndex].Cells["PrecioNeto"].ReadOnly = false;
                                dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].ReadOnly = false;
                                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells["Cantidad"];
                                dataGridView1.BeginEdit(true);
                            }
                            else
                            {
                                MessageBox.Show("stock insuficiente");
                                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells["Codigo"];
                                dataGridView1.BeginEdit(true);
                            }
                        else if (proceso.ConsultarTabla_("Vva_producto", "Codigo like '%" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "%'").Rows.Count > 0)
                            Productos("select Codigo,Descripcion,Unidad,Fisico,Disponible from Vva_producto where activo = 1 and codigo like '%" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "%'");
                        else
                        {
                            MessageBox.Show("Codigo no existe o esta desactivo");
                            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells["Codigo"];
                            dataGridView1.BeginEdit(true);
                        }
                        break;
                    case "Descripcion":
                        if (dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].Value == null)
                            Productos(@"select Codigo,Descripcion,Unidad,Fisico,Disponible from Vva_producto where   = 1");
                        else if (proceso.ConsultarTabla_("Vva_producto", "descripcion like '%" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].Value) + "%'").Rows.Count > 0)
                            Productos(@"select Codigo,Descripcion,Unidad,Fisico,Disponible from Vva_producto where activo = 1 and Descripcion like '%" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].Value) + "%'");
                        else
                        {
                            MessageBox.Show("Codigo no existe o esta desactivo");
                            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells["Descripcion"];
                            dataGridView1.BeginEdit(true);
                        }
                        break;
                    case "Cantidad":
                        if (proceso.ExistenciaStock(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value), cantidadpedido, Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value)))
                        {
                            var i = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioUnitario"].Value) - Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioNeto"].Value);
                            dataGridView1.Rows[e.RowIndex].Cells["Total"].Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioNeto"].Value);
                            dataGridView1.Rows[e.RowIndex].Cells["Descuento"].Value = i > 0 ? i * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) : 0;
                            dataGridView1.Rows[e.RowIndex].Cells["Recargo"].Value = i < 0 ? Math.Abs(i) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) : 0;
                            calculartotal();
                        }
                        else
                        {
                            MessageBox.Show("stock insuficiente");
                            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells["Cantidad"];
                            dataGridView1.BeginEdit(true);
                        }

                        break;
                    case "PrecioNeto":
                        var j = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioUnitario"].Value) - Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioNeto"].Value);
                        dataGridView1.Rows[e.RowIndex].Cells["Total"].Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioNeto"].Value);
                        dataGridView1.Rows[e.RowIndex].Cells["Descuento"].Value = j > 0 ? j * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) : 0;
                        dataGridView1.Rows[e.RowIndex].Cells["Recargo"].Value = j < 0 ? Math.Abs(j) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) : 0;
                        calculartotal();
                        break;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Cantidad")
                if (Convert.ToDecimal(e.Value is DBNull ? 0 : e.Value) == 0)
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.PaleVioletRed;
                else
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Total":
                    calculartotal();
                    break;
                case "PrecioNeto":
                    calculartotal();
                    break;
                case "Descuento":
                    calculartotal();
                    break;
                case "Recargo":
                    calculartotal();
                    break;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells["Codigo"];
                dataGridView1.BeginEdit(true);
            }
        }
        void formapago(string Codigo, string condicion)
        {
            string _Codigo = "";
            string _CodigoPrecio = "";
            txtformaPago.Text = condicion;
            CodigoFP.Text = Codigo;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells["Codigo"].Value != null && dr.Cells["Descripcion"] != null)
                {
                    switch (dr.Cells["TpPrecio"].Value)
                    {
                        case 1:
                            _CodigoPrecio = "CR_MENOR";
                            dr.Cells["TpPrecio"].Value = 3;
                            break;
                        case 2:
                            _CodigoPrecio = "CR_MAYOR";
                            dr.Cells["TpPrecio"].Value = 4;
                            break;
                        case 6:
                            _CodigoPrecio = "ESPECIAL05";
                            dr.Cells["TpPrecio"].Value = 5;
                            break;
                    }
                    _Codigo = Convert.ToString(dr.Cells["Codigo"].Value);
                    dr.Cells["Credito"].Value = true;
                    dr.Cells["PrecioUnitario"].Value = proceso.ConsultarCadena(_CodigoPrecio, "Vva_Producto", "Codigo = '" + _Codigo + "'");
                    dr.Cells["PrecioNeto"].Value = proceso.ConsultarCadena(_CodigoPrecio, "Vva_Producto", "Codigo = '" + _Codigo + "'");
                    dr.Cells["Total"].Value = Convert.ToDecimal(dr.Cells["Cantidad"].Value) * Convert.ToDecimal(dr.Cells["PrecioNeto"].Value);
                }
            }
        }

        private void frmpedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                btnCancelar_Click(sender, e);
        }

        private void frmpedido_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 18;
        }

        private void txtcdAlmacen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            entidad.tabla = "almacen";
            Maestro.frmAlmacen frmalmacen = new Maestro.frmAlmacen();
            frmalmacen.pasar += new Maestro.frmAlmacen.campos(camposalmacen);
            proceso.consultar("select Codigo,Nombre from almacen where activo = 1", entidad.tabla);
            frmalmacen.gridControl1.DataSource = proceso.ds.Tables[entidad.tabla];
            formato.Grilla(frmalmacen.gridView1);
            frmalmacen.StartPosition = FormStartPosition.CenterScreen;
            frmalmacen.ShowDialog();
        }

        private void txtcdCLiente_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtcdVendedor.Text.Trim().Length > 0 && txtnmVendedor.Text.Trim().Length > 10)
            {
                Maestro.frmCliente frmcliente = new Maestro.frmCliente();
                frmcliente.pasar += new Maestro.frmCliente.campos(campos);
                proceso.consultar(@"SELECT dbo.CLIENTE.Cliente AS Codigo, dbo.CLIENTE.Alias AS Nombre, 
                CASE WHEN len(dni) > 0 AND len(Ruc) = 0 THEN Dni WHEN len(dni) = 0 AND len(Ruc) > 0 THEN Ruc ELSE Ruc END AS Documento
                FROM  dbo.CLIENTE INNER JOIN dbo.ZONA_PERSONAL ON dbo.CLIENTE.Zona = dbo.ZONA_PERSONAL.Zona WHERE (dbo.ZONA_PERSONAL.Personal = '" + txtcdVendedor.Text.Trim() + @"')
                AND (dbo.ZONA_PERSONAL.Numero = DATEPART(dw,'" + Convert.ToDateTime(dateEmision.EditValue).ToString("yyyyMMdd") + "')) AND(Cliente.Estado = 'A')", "cliente");
                frmcliente.gridControl1.DataSource = proceso.ds.Tables["cliente"];
                formato.Grilla(frmcliente.gridView1);
                frmcliente.StartPosition = FormStartPosition.CenterScreen;
                frmcliente.ShowDialog();
            }
            else
                MessageBox.Show("pedido no cuenta con datos de vendedor");
        }

        private void txtcdCLiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                if (txtcdVendedor.Text.Trim().Length > 0 && txtnmVendedor.Text.Trim().Length > 10)
                    if (txtcdCLiente.Text.Length == 0)
                    {
                        Maestro.frmCliente frmcliente = new Maestro.frmCliente();
                        frmcliente.pasar += new Maestro.frmCliente.campos(campos);
                        proceso.consultar(@"SELECT Codigo,Nombre,Documento from Vva_Clientevendedor where (Personal = '" + txtcdVendedor.Text.Trim() + @"')
                        AND (Dia = DATEPART(dw,'" + Convert.ToDateTime(dateEmision.EditValue).ToString("yyyyMMdd") + "'))", "cliente");
                        frmcliente.gridControl1.DataSource = proceso.ds.Tables["cliente"];
                        formato.Grilla(frmcliente.gridView1);
                        frmcliente.StartPosition = FormStartPosition.CenterScreen;
                        frmcliente.ShowDialog();
                    }
                    else if (proceso.ExistenciaCampo("Codigo", "Vva_Clientevendedor", "Codigo = '" + txtcdCLiente.Text.Trim() + "'"))
                    {
                        txtnmCliente.Text = proceso.ConsultarCadena
                          ("Nombre", "Vva_Clientevendedor", "Dia = datepart(dw,'" + Convert.ToDateTime(dateEmision.EditValue).ToString("yyyyMMdd") + "') and personal = '" + txtcdVendedor.Text.Trim() + "' and codigo = '" + txtcdCLiente.Text.Trim() + "'");
                        txtdocCliente.Text = proceso.ConsultarCadena
                          ("Documento", "Vva_Clientevendedor", "Dia = datepart(dw,'" + Convert.ToDateTime(dateEmision.EditValue).ToString("yyyyMMdd") + "') and personal = '" + txtcdVendedor.Text.Trim() + "' and codigo = '" + txtcdCLiente.Text.Trim() + "'");
                        txtnmDireccion.Text = proceso.ConsultarCadena("Direccion", "Vva_Cliente", "Codigo = '" + txtcdCLiente.Text.Trim() + "'");
                        txtnmZona.Text = proceso.ConsultarCadena("Zona.Descripcion", @"Vva_Cliente INNER JOIN
                              ZONA ON Vva_Cliente.Zona = ZONA.Zona INNER JOIN
                              Distrito ON Vva_Cliente.IDDistrito = Distrito.iddistrito INNER JOIN
                              provincia ON Distrito.idprovincia = provincia.idprovincia", "Vva_Cliente.Codigo = '" + txtcdCLiente.Text.Trim() + "'");
                        txtnmDistrito.Text = proceso.ConsultarCadena("Distrito.descrip", @"Vva_Cliente INNER JOIN
                              ZONA ON Vva_Cliente.Zona = ZONA.Zona INNER JOIN
                              Distrito ON Vva_Cliente.IDDistrito = Distrito.iddistrito INNER JOIN
                              provincia ON Distrito.idprovincia = provincia.idprovincia", "Vva_Cliente.Codigo = '" + txtcdCLiente.Text.Trim() + "'");
                        txtnmProvincia.Text = proceso.ConsultarCadena("provincia.descrip", @"Vva_Cliente INNER JOIN
                              ZONA ON Vva_Cliente.Zona = ZONA.Zona INNER JOIN
                              Distrito ON Vva_Cliente.IDDistrito = Distrito.iddistrito INNER JOIN
                              provincia ON Distrito.idprovincia = provincia.idprovincia", "Vva_Cliente.Codigo = '" + txtcdCLiente.Text.Trim() + "'");
                    }
                    else if (proceso.ConsultarTabla_("Vva_Clientevendedor", "Codigo like '%" + txtcdCLiente.Text.Trim() + "%'").Rows.Count > 0)
                    {
                        Maestro.frmCliente frmcliente = new Maestro.frmCliente();
                        frmcliente.pasar += new Maestro.frmCliente.campos(campos);
                        proceso.consultar(@" select Codigo,Nombre,Documento from  Vva_Clientevendedor where (Personal = '" + txtcdVendedor.Text.Trim() + @"')
                            AND (Dia = DATEPART(dw,'" + Convert.ToDateTime(dateEmision.EditValue).ToString("yyyyMMdd") + @"')) 
                            and Codigo like '%" + txtcdCLiente.Text.Trim() + "%'", "cliente");
                        frmcliente.gridControl1.DataSource = proceso.ds.Tables["cliente"];
                        formato.Grilla(frmcliente.gridView1);
                        frmcliente.StartPosition = FormStartPosition.CenterScreen;
                        frmcliente.ShowDialog();
                    }
                    else
                        MessageBox.Show("Codigo no existe");
                else
                    MessageBox.Show("pedido no cuenta con datos de vendedor");
        }

        private void txtcdVendedor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (var Context = new LiderEntities())
            {
                Maestro.frmVendedor frmvendedor = new Maestro.frmVendedor();
                frmvendedor.pasar += new Maestro.frmVendedor.campos(camposvendedor);
                var _RVentas = (from Rv in Context.PERSONALs.Where(w => w.Activo == true)
                                join Fv in Context.FuerzaVentas.Where(wx => wx.Activo == true) on Rv.fzavtas equals Fv.fzavtas
                                select new
                                {
                                    Codigo = Rv.Personal1,
                                    Nombre = Rv.Nombre
                                }).ToList();
                frmvendedor.gridControl1.DataSource = _RVentas;
                formato.Grilla(frmvendedor.gridView1);
                frmvendedor.StartPosition = FormStartPosition.CenterScreen;
                frmvendedor.ShowDialog();
            }
        }

        private void txtcdVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            using (var Ctx = new LiderEntities())
            {
                var _RVentas = (from Rv in Ctx.PERSONALs.Where(w => w.Activo == true)
                                join Fv in Ctx.FuerzaVentas.Where(wx => wx.Activo == true) on Rv.fzavtas equals Fv.fzavtas
                                select new
                                {
                                    Codigo = Rv.Personal1,
                                    Nombre = Rv.Nombre
                                }).ToList();

                if (e.KeyChar == (int)Keys.Enter)
                {
                    if (!proceso.ExistenciaCampo("codigo", "Vva_Clientevendedor", "codigo = '" + txtcdCLiente.Text.Trim() + "' and personal = " +
                        "'" + txtcdVendedor.Text.Trim() + "'  AND (Dia = DATEPART(dw,'" + Convert.ToDateTime(dateEmision.EditValue).ToString("yyyyMMdd") + "'))"))
                    {
                        txtcdCLiente.ResetText();
                        txtnmCliente.ResetText();
                        txtdocCliente.ResetText();
                    }
                    if (txtcdVendedor.Text.Length == 0)
                    {
                        Maestro.frmVendedor frmvendedor = new Maestro.frmVendedor();
                        frmvendedor.pasar += new Maestro.frmVendedor.campos(camposvendedor);
                        frmvendedor.gridControl1.DataSource = _RVentas;
                        formato.Grilla(frmvendedor.gridView1);
                        frmvendedor.StartPosition = FormStartPosition.CenterScreen;
                        frmvendedor.ShowDialog();
                    }
                    else if (_RVentas.Where(x => x.Codigo == txtcdVendedor.Text.Trim()).FirstOrDefault() != null)
                    {
                        txtnmVendedor.Text = Convert.ToString(_RVentas.Where(x => x.Codigo == txtcdVendedor.Text.Trim()).Select(y => y.Nombre.Trim()).FirstOrDefault());
                    }
                    else if (_RVentas.Where(x => x.Codigo.Contains(txtcdVendedor.Text.Trim())).Count() > 0)
                    {
                        Maestro.frmVendedor frmvendedor = new Maestro.frmVendedor();
                        frmvendedor.pasar += new Maestro.frmVendedor.campos(camposvendedor);
                        frmvendedor.gridControl1.DataSource = _RVentas.Where(x => x.Codigo.Contains(txtcdVendedor.Text.Trim()));
                        formato.Grilla(frmvendedor.gridView1);
                        frmvendedor.StartPosition = FormStartPosition.CenterScreen;
                        frmvendedor.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Codigo no existe");
                    }
                }
            }
        }

        private void txtdocCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            entidad.tabla = "cliente";
            if (e.KeyChar == (int)Keys.Enter)
                if (txtcdVendedor.Text.Length > 0 && txtnmVendedor.Text.Length > 0)
                    if (txtdocCliente.Text.Length == 0)
                    {
                        Maestro.frmCliente frmcliente = new Maestro.frmCliente();
                        frmcliente.pasar += new Maestro.frmCliente.campos(campos);
                        proceso.consultar(
                        @" select Codigo,Nombre,Documento 
                        from Vva_Clientevendedor where personal = '" + txtcdVendedor.Text.Trim() +
                        @"' and Dia = datepart(dw,'" + Convert.ToDateTime(dateEmision.EditValue).ToString("yyyyMMdd") + "')", "cliente");
                        frmcliente.gridControl1.DataSource = proceso.ds.Tables["cliente"];
                        formato.Grilla(frmcliente.gridView1);
                        frmcliente.StartPosition = FormStartPosition.CenterScreen;
                        frmcliente.ShowDialog();
                    }
                    else if (proceso.ExistenciaCampo("Codigo", "Vva_Clientevendedor", "(Documento = '" + txtdocCliente.Text.Trim() + "')"))
                    {
                        txtcdCLiente.Text = proceso.ConsultarCadena("Nombre", "Vva_Clientevendedor", "Documento = '" + txtdocCliente.Text.Trim() + "'");
                        txtnmCliente.Text = proceso.ConsultarCadena("Nombre", "Vva_Clientevendedor", "Documento = '" + txtcdCLiente.Text.Trim() + "'");
                        txtnmDireccion.Text = proceso.ConsultarCadena("Direccion", "Vva_Cliente", "Codigo = '" + txtcdCLiente.Text.Trim() + "'");
                        txtnmZona.Text = proceso.ConsultarCadena("Zona.Descripcion", @"Vva_Cliente INNER JOIN
                              ZONA ON Vva_Cliente.Zona = ZONA.Zona INNER JOIN
                              Distrito ON Vva_Cliente.IDDistrito = Distrito.iddistrito INNER JOIN
                              provincia ON Distrito.idprovincia = provincia.idprovincia", "Vva_Cliente.Codigo = '" + txtcdCLiente.Text.Trim() + "'");
                        txtnmDistrito.Text = proceso.ConsultarCadena("Distrito.descrip", @"Vva_Cliente INNER JOIN
                              ZONA ON Vva_Cliente.Zona = ZONA.Zona INNER JOIN
                              Distrito ON Vva_Cliente.IDDistrito = Distrito.iddistrito INNER JOIN
                              provincia ON Distrito.idprovincia = provincia.idprovincia", "Vva_Cliente.Codigo = '" + txtcdCLiente.Text.Trim() + "'");
                        txtnmProvincia.Text = proceso.ConsultarCadena("provincia.descrip", @"Vva_Cliente INNER JOIN
                              ZONA ON Vva_Cliente.Zona = ZONA.Zona INNER JOIN
                              Distrito ON Vva_Cliente.IDDistrito = Distrito.iddistrito INNER JOIN
                              provincia ON Distrito.idprovincia = provincia.idprovincia", "Vva_Cliente.Codigo = '" + txtcdCLiente.Text.Trim() + "'");
                    }
                    else if (proceso.ConsultarTabla_("Vva_Clientevendedor", "(Documento like '%" + txtdocCliente.Text.Trim() + "%')").Rows.Count > 0)
                    {
                        Maestro.frmCliente frmcliente = new Maestro.frmCliente();
                        frmcliente.pasar += new Maestro.frmCliente.campos(campos);
                        proceso.consultar(
                        @"select distinct Codigo,Nombre,Documento 
                            from Vva_Clientevendedor where  Documento like '%" + txtdocCliente.Text.Trim() + "%'", "cliente");
                        frmcliente.gridControl1.DataSource = proceso.ds.Tables["cliente"];
                        formato.Grilla(frmcliente.gridView1);
                        frmcliente.StartPosition = FormStartPosition.CenterScreen;
                        frmcliente.ShowDialog();
                    }
                    else
                        MessageBox.Show("Codigo no existe");
                else
                    MessageBox.Show("pedido no cuenta con datos de vendedor");
        }

        private void txtnmCliente_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) => txtcdCLiente_ButtonClick(sender, e);

        private void txtnmCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                if (txtnmCliente.Text.Length == 0)
                {
                    Maestro.frmCliente frmcliente = new Maestro.frmCliente();
                    frmcliente.pasar += new Maestro.frmCliente.campos(campos);
                    proceso.consultar(
                    @"SELECT        
                    dbo.CLIENTE.Cliente AS Codigo, dbo.CLIENTE.Alias AS Nombre, 
                    CASE WHEN len(dni) > 0 AND len(Ruc) = 0 THEN Dni WHEN len(dni) = 0 AND len(Ruc) > 0 THEN Ruc ELSE Ruc END AS Documento
                    FROM            
                    dbo.CLIENTE INNER JOIN
                    dbo.ZONA_PERSONAL ON dbo.CLIENTE.Zona = dbo.ZONA_PERSONAL.Zona
                    WHERE        
                    (dbo.ZONA_PERSONAL.Personal = '" + txtcdVendedor.Text.Trim() + @"')
                    AND (dbo.ZONA_PERSONAL.Numero = DATEPART(dw,'" + Convert.ToDateTime(dateEmision.EditValue).ToString("yyyyMMdd") +
                    @"')) AND(Cliente.Estado = 'A')", "Cliente");
                    frmcliente.gridControl1.DataSource = proceso.ds.Tables["Cliente"];
                    formato.Grilla(frmcliente.gridView1);
                    frmcliente.StartPosition = FormStartPosition.CenterScreen;
                    frmcliente.ShowDialog();
                }
                else if (proceso.ExistenciaCampo("alias", "Cliente", "alias like '%" + txtnmCliente.Text.Trim() + "%'"))
                {
                    Maestro.frmCliente frmcliente = new Maestro.frmCliente();
                    frmcliente.pasar += new Maestro.frmCliente.campos(campos);
                    proceso.consultar(
                    @"SELECT        
                        dbo.CLIENTE.Cliente AS Codigo, dbo.CLIENTE.Alias AS Nombre, 
                        CASE WHEN len(dni) > 0 AND len(Ruc) = 0 THEN Dni WHEN len(dni) = 0 AND len(Ruc) > 0 THEN Ruc ELSE Ruc END AS Documento
                        FROM            
                        dbo.CLIENTE INNER JOIN
                        dbo.ZONA_PERSONAL ON dbo.CLIENTE.Zona = dbo.ZONA_PERSONAL.Zona
                        WHERE        
                        (dbo.ZONA_PERSONAL.Personal = '" + txtcdVendedor.Text.Trim() + @"')
                        AND (dbo.ZONA_PERSONAL.Numero = DATEPART(dw,'" + Convert.ToDateTime(dateEmision.EditValue).ToString("yyyyMMdd") +
                    @"')) AND(Cliente.Estado = 'A') AND (alias like '%" + txtnmCliente.Text.Trim() + "%')", "Cliente");
                    frmcliente.gridControl1.DataSource = proceso.ds.Tables["Cliente"];
                    formato.Grilla(frmcliente.gridView1);
                    frmcliente.StartPosition = FormStartPosition.CenterScreen;
                    frmcliente.ShowDialog();
                }
                else
                    MessageBox.Show("Codigo no existe");
        }

        private void txtnmVendedor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            entidad.tabla = "vendedor";
            Maestro.frmVendedor frmvendedor = new Maestro.frmVendedor();
            frmvendedor.pasar += new Maestro.frmVendedor.campos(camposvendedor);
            proceso.consultar(@"select personal Codigo,nombre Nombre from personal where vendedor = 1 and activo = 1", "Vendedor");
            frmvendedor.gridControl1.DataSource = proceso.ds.Tables["Vendedor"];
            formato.Grilla(frmvendedor.gridView1);
            frmvendedor.StartPosition = FormStartPosition.CenterScreen;
            frmvendedor.ShowDialog();
        }

        private void txtnmVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                if (txtnmVendedor.Text.Length == 0)
                {
                    entidad.tabla = "vendedor";
                    Maestro.frmVendedor frmvendedor = new Maestro.frmVendedor();
                    frmvendedor.pasar += new Maestro.frmVendedor.campos(camposvendedor);
                    proceso.consultar(
                    @"select personal Codigo,nombre Nombre from personal where vendedor = 1 and activo = 1", "Vendedor");
                    frmvendedor.gridControl1.DataSource = proceso.ds.Tables["Vendedor"];
                    formato.Grilla(frmvendedor.gridView1);
                    frmvendedor.StartPosition = FormStartPosition.CenterScreen;
                    frmvendedor.ShowDialog();
                }
                else if (proceso.ExistenciaCampo("personal", "personal", "nombre = '" + txtnmVendedor.Text.Trim() + "'"))
                    txtcdVendedor.Text = proceso.ConsultarCadena("personal", "personal", "nombre = '" + txtnmVendedor.Text.Trim() + "'");
                else if (proceso.ConsultarTabla_("personal", "nombre like '%" + txtnmVendedor.Text.Trim() + "%'").Rows.Count > 0)
                {
                    entidad.tabla = "vendedor";
                    Maestro.frmVendedor frmvendedor = new Maestro.frmVendedor();
                    frmvendedor.pasar += new Maestro.frmVendedor.campos(camposvendedor);
                    proceso.consultar(
                    @"select personal Codigo,nombre Nombre from personal where vendedor = 1 and activo = 1 and nombre like '%" + txtnmVendedor.Text.Trim() + "%'", "Vendedor");
                    frmvendedor.gridControl1.DataSource = proceso.ds.Tables["Vendedor"];
                    formato.Grilla(frmvendedor.gridView1);
                    frmvendedor.StartPosition = FormStartPosition.CenterScreen;
                    frmvendedor.ShowDialog();
                }
                else
                    MessageBox.Show("Codigo no existe");
        }

        private void txttipoDocumento_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            entidad.tabla = "tipodocumento";
            Maestro.frmTipoDocumento frmtipodocumento = new Maestro.frmTipoDocumento();
            frmtipodocumento.pasar += new Maestro.frmTipoDocumento.campos(campostipodocumento);
            proceso.consultar("select Descripcion from doctipo", entidad.tabla);
            frmtipodocumento.gridControl1.DataSource = proceso.ds.Tables[entidad.tabla];
            formato.Grilla(frmtipodocumento.gridView1);
            frmtipodocumento.ShowDialog();

        }
        #region Enlazados:
        void camposproducto(string codigo, string descripcion, string unidad)
        {
            if (!Existe)
                if (proceso.ExistenciaStock(codigo, cantidadpedido, 0))
                {
                    dataGridView1.Rows[index].Cells["Codigo"].Value = codigo;
                    dataGridView1.Rows[index].Cells["Descripcion"].Value = descripcion;
                    dataGridView1.Rows[index].Cells["Unidad"].Value = unidad;
                    dataGridView1.Rows[index].Cells["TpPrecio"].Value = producto.TipoPrecio;
                    dataGridView1.Rows[index].Cells["Afecto"].Value = proceso.ConsultarCadena("Afecto", "Vva_producto", "Codigo = '" + codigo + "'");
                    dataGridView1.Rows[index].Cells["PrecioUnitario"].Value = proceso.ConsultarDecimal(producto.CodigoPrecio, "Vva_Producto", "Codigo = '" + codigo + "'");
                    dataGridView1.Rows[index].Cells["PrecioNeto"].Value = proceso.ConsultarDecimal(producto.CodigoPrecio, "Vva_Producto", "Codigo = '" + codigo + "'");
                    dataGridView1.Rows[index].Cells["Total"].Value = 0.00;
                    dataGridView1.Rows[index].Cells["Descuento"].Value = 0.00;
                    dataGridView1.Rows[index].Cells["Recargo"].Value = 0.00;
                    dataGridView1.Rows[index].Cells["Bonif"].Value = proceso.ConsultarDecimal(producto.CodigoPrecio, "Vva_Producto", "Codigo = '" + codigo + "'") <= (decimal)0.01 ? true : false;
                    dataGridView1.Rows[index].Cells["Credito"].Value = btnCredito.Checked;
                    dataGridView1.Rows[index].Cells["Afecto"].Value = proceso.ConsultarVerdad("Afecto", "Vva_Producto", "Codigo = '" + codigo + "'");
                    dataGridView1.Rows[index].Cells["IDBonificacion"].Value = string.Empty;
                    dataGridView1.Rows[index].Cells["Codigo"].ReadOnly = true;
                    dataGridView1.Rows[index].Cells["Descripcion"].ReadOnly = true;
                    dataGridView1.Rows[index].Cells["PrecioNeto"].ReadOnly = false;
                    dataGridView1.Rows[index].Cells["Cantidad"].ReadOnly = false;
                    dataGridView1.Rows[index].Cells["Cantidad"].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells["Cantidad"];
                }
                else
                {
                    MessageBox.Show("stock insuficiente");
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells["Codigo"];
                    dataGridView1.BeginEdit(true);
                }

        }
        void campostipodocumento(string nombre)
        {
            txttipoDocumento.Text = nombre;
        }
        void camposvendedor(string codigo, string nombre)
        {
            txtcdVendedor.Text = codigo;
            txtnmVendedor.Text = nombre;
        }
        void Productos(string sql)
        {
            Maestro.frmProducto frmproducto = new Maestro.frmProducto();
            frmproducto.pasar += new Maestro.frmProducto.variables(camposproducto);
            proceso.consultar(sql, "Producto");
            frmproducto.gridControl1.DataSource = proceso.ds.Tables["Producto"];
            formato.Grilla(frmproducto.gridView1);
            frmproducto.StartPosition = FormStartPosition.CenterScreen;
            frmproducto.ShowDialog();
        }

        public void calculartotal()
        {
            var subtotal = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>()
                            select (Convert.ToDecimal(detalle.Cells["Cantidad"].Value) * Convert.ToDecimal(detalle.Cells["PrecioUnitario"].Value))).Sum();

            var descuento = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>()
                             select (Convert.ToDecimal(detalle.Cells["Descuento"].Value))).Sum();

            var recargo = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>()
                           select (Convert.ToDecimal(detalle.Cells["Recargo"].Value))).Sum();

            var afecto = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>()
                          where Convert.ToBoolean(detalle.Cells["Afecto"].Value) == true
                          select ((Convert.ToDecimal(detalle.Cells["Total"].Value)) / (decimal)1.18)).Sum();

            var inafecto = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>()
                            where Convert.ToBoolean(detalle.Cells["Afecto"].Value) == false
                            select Convert.ToDecimal(detalle.Cells["Total"].Value)).Sum();

            var impuesto = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>()
                            where Convert.ToBoolean(detalle.Cells["Afecto"].Value) == true
                            select (Convert.ToDecimal(detalle.Cells["Total"].Value) - (Convert.ToDecimal(detalle.Cells["Total"].Value) / (decimal)1.18))).Sum();

            var total = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>()
                         select (Convert.ToDecimal(detalle.Cells["Total"].Value))).Sum();

            txtValorSubtotal.Text = subtotal.ToString("N2");
            txtValorDescuento.Text = descuento.ToString("N2");
            txtValorRecargo.Text = recargo.ToString("N2");
            txtValorAfecto.Text = afecto.ToString("N2");
            txtValorInafecto.Text = inafecto.ToString("N2");
            txtValorImpuesto.Text = impuesto.ToString("N2");
            txtValorImporteTotal.Text = total.ToString("N2");
        }
        #endregion
    }
}