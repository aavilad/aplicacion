using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xtraForm.Modulos.Inventario
{
    public partial class frmMarca : DevExpress.XtraEditors.XtraForm
    {
        public string tabla = "Marca";
        public frmMarca()
        {
            InitializeComponent();
        }

        void Refrescar()
        {
            var proceso = new Libreria.Proceso();
            var lista_ = new List<string>();
            proceso.consultar("select campo, condicion, valor,[union] from filtro where tabla = '" + tabla + "'", tabla);
            foreach (DataRow DR_1 in proceso.ds.Tables[tabla].Rows)
                lista_.Add(tabla + "." + "[" + DR_1[0].ToString() + "]" + DR_1[1].ToString() + "'" + DR_1[2].ToString() + "'" + DR_1[3].ToString());
            string cadena = string.Join(" ", lista_.ToArray());
            condicion(cadena);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void filtrarToolStripMenuItem_Click(object sender, EventArgs e)
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
                k.DataSource = Context.Database.SqlQuery<string>(Libreria.Constante.Mapa_Table + "'" + tabla + "'").ToList();
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
            var proceso = new Libreria.Proceso();
            try
            {
                if (cadena.Length == 0)
                {
                    proceso.consultar(Libreria.Constante.Marcas, tabla);
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
                    proceso.consultar(Libreria.Constante.Marcas + " where " + cadena, tabla);
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
            try
            {
                using (var Context = new Model.LiderAppEntities())
                {
                    var frmmarca = new Elementos.frmMarca();
                    frmmarca.pasar += new Elementos.frmMarca.Variables(Campos);
                    string Codigo_ = Convert.ToString(gridView1.GetFocusedRowCellValue("Codigo")).Trim();
                    string Descripcion_ = Convert.ToString(Context.MARCA.Where(x => x.Marca1 == Codigo_).Select(p => p.Descripcion).FirstOrDefault());
                    string Abreviacion_ = Convert.ToString(Context.MARCA.Where(x => x.Marca1 == Codigo_).Select(p => p.Descorta).FirstOrDefault());
                    string Orden_ = Convert.ToString(Context.MARCA.Where(x => x.Marca1 == Codigo_).Select(p => p.Orden).FirstOrDefault());
                    string Proveedor_ = Convert.ToString(Context.MARCA.Where(x => x.Marca1 == Codigo_).Select(p => p.Proveedor).FirstOrDefault());
                    string Linea_ = Convert.ToString(Context.MARCA.Where(x => x.Marca1 == Codigo_).Select(p => p.Linea).FirstOrDefault());
                    frmmarca.txtMarcaCodigo.Text = Codigo_;
                    frmmarca.txtMarcaDescripcion.Text = Descripcion_;
                    frmmarca.txtMarcaAbreviacion.Text = Abreviacion_;
                    frmmarca.txtMarcaProveedor.EditValue = Proveedor_;
                    frmmarca.txtMarcaLinea.EditValue = Linea_;
                    frmmarca.txtMarcaOrden.Text = Orden_;
                    frmmarca.StartPosition = FormStartPosition.CenterScreen;
                    frmmarca.Show();
                }

            }
            catch (SqlException t)
            {
                MessageBox.Show(t.Message);
            }

        }
        void Campos(string MarcaCodigo, string MarcaOrden, string MarcaProveedor, string MarcaLinea, string MarcaDescripcion, string MarcaAbreviacion)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                Model.MARCA Mca = new Model.MARCA { Marca1 = MarcaCodigo };
                Context.MARCA.Attach(Mca);
                Mca.Linea = MarcaLinea;
                Mca.Proveedor = MarcaProveedor;
                Mca.Orden = MarcaOrden;
                Mca.Descorta = MarcaAbreviacion;
                Mca.Descripcion = MarcaDescripcion;
                Context.SaveChanges();
            }
        }
    }
}