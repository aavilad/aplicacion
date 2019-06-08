using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmpedido : DevExpress.XtraEditors.XtraForm
    {
        decimal cantidadpedido = 0;
        string CodigoPrecio;
        string Fecha;
        Libreria.Formato formato = new Libreria.Formato();
        int index = 0;
        Libreria.Rutina proceso = new Libreria.Rutina();
        string tabla = "nuevoPedido";
        int TipoLista = 0;
        decimal PorEspecial = 0;
        int TipoPrecio = 0;
        public bool Existe;
        public int tipoprecio;

        public frmpedido()
        {
            InitializeComponent();
        }

        public delegate void varaible(string CdPedido, string TpDoc, string CdVendedor, string CdCliente, string CdFP, DateTime Fecha, string NmCliente, string Ruc, string Direccion, string Dni, string NmVendedor,
            string Gestion, string IdDistrito, DataGridView dgv);

        public event varaible pasar;

        private void MaestroCliente()
        {
            Maestro.frmCliente frmcliente = new Maestro.frmCliente();
            frmcliente.pasar += new Maestro.frmCliente.campos(campos);
            string sql = btnFueraRuta.Checked == true ? Libreria.Constante.Cliente : Libreria.Constante.ClienteVendedor.Replace("@Fecha", Fecha).Replace("@Vendedor", txtcdVendedor.Text.Trim());
            proceso.consultar(sql, "cliente");
            frmcliente.gridControl1.DataSource = proceso.ds.Tables["cliente"];
            formato.Grilla(frmcliente.gridView1);
            frmcliente.StartPosition = FormStartPosition.CenterScreen;
            frmcliente.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int n = 0;
            while (n < 6)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var Codigo = dataGridView1.Rows[i].Cells["Codigo"].Value;
                    var Descripcion = dataGridView1.Rows[i].Cells["Descripcion"].Value;
                    var Cantidad = dataGridView1.Rows[i].Cells["Cantidad"].Value;
                    var Unidad = dataGridView1.Rows[i].Cells["unidad"].Value;
                    if (Codigo == null && Descripcion == null && Cantidad == null && Unidad == null)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }
                n++;
            }
            using (var CTX = new LiderEntities())
            {
                string NumeroPedido = txtcdDocumento.Text.Trim();
                string CodigoVendedor = txtcdVendedor.Text.Trim();
                string CodigoCliente = txtcdCLiente.Text.Trim();
                string FormaPago = CodigoFP.Text;
                string NombreCliente = txtnmCliente.Text;
                string DocumentoCliente = txtdocCliente.Text.Trim();
                string DireccionCliente = txtnmDireccion.Text;
                string NombreVendedor = txtnmVendedor.Text;
                string Gestion = txtcdGestion.Text.Trim();
                string DistritoCliente = txtcdDistrito.Text.Trim();
                string TipoPedido = txtdocCliente.Text.Trim().Length == 11 ? "F" : "B";
                if (!CTX.PEDIDOes.Where(x => x.Pedido1 == NumeroPedido).Select(y => y.Procesado).FirstOrDefault())
                    try
                    {
                        if (dxValidationProvider1.Validate())
                        {
                            pasar(NumeroPedido, TipoPedido, CodigoVendedor, CodigoCliente, FormaPago, Convert.ToDateTime(dateEmision.EditValue), NombreCliente, DocumentoCliente.Length == 8 ? string.Empty : DocumentoCliente,
                                DireccionCliente, DocumentoCliente.Length == 11 ? string.Empty : DocumentoCliente, NombreVendedor, Gestion, DistritoCliente, dataGridView1);
                            this.Close();
                        }
                    }
                    catch (DbEntityValidationException t)
                    {
                        var Formulario = new Elementos.frmResult();
                        foreach (DbEntityValidationResult item in t.EntityValidationErrors)
                        {
                            DbEntityEntry entry = item.Entry;
                            string entityTypeName = entry.Entity.GetType().Name;
                            foreach (DbValidationError subItem in item.ValidationErrors)
                            {
                                string message = string.Format("Error '{0}' occurred in {1} at {2}", subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                                Formulario.MemoEd.Text += message + "\n";
                                Formulario.Show();
                            }
                        }
                    }
                else
                    MessageBox.Show("Pedido se encuentra procesado.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                try
                {
                    if (txtcdCLiente.Text.Length > 0 && txtnmCliente.Text.Length > 0)
                    {

                        TipoLista = CTX.PERSONALs.Where(w => w.Personal1 == txtcdVendedor.Text.Trim()).Select(s => s.clase).FirstOrDefault();
                        PorEspecial = (from Tipo in CTX.TIPOCLIs.Where(w => w.TipoCli1 == "E").AsEnumerable()
                                       join Cl in CTX.CLIENTEs.Where(w => w.Estado == "A" && w.Cliente1 == txtcdCLiente.Text.Trim()).AsEnumerable() on Tipo.TipoCli1 equals Cl.TipoCli
                                       select Convert.ToDecimal(Tipo.Porcentaje)).FirstOrDefault();
                        dataGridView1.Rows.Add();
                        btnCredito.Enabled = true;
                    }
                    else
                        MessageBox.Show("pedido no cuenta datos de cliente");
                }
                catch (DbEntityValidationException t)
                {
                    foreach (var eve in t.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show("- Property: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
                        }
                    }
                }
            }
        }

        private void btnBonificar_Click(object sender, EventArgs e)
        {
            int n = 0;
            while (n < 4)
            {
                foreach (DataGridViewRow Fa in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(Fa.Cells["Bonif"].Value) == true)
                    {
                        dataGridView1.Rows.RemoveAt(Fa.Index);
                    }
                }
                n++;
            }
            var Evaluar = new Libreria.Pedido_Bonificar();
            Existe = true;
            Evaluar.Evaluar_Bonificacion(dataGridView1, Convert.ToDateTime(dateEmision.EditValue).ToString("dd/MM/yyyy"));
            Existe = false;
            proceso.Procedimiento("sp_stock_sistema '" + DateTime.Now.Date.ToString("yyyyMMdd") + "',2");
            proceso.Procedimiento("sp_stock_sistema_web '" + DateTime.Now.Date.ToString("yyyyMMdd") + "',2");

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
                                            CodigoPrecio = "C_MENOR";
                                            dr.Cells["TpPrecio"].Value = 1;
                                            break;
                                        case 4:
                                            CodigoPrecio = "C_MAYOR";
                                            dr.Cells["TpPrecio"].Value = 2;
                                            break;
                                        case 5:
                                            CodigoPrecio = "ESPECIAL06";
                                            dr.Cells["TpPrecio"].Value = 6;
                                            break;
                                    }
                                    txtformaPago.Text = "CONTADO";
                                    string codigo = dr.Cells["Codigo"].Value.ToString();
                                    dr.Cells["Credito"].Value = false;
                                    dr.Cells["PrecioUnitario"].Value = proceso.ConsultarCadena(CodigoPrecio, "Vva_Producto", "Codigo = '" + codigo + "'");
                                    dr.Cells["PrecioNeto"].Value = proceso.ConsultarCadena(CodigoPrecio, "Vva_Producto", "Codigo = '" + codigo + "'");
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
                string directorio = xtraOpenFileDialog1.FileName;
                string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + directorio + ";Extended Properties=Excel 12.0;";
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

        void camposproducto(string codigo, string descripcion, string unidad)
        {
            if (!Existe)
                using (var CTX = new LiderEntities())
                {
                    var Product = CTX.PRODUCTOes.Where(x => x.Activo == true && x.Producto1 == codigo);
                    if (Product.Select(x => x.StockDia + cantidadpedido).FirstOrDefault() > 0)
                    {
                        dataGridView1.Rows[index].Cells["Codigo"].Value = codigo;
                        dataGridView1.Rows[index].Cells["Descripcion"].Value = descripcion;
                        dataGridView1.Rows[index].Cells["Unidad"].Value = unidad;
                        dataGridView1.Rows[index].Cells["TpPrecio"].Value = TipoPrecio;
                        dataGridView1.Rows[index].Cells["PrecioUnitario"].Value = proceso.ConsultarDecimal(CodigoPrecio, "Vva_Producto", "Codigo = '" + codigo + "'");
                        dataGridView1.Rows[index].Cells["PrecioNeto"].Value = PorEspecial > 0 ? Convert.ToDecimal(Product.Select(x => x.Costo * (1 + (PorEspecial / 100))).FirstOrDefault()) : proceso.ConsultarDecimal(CodigoPrecio, "Vva_Producto", "Codigo = '" + codigo + "'");
                        dataGridView1.Rows[index].Cells["Total"].Value = 0.00;
                        dataGridView1.Rows[index].Cells["Descuento"].Value = 0.00;
                        dataGridView1.Rows[index].Cells["Recargo"].Value = 0.00;
                        dataGridView1.Rows[index].Cells["Bonif"].Value = proceso.ConsultarDecimal(CodigoPrecio, "Vva_Producto", "Codigo = '" + codigo + "'") <= (decimal)0.01 ? true : false;
                        dataGridView1.Rows[index].Cells["Credito"].Value = btnCredito.Checked;
                        dataGridView1.Rows[index].Cells["Afecto"].Value = Product.Select(x => x.ConIgv).FirstOrDefault();
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
            string Valor;
            index = e.RowIndex;
            cantidadpedido = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantpedido"].Value);
            if (!Existe)
            {
                switch (TipoLista)
                {
                    case 1:
                        TipoPrecio = btnCredito.Checked == true ? 5 : 6;
                        CodigoPrecio = btnCredito.Checked == true ? "Especial05" : "Especial06";
                        break;
                    case 2:
                        //no se usa aun
                        break;
                    case 3:
                        TipoPrecio = btnCredito.Checked == true ? 3 : 1; ;
                        CodigoPrecio = btnCredito.Checked == true ? "CR_MENOR" : "C_MENOR";
                        break;
                }
                using (var CTX = new LiderEntities())
                {
                    int Y = dataGridView1.CurrentRow.Index;
                    try
                    {
                        switch (dataGridView1.Columns[e.ColumnIndex].Name)
                        {
                            case "Codigo":
                                Valor = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) is DBNull ? "" : Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value);
                                if (Valor == "") ;
                                else if (CTX.PRODUCTOes.Where(x => x.Activo && x.Producto1 == Valor).Count() == 1)
                                {
                                    var Product = CTX.PRODUCTOes.Where(x => x.Activo && x.Producto1 == Valor);
                                    if (Product.Select(s => s.StockDia + cantidadpedido).FirstOrDefault() > 0)
                                    {
                                        dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value = Product.Select(x => x.Producto1.Trim()).FirstOrDefault();
                                        dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].Value = Product.Select(x => x.Descripcion.Trim()).FirstOrDefault();
                                        dataGridView1.Rows[e.RowIndex].Cells["Unidad"].Value = Product.Select(x => x.UniMed.Trim()).FirstOrDefault();
                                        dataGridView1.Rows[e.RowIndex].Cells["TpPrecio"].Value = TipoPrecio;
                                        dataGridView1.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = proceso.ConsultarDecimal(CodigoPrecio, "Vva_Producto", "Codigo = '" + Valor + "'");
                                        dataGridView1.Rows[e.RowIndex].Cells["PrecioNeto"].Value = PorEspecial > 0 ? Convert.ToDecimal(Product.Select(x => x.Costo * (1 + (PorEspecial / 100))).FirstOrDefault()) : proceso.ConsultarDecimal(CodigoPrecio, "Vva_Producto", "Codigo = '" + Valor + "'");
                                        dataGridView1.Rows[e.RowIndex].Cells["Total"].Value = 0.00;
                                        dataGridView1.Rows[e.RowIndex].Cells["Descuento"].Value = 0.00;
                                        dataGridView1.Rows[e.RowIndex].Cells["Recargo"].Value = 0.00;
                                        dataGridView1.Rows[e.RowIndex].Cells["Bonif"].Value = proceso.ConsultarDecimal(CodigoPrecio, "Vva_Producto", "Codigo = '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "'") <= (decimal)0.01 ? true : false;
                                        dataGridView1.Rows[e.RowIndex].Cells["Credito"].Value = btnCredito.Checked;
                                        dataGridView1.Rows[e.RowIndex].Cells["Afecto"].Value = Product.Select(s => s.ConIgv).FirstOrDefault();
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
                                }
                                else if (CTX.PRODUCTOes.Where(x => x.Activo && x.Producto1.StartsWith(Valor)).Count() > 0)
                                { Productos("select Codigo,Descripcion,Unidad,Fisico,Disponible from Vva_producto where activo = 1 and codigo like '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value) + "%'"); }
                                else
                                {
                                    MessageBox.Show("No se encuentra alguna coincidencia.");
                                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
                                    dataGridView1.BeginEdit(true);
                                }
                                break;
                            case "Descripcion":
                                Valor = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].Value) is DBNull ? "" : Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].Value);
                                if (Valor == "") ;
                                else
                                {
                                    Productos(@"select Codigo,Descripcion,Unidad,Fisico,Disponible from Vva_producto where activo = 1 and Descripcion like '%" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].Value) + "%'");
                                }
                                break;
                            case "Cantidad":
                                if (proceso.ExistenciaStock(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value), cantidadpedido, Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value)))
                                {
                                    var i = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioUnitario"].Value) - Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioNeto"].Value);
                                    dataGridView1.Rows[e.RowIndex].Cells["Total"].Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioNeto"].Value);
                                    dataGridView1.Rows[e.RowIndex].Cells["Descuento"].Value = i > 0 ? i * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) : 0;
                                    dataGridView1.Rows[e.RowIndex].Cells["Recargo"].Value = i < 0 ? Math.Abs(i) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) : 0;
                                    if (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value) > 0)
                                    {
                                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[7];
                                        dataGridView1.BeginEdit(true);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("stock insuficiente");
                                    dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["Cantidad"];
                                    dataGridView1.BeginEdit(true);
                                }

                                break;
                            case "PrecioNeto":
                                var j = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioUnitario"].Value) - Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioNeto"].Value);
                                dataGridView1.Rows[e.RowIndex].Cells["Total"].Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["PrecioNeto"].Value);
                                dataGridView1.Rows[e.RowIndex].Cells["Descuento"].Value = j > 0 ? j * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) : 0;
                                dataGridView1.Rows[e.RowIndex].Cells["Recargo"].Value = j < 0 ? Math.Abs(j) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cantidad"].Value) : 0;
                                calculartotal();
                                btnAgregar.Select();
                                break;
                        }
                        calculartotal();
                    }
                    catch { }
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
            txtcdVendedor.Select();
            Fecha = Convert.ToDateTime(dateEmision.EditValue).ToString("yyyyMMdd");
        }
        void Productos(string sql)
        {
            Maestro.frmProducto frmproducto = new Maestro.frmProducto();
            frmproducto.Ex = true;
            frmproducto.pasar += new Maestro.frmProducto.variables(camposproducto);
            proceso.consultar(sql, "Producto");
            frmproducto.gridControl1.DataSource = proceso.ds.Tables["Producto"];
            formato.Grilla(frmproducto.gridView1);
            frmproducto.StartPosition = FormStartPosition.CenterScreen;
            frmproducto.ShowDialog();
        }

        private void txtcdCLiente_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtcdVendedor.Text.Trim().Length > 0 && txtnmVendedor.Text.Trim().Length > 5)
            {
                MaestroCliente();
            }
            else
                MessageBox.Show("pedido no cuenta con datos de vendedor");
        }

        private void txtcdCLiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sql = btnFueraRuta.Checked == true ? Libreria.Constante.Cliente : Libreria.Constante.ClienteVendedor.Replace("@Fecha", Fecha).Replace("@Vendedor", txtcdVendedor.Text.Trim());
            string Where = btnFueraRuta.Checked == true ? " AND Codigo = '" + txtcdCLiente.Text.Trim() + "'" : " AND (Codigo = '" + txtcdCLiente.Text.Trim() + "')";
            if (e.KeyChar == (int)Keys.Enter)
                if (txtcdVendedor.Text.Trim().Length > 0 && txtnmVendedor.Text.Trim().Length > 5)
                    if (txtcdCLiente.Text.Length == 0)
                    {
                        MaestroCliente();
                    }
                    else if (proceso.ExistenciaCampo("Codigo", "Vva_Clientevendedor", "Codigo = '" + txtcdCLiente.Text.Trim() + "'"))
                    {
                        proceso.consultar(sql + Where, "Cl");
                        var Result = (from Cl in proceso.ds.Tables["Cl"].AsEnumerable()
                                      select Cl).FirstOrDefault();
                        if (Result != null)
                        {
                            txtnmCliente.Text = Result["Nombre"].ToString();
                            txtdocCliente.Text = Result["Documento"].ToString();
                            txtnmDireccion.Text = Result["Direccion"].ToString();
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
                        else
                        {
                            MessageBox.Show("Cliente no pertenece al vendedor");
                        }
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
            if (e.KeyChar == (int)Keys.Enter)
                using (var CTX = new LiderEntities())
                {
                    if (txtcdVendedor.Text.Length > 0 && txtnmVendedor.Text.Length > 0)
                    {
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
                    }
                    else
                        MessageBox.Show("pedido no cuenta con datos de vendedor");
                }
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
            Maestro.frmTipoDocumento frmtipodocumento = new Maestro.frmTipoDocumento();
            frmtipodocumento.pasar += new Maestro.frmTipoDocumento.campos(campostipodocumento);
            proceso.consultar("select Descripcion from doctipo", "tipodocumento");
            frmtipodocumento.gridControl1.DataSource = proceso.ds.Tables["tipodocumento"];
            formato.Grilla(frmtipodocumento.gridView1);
            frmtipodocumento.ShowDialog();
        }

        public void calculartotal()
        {
            var subtotal = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>() select (Convert.ToDecimal(detalle.Cells["Cantidad"].Value) * Convert.ToDecimal(detalle.Cells["PrecioUnitario"].Value))).Sum();
            var descuento = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>() select (Convert.ToDecimal(detalle.Cells["Descuento"].Value))).Sum();
            var recargo = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>() select (Convert.ToDecimal(detalle.Cells["Recargo"].Value))).Sum();
            var afecto = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>()
                          where Convert.ToBoolean(detalle.Cells["Afecto"].Value) == true
                          select ((Convert.ToDecimal(detalle.Cells["Total"].Value)) / (decimal)1.18)).Sum();

            var inafecto = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>()
                            where Convert.ToBoolean(detalle.Cells["Afecto"].Value) == false
                            select Convert.ToDecimal(detalle.Cells["Total"].Value)).Sum();

            var impuesto = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>()
                            where Convert.ToBoolean(detalle.Cells["Afecto"].Value) == true
                            select (Convert.ToDecimal(detalle.Cells["Total"].Value) - (Convert.ToDecimal(detalle.Cells["Total"].Value) / (decimal)1.18))).Sum();

            var total = (from detalle in dataGridView1.Rows.Cast<DataGridViewRow>() select (Convert.ToDecimal(detalle.Cells["Total"].Value))).Sum();

            txtValorSubtotal.Text = subtotal.ToString("N2");
            txtValorDescuento.Text = descuento.ToString("N2");
            txtValorRecargo.Text = recargo.ToString("N2");
            txtValorAfecto.Text = afecto.ToString("N2");
            txtValorInafecto.Text = inafecto.ToString("N2");
            txtValorImpuesto.Text = impuesto.ToString("N2");
            txtValorImporteTotal.Text = total.ToString("N2");
        }
    }
}