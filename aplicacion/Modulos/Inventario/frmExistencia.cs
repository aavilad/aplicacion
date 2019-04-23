using DevExpress.Data.Browsing;
using DevExpress.Entity.Model.Metadata;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Inventario
{
    public partial class frmExistencia : DevExpress.XtraEditors.XtraForm
    {
        public string tabla = "Vva_Producto";
        Libreria.Proceso proceso = new Libreria.Proceso();
        public frmExistencia()
        {
            InitializeComponent();
        }

        private void filtarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                Filtros.frmFiltros filtro = new Filtros.frmFiltros();
                DataGridViewComboBoxColumn i = filtro.dataGridView1.Columns["Index1"] as DataGridViewComboBoxColumn;
                i.DataSource = Context.FiltroConfiguracion.Where(a => a.Tipo == "CONDICION").ToArray();
                i.DisplayMember = "Descripcion";
                i.ValueMember = "Codigo";
                DataGridViewComboBoxColumn j = filtro.dataGridView1.Columns["Index3"] as DataGridViewComboBoxColumn;
                j.DataSource = Context.FiltroConfiguracion.Where(a => a.Tipo == "OPERADOR").ToList();
                j.DisplayMember = "Descripcion";
                j.ValueMember = "Codigo";
                DataGridViewComboBoxColumn k = filtro.dataGridView1.Columns["Index0"] as DataGridViewComboBoxColumn;
                k.DataSource = Context.Database.SqlQuery<string>(Libreria.Constante.Mapa_View + "'" + tabla + "'").ToList();
                filtro.pasar += new Filtros.frmFiltros.variables(condicion);
                filtro.StartPosition = FormStartPosition.CenterScreen;
                foreach (var fila in Context.Filtro.Where(w => w.tabla.Equals(tabla)).ToList())
                {
                    filtro.dataGridView1.Rows.Add(fila.campo, fila.condicion, fila.valor, fila.union);
                }
                filtro.entidad = tabla;
                filtro.ShowDialog();
            }
        }
        void condicion(string cadena)
        {
            try
            {
                if (cadena.Length == 0)
                {
                    proceso.consultar(Libreria.Constante.Existencias, tabla);
                    gridControl1.DataSource = proceso.ds.Tables[tabla];
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.OptionsView.ShowFooter = true;
                    gridView1.FooterPanelHeight = -2;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.GroupRowHeight = 1;
                    gridView1.RowHeight = 1;
                    gridView1.Appearance.Row.FontSizeDelta = 0;
                    gridView1.BestFitColumns();
                }
                else
                {

                    proceso.consultar(Libreria.Constante.Existencias + " where " + cadena, tabla);
                    gridControl1.DataSource = proceso.ds.Tables[tabla];
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.OptionsView.ShowFooter = true;
                    gridView1.GroupRowHeight = 1;
                    gridView1.RowHeight = 1;
                    gridView1.Appearance.Row.FontSizeDelta = 0;
                    gridView1.BestFitColumns();
                }
            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
                gridControl1.DataSource = null;
                gridControl1.Refresh();
            }

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                Elementos.frmProducto frmproducto = new Elementos.frmProducto();
                string CodigoProducto = gridView1.GetFocusedRowCellValue("Codigo").ToString();
                string ProductoProveedor = Context.Vva_Producto.Where(x=>x.Codigo.Equals(CodigoProducto)).Select(y=>y.IDProv).FirstOrDefault();
                string CodigoFabrica = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.sku).FirstOrDefault();
                string CodigoEan = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.EAN).FirstOrDefault();
                string productoDescripcion = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Descripcion).FirstOrDefault();
                string ProductoLinea = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.IDLinea).FirstOrDefault();
                string ProductoMarca = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.IDMarca).FirstOrDefault();
                string ProductoGrupo = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.IDGrupo).FirstOrDefault();
                string ProductoClase = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.IDClase).FirstOrDefault();
                string ProductoCategoria = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.IDCategoria).FirstOrDefault();
                bool ProductoVenta = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.ArticuloVenta).FirstOrDefault();
                bool ProductoCompra = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.ArticuloCompra).FirstOrDefault();
                bool ProductoCombo = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.ArticuloCombo).FirstOrDefault();
                bool ProductoUnilever = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Dms).FirstOrDefault();
                bool ProductoWeb = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Web).FirstOrDefault();
                bool ProductoAfecto = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Afecto).FirstOrDefault();
                bool ProductoActivo = Context.Vva_Producto.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Activo).FirstOrDefault();
            }

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Elementos.frmProducto frmproducto = new Elementos.frmProducto();
            frmproducto.Show();
        }
    }
}