using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xtraForm.Modulos.Ventas
{
    public partial class frmListaPrecio : DevExpress.XtraEditors.XtraForm
    {
        string tabla = "Vva_PrecioEscala";
        public frmListaPrecio()
        {
            InitializeComponent();
        }

        void condicion(string cadena)
        {
            var proceso = new Libreria.Proceso();
            try
            {
                if (cadena.Length == 0)
                {
                    proceso.consultar(Libreria.Constante.ProductoEscala, tabla);
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
                    proceso.consultar(Libreria.Constante.ProductoEscala + " where " + cadena, tabla);
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

        void Refrescar()
        {
            var lista_ = new List<string>();
            using (var Context = new Model.LiderAppEntities())
            {
                var Filtro = Context.Filtro.Where(x => x.tabla == "").Select(p => p).ToList();
                foreach (var i in Filtro)
                {
                    lista_.Add(tabla + "." + "[" + i.campo + "]" + i.condicion + "'" + i.valor + "'" + i.union);
                }
                string Cadena = string.Join(" ", lista_.ToArray());
                condicion(Cadena);
            }

            //proceso.consultar("select campo, condicion, valor,[union] from filtro where tabla = '" + tabla + "'", tabla);
            //foreach (DataRow DR_1 in proceso.ds.Tables[tabla].Rows)
            //    lista_.Add(tabla + "." + "[" + DR_1[0].ToString() + "]" + DR_1[1].ToString() + "'" + DR_1[2].ToString() + "'" + DR_1[3].ToString());
            //string cadena = string.Join(" ", lista_.ToArray());
            //condicion(cadena);
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

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "")
            {

            }
        }

        private void TxtCodigoProducto_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Codigo = Convert.ToString(TxtCodigoProducto.EditValue);
            using (var Context = new Model.LiderAppEntities())
            {
                var ProductoEscala = (from p in Context.Vva_Producto.AsEnumerable().Where(x => x.Codigo.StartsWith(Codigo))
                                      from pu in Context.PlantillaUnidad.AsEnumerable().Where(x => x.PKID == p.IDUnidad).DefaultIfEmpty()
                                      select new
                                      {
                                          Codigo = p.Codigo.Trim(),
                                          Descripcion = p.Descripcion.Trim(),
                                          UnidadAnterior = p.Unidad.Trim(),
                                          Unidad = pu == null ? "" : pu.Abreviacion.Trim()
                                      }).ToList();
                gridControl1.DataSource = ProductoEscala;
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.OptionsView.ShowGroupPanel = false;
                gridView1.BestFitColumns();
                gridView1.OptionsView.ShowIndicator = false;
                gridView1.OptionsBehavior.ReadOnly = true;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            string Codigo = Convert.ToString(gridView1.GetFocusedRowCellValue("Codigo"));
            using (var Context = new Model.LiderAppEntities())
            {
                var Costo = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.Costo).FirstOrDefault();
                var P1 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.C_MENOR).FirstOrDefault();
                var P2 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.C_MAYOR).FirstOrDefault();
                var P3 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.CR_MENOR).FirstOrDefault();
                var P4 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.CR_MENOR).FirstOrDefault();
                var P5 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL05).FirstOrDefault();
                var P6 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL06).FirstOrDefault();
                var P7 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL07).FirstOrDefault();
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(Costo, P1, P2, P3, P4, P5, P6, P7);
            }
        }
    }
}