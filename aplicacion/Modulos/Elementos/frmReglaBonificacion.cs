using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmReglaBonificacion : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variable(int PKID, string Mecanica, int TipoMecanica, string CodigoObsequio, decimal CantidadMinima, int CantidadMaxima, int CantidadObsequio, int MaximoPorCliente,
            decimal Stock, bool Exclusion, int PkidExclusion, string CodigoVenta, string Proveedor, string Desde, string Hasta, bool Activo, int IDAsociado, DataGridView dgv);
        public event variable pasar;
        Libreria.Rutina proceso = new Libreria.Rutina();
        Libreria.Bonificacion bonificacion = new Libreria.Bonificacion();
        public bool existe;
        public frmReglaBonificacion() => InitializeComponent();
        void camposbonificacion(int pkid, string codigo, string Descripcion)
        {
            bonificacion.TipoMecanica = pkid;
            IDBonificacion.Text = codigo;
            nmBonificacion.Text = Descripcion;
        }
        void camposproveedor(string codigo, string descripcion)
        {
            IDProveedor.Text = codigo;
            NmProveedor.Text = descripcion;
        }
        void camposproductobsequio(string codigo, string descripcion, string unidad)
        {
            IDObsequio.Text = codigo;
            NmObsequio.Text = descripcion;
        }
        void camposproductoexclusion(string PKID, string Mecanica)
        {
            IDExclusion.Text = PKID;
            NmExclusion.Text = Mecanica;
        }
        void camposproductocanje(string codigo, string descripcion, string unidad)
        {
            IDCanje.Text = codigo;
            NmCanje.Text = descripcion;
        }
        void camposmarca(string codigo, string descripcion)
        {
            dataGridView1.Rows.Add(codigo, descripcion);
        }
        void camposlinea(string codigo, string descripcion)
        {
            dataGridView1.Rows.Add(codigo, descripcion);
        }
        void camposgrupo(string codigo, string descripcion)
        {
            dataGridView1.Rows.Add(codigo, descripcion);
        }
        void camposproducto(string codigo, string descripcion, string unidad)
        {
            dataGridView1.Rows.Add(codigo, descripcion);
        }
        private void IDBonificacion_EditValueChanged(object sender, EventArgs e)
        {
            if (bonificacion.TipoMecanica == 1)
                CantidadMaxima.Enabled = false;
            if (bonificacion.TipoMecanica == 2)
                CantidadMaxima.Enabled = true;
            if (bonificacion.TipoMecanica == 3)
                CantidadMaxima.Enabled = false;
            if (bonificacion.TipoMecanica == 4)
                CantidadMaxima.Enabled = true;
        }

        private void IDBonificacion_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Maestro.frmBonificacion msbonificacion = new Maestro.frmBonificacion();
            proceso.consultar("select Pkid,Codigo,Descripcion from tipobonificacion where activo = 1", "tipobonificacion");
            msbonificacion.gridControl1.DataSource = proceso.ds.Tables["tipobonificacion"];
            msbonificacion.gridView1.OptionsView.ShowGroupPanel = false;
            msbonificacion.gridView1.OptionsView.ShowIndicator = false;
            msbonificacion.gridView1.Columns["Pkid"].Visible = false;
            msbonificacion.gridView1.BestFitColumns();
            msbonificacion.pasar += new Maestro.frmBonificacion.variables(camposbonificacion);
            msbonificacion.StartPosition = FormStartPosition.CenterScreen;
            msbonificacion.ShowDialog();
        }

        private void IDBonificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                if (IDBonificacion.Text.Length != 0)
                    if (proceso.ExistenciaCampo("pkid", "tipobonificacion", "codigo = '" + IDBonificacion.Text.Trim() + "'"))
                    {
                        nmBonificacion.Text = proceso.ConsultarCadena("Descripcion", "tipobonificacion", "codigo = '" + IDBonificacion.Text.Trim() + "'");
                        bonificacion.TipoMecanica = proceso.ConsultarEntero("PKID", "tipobonificacion", "codigo = '" + IDBonificacion.Text.Trim() + "'");
                    }
                    else
                        MessageBox.Show("Tipo de bonificacion no existe");
                else
                {
                    Maestro.frmBonificacion msbonificacion = new Maestro.frmBonificacion();
                    proceso.consultar("select Pkid,Codigo,Descripcion from tipobonificacion where activo = 1", "tipobonificacion");
                    msbonificacion.gridControl1.DataSource = proceso.ds.Tables["tipobonificacion"];
                    msbonificacion.gridView1.OptionsView.ShowGroupPanel = false;
                    msbonificacion.gridView1.OptionsView.ShowIndicator = false;
                    msbonificacion.gridView1.Columns["Pkid"].Visible = false;
                    msbonificacion.gridView1.BestFitColumns();
                    msbonificacion.pasar += new Maestro.frmBonificacion.variables(camposbonificacion);
                    msbonificacion.StartPosition = FormStartPosition.CenterScreen;
                    msbonificacion.ShowDialog();
                }
        }

        private void IDProveedor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Maestro.frmProveedor msproveedor = new Maestro.frmProveedor();
            proceso.consultar("select Proveedor, razonsocial as Nombre,ruc,direccion from proveedor", "proveedor");
            msproveedor.gridControl1.DataSource = proceso.ds.Tables["proveedor"];
            msproveedor.gridView1.OptionsView.ShowGroupPanel = false;
            msproveedor.gridView1.BestFitColumns();
            msproveedor.pasar += new Maestro.frmProveedor.variables(camposproveedor);
            msproveedor.StartPosition = FormStartPosition.CenterScreen;
            msproveedor.ShowDialog();
        }

        private void IDProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                if (IDProveedor.Text.Length != 0)
                    if (proceso.ExistenciaCampo("proveedor", "Proveedor", "proveedor = '" + IDProveedor.Text + "'"))
                        NmProveedor.Text = proceso.ConsultarCadena("razonsocial", "proveedor", "Proveedor = '" + IDProveedor.Text + "'");
                    else
                        MessageBox.Show("codigo no existe");
                else
                {
                    Maestro.frmProveedor msproveedor = new Maestro.frmProveedor();
                    proceso.consultar("select Proveedor, razonsocial as Nombre,ruc,direccion from proveedor", "proveedor");
                    msproveedor.gridControl1.DataSource = proceso.ds.Tables["proveedor"];
                    msproveedor.gridView1.OptionsView.ShowGroupPanel = false;
                    msproveedor.gridView1.BestFitColumns();
                    msproveedor.pasar += new Maestro.frmProveedor.variables(camposproveedor);
                    msproveedor.StartPosition = FormStartPosition.CenterScreen;
                    msproveedor.ShowDialog();
                }
        }

        private void IDObsequio_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Maestro.frmProducto msproducto = new Maestro.frmProducto();
            msproducto.gridView1.BestFitColumns();
            msproducto.pasar += new Maestro.frmProducto.variables(camposproductobsequio);
            msproducto.StartPosition = FormStartPosition.CenterScreen;
            msproducto.ShowDialog();
        }

        private void IDObsequio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                if (IDObsequio.Text.Length != 0)
                    if (proceso.ExistenciaCampo("Codigo", "Vva_producto", "Codigo = '" + IDObsequio.Text + "'"))
                        NmObsequio.Text = proceso.ConsultarCadena("descripcion", "Vva_producto", "Codigo = '" + IDObsequio.Text + "'");
                    else
                        MessageBox.Show("codigo no existe");
                else
                {
                    Maestro.frmProducto msproducto = new Maestro.frmProducto();
                    proceso.consultar("select Codigo,Descripcion,Unidad,Fisico,Disponible from Vva_producto where activo = 1", "Producto");
                    msproducto.gridControl1.DataSource = proceso.ds.Tables["Producto"];
                    msproducto.gridView1.OptionsView.ShowGroupPanel = false;
                    msproducto.gridView1.OptionsView.ShowIndicator = false;
                    msproducto.gridView1.BestFitColumns();
                    msproducto.pasar += new Maestro.frmProducto.variables(camposproductobsequio);
                    msproducto.StartPosition = FormStartPosition.CenterScreen;
                    msproducto.ShowDialog();
                }
        }

        private void IDExclusion_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Maestro.frmItemBonificacion msItemBonificacion = new Maestro.frmItemBonificacion();
            proceso.consultar(
            @"SELECT        
            Bonificacion.PKID, Bonificacion.Mecanica, Bonificacion.TipoMecanica, Bonificacion.cdProductoRegalo,
            PROVEEDOR.RazonSocial AS Proveedor
            FROM
            Bonificacion INNER JOIN PROVEEDOR ON Bonificacion.IDProveedor = PROVEEDOR.Proveedor
            where activo = 1 and '" + Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd") + "' >= Desde and '" + Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd") + "' < Hasta", "Bonificacion");
            msItemBonificacion.gridControl1.DataSource = proceso.ds.Tables["Bonificacion"];
            msItemBonificacion.gridView1.OptionsView.ShowGroupPanel = false;
            msItemBonificacion.gridView1.OptionsBehavior.ReadOnly = true;
            msItemBonificacion.gridView1.OptionsBehavior.Editable = false;
            msItemBonificacion.gridView1.OptionsView.ColumnAutoWidth = false;
            msItemBonificacion.gridView1.Columns[0].Visible = false;
            msItemBonificacion.gridView1.BestFitColumns();
            msItemBonificacion.gridView1.Columns["Proveedor"].GroupIndex = 0;
            msItemBonificacion.gridView1.Columns["TipoMecanica"].GroupIndex = 1;
            msItemBonificacion.gridView1.GroupRowHeight = 1;
            msItemBonificacion.gridView1.RowHeight = 1;
            msItemBonificacion.gridView1.Appearance.Row.FontSizeDelta = 0;
            msItemBonificacion.pasar += new Maestro.frmItemBonificacion.variables(camposproductoexclusion);
            msItemBonificacion.StartPosition = FormStartPosition.CenterScreen;
            msItemBonificacion.ShowDialog();
        }

        private void IDCanje_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Maestro.frmProducto msproducto = new Maestro.frmProducto();
            msproducto.gridView1.BestFitColumns();
            msproducto.pasar += new Maestro.frmProducto.variables(camposproductocanje);
            msproducto.StartPosition = FormStartPosition.CenterScreen;
            msproducto.ShowDialog();
        }

        private void IDCanje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                if (IDCanje.Text.Length != 0)
                    if (proceso.ExistenciaCampo("Codigo", "Vva_producto", "Codigo = '" + IDCanje.Text + "'"))
                        NmCanje.Text = proceso.ConsultarCadena("descripcion", "Vva_producto", "Codigo = '" + IDCanje.Text + "'");
                    else
                        MessageBox.Show("codigo no existe");
                else
                {
                    Maestro.frmProducto msproducto = new Maestro.frmProducto();
                    proceso.consultar("select Codigo,Descripcion,Unidad,Fisico,Disponible from Vva_producto where activo = 1", "Producto");
                    msproducto.gridControl1.DataSource = proceso.ds.Tables["Producto"];
                    msproducto.gridView1.OptionsView.ShowGroupPanel = false;
                    msproducto.gridView1.OptionsView.ShowIndicator = false;
                    msproducto.gridView1.BestFitColumns();
                    msproducto.pasar += new Maestro.frmProducto.variables(camposproductocanje);
                    msproducto.StartPosition = FormStartPosition.CenterScreen;
                    msproducto.ShowDialog();
                }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            switch (BoxTipoAsociado.EditValue)
            {
                case 1:
                    Maestro.frmMarca msmarca = new Maestro.frmMarca();
                    proceso.consultar("select Marca,Descripcion from Marca", "Marca");
                    msmarca.gridControl1.DataSource = proceso.ds.Tables["Marca"];
                    msmarca.gridView1.OptionsView.ShowGroupPanel = false;
                    msmarca.gridView1.BestFitColumns();
                    msmarca.pasar += new Maestro.frmMarca.variables(camposmarca);
                    msmarca.ShowDialog();
                    break;
                case 2:
                    Maestro.frmLinea mslinea = new Maestro.frmLinea();
                    proceso.consultar("select Linea,Descripcion from Linea", "Linea");
                    mslinea.gridControl1.DataSource = proceso.ds.Tables["Linea"];
                    mslinea.gridView1.OptionsView.ShowGroupPanel = false;
                    mslinea.gridView1.BestFitColumns();
                    mslinea.pasar += new Maestro.frmLinea.variables(camposlinea);
                    mslinea.ShowDialog();
                    break;
                case 3:
                    Maestro.frmGrupo msgroup = new Maestro.frmGrupo();
                    proceso.consultar("select grupo,descrip from grupo", "Grupo");
                    msgroup.gridControl1.DataSource = proceso.ds.Tables["Grupo"];
                    msgroup.gridView1.OptionsView.ShowGroupPanel = false;
                    msgroup.gridView1.BestFitColumns();
                    msgroup.pasar += new Maestro.frmGrupo.variables(camposgrupo);
                    msgroup.ShowDialog();
                    break;
                case 4:
                    Maestro.frmProducto msproducto = new Maestro.frmProducto();
                    msproducto.gridView1.BestFitColumns();
                    msproducto.pasar += new Maestro.frmProducto.variables(camposproducto);
                    msproducto.StartPosition = FormStartPosition.CenterScreen;
                    msproducto.ShowDialog();
                    break;
            }
        }

        private void cdProducto_CheckedChanged(object sender, EventArgs e) => dataGridView1.Rows.Clear();

        private void cdLinea_CheckedChanged(object sender, EventArgs e) => dataGridView1.Rows.Clear();

        private void cdGrupo_CheckedChanged(object sender, EventArgs e) => dataGridView1.Rows.Clear();

        private void cdMarca_CheckedChanged(object sender, EventArgs e) => dataGridView1.Rows.Clear();

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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Eliminar fila", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                foreach (DataGridViewRow rows in dataGridView1.SelectedRows)
                    dataGridView1.Rows.RemoveAt(rows.Index);
        }

        private void simpleButton1_Click(object sender, EventArgs e) { if (proceso.MensageError("Cancelar") == DialogResult.Yes) this.Close(); }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                int Id = Convert.ToInt32(IDControl.Text);
                string Mecanica = DetalleMecanica.Text.Trim();
                int TipoMecanica = CTX.TipoBonificacions.Where(w => w.Codigo == IDBonificacion.Text.Trim()).Select(s => s.PKID).FirstOrDefault();
                string CodigoObsequio = IDObsequio.Text.Trim();
                decimal CantMinima = CantidadMinima.Value;
                int CantMaxima = Convert.ToInt32(CantidadMaxima.Value);
                int CantObsequio = Convert.ToInt32(CantidadRegalo.Value);
                int MaximoPorCliente = Convert.ToInt32(CantidadMaximaCliente.Value);
                int Stock = Convert.ToInt32(StockPromocional.Value);
                bool Excl = Exclusion.Checked;
                int IdExcl = Exclusion.Checked is false ? 0 : Convert.ToInt32(IDExclusion.EditValue);
                string CodigoVenta = IDCanje.Text.Trim();
                string Proveedor = IDProveedor.Text.Trim();
                string Desde = fechaDesde.DateTime.ToString("dd/MM/yyyy");
                string Hasta = fechaHasta.DateTime.ToString("dd/MM/yyyy");
                bool Activo = Estado.Checked;
                int IdAsociado = Convert.ToInt32(BoxTipoAsociado.EditValue);
                pasar(Id, Mecanica, TipoMecanica, CodigoObsequio, CantMinima, CantMaxima, CantObsequio, MaximoPorCliente, Stock, Excl, IdExcl, CodigoVenta, Proveedor, Desde, Hasta, Activo, IdAsociado, dataGridView1);
                this.Close();
            }
        }

        private void frmReglaBonificacion_KeyPress(object sender, KeyPressEventArgs e) { if (e.KeyChar == (int)Keys.Escape) simpleButton1_Click(sender, e); }

        private void FrmReglaBonificacion_Load(object sender, EventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                BoxTipoAsociado.Properties.DisplayMember = "Codigo";
                BoxTipoAsociado.Properties.ValueMember = "PKID";
                BoxTipoAsociado.Properties.DataSource = CTX.TipoAsociadoes.ToList();
                BoxTipoAsociado.Properties.Columns.Add(new LookUpColumnInfo("Codigo", "Tipo Asociado"));
            }
        }

        private void CheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            switch (Exclusion.Checked)
            {
                case true:
                    IDExclusion.Enabled = true;
                    NmExclusion.Enabled = true;
                    break;
                case false:
                    IDExclusion.Enabled = false;
                    NmExclusion.Enabled = false;
                    break;
            }
        }

        private void BoxTipoAsociado_EditValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}