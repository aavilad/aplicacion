using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmComprobantes : DevExpress.XtraEditors.XtraForm
    {
        string tabla = "Vva_Cp";
        Libreria.Entidad entidad = new Libreria.Entidad();
        Libreria.Proceso proceso = new Libreria.Proceso();
        Libreria.Maestra maestro = new Libreria.Maestra();
        public frmComprobantes()
        {
            InitializeComponent();
        }

        void Refrescar()
        {
            proceso.consultar("select campo, condicion, valor,[union] from filtro where tabla = '" + tabla + "'", tabla);
            List<string> lista_ = new List<string>();
            foreach (DataRow DR_1 in proceso.ds.Tables[tabla].Rows)
                lista_.Add(tabla + "." + "[" + DR_1[0].ToString() + "]" + DR_1[1].ToString() + "'" + DR_1[2].ToString() + "'" + DR_1[3].ToString());
            string cadena = string.Join(" ", lista_.ToArray());
            condicion(cadena);
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
                k.DataSource = Context.Database.SqlQuery<string>(Libreria.Constante.Mapa_View + "'Vva_Cp'").ToList();
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
            using (var Context = new Model.LiderAppEntities())
            {
                string Query = Convert.ToString(Context.VistaAdministrativa.Where(x => x.IDModulo == 3).Select(a => a.Vista.Trim()).FirstOrDefault());
                if (cadena.Length == 0)
                {
                    proceso.consultar(Query, tabla);
                    gridControl1.DataSource = proceso.ds.Tables[tabla];
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.OptionsView.ShowFooter = true;
                    gridView1.FooterPanelHeight = -2;
                    gridView1.Columns["Valor Venta"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["afecto"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["inafecto"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["igv"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["Valor Total"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["Credito"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.GroupRowHeight = 1;
                    gridView1.RowHeight = 1;
                    gridView1.Appearance.Row.FontSizeDelta = 0;
                    gridView1.BestFitColumns();
                }
                else
                {
                    try
                    {
                        proceso.consultar(Query + " HAVING " + cadena, tabla);
                        gridControl1.DataSource = proceso.ds.Tables[tabla];
                        gridView1.OptionsView.ColumnAutoWidth = false;
                        gridView1.OptionsBehavior.Editable = false;
                        gridView1.OptionsBehavior.ReadOnly = true;
                        gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                        gridView1.OptionsView.ShowGroupPanel = false;
                        gridView1.OptionsView.ShowFooter = true;
                        gridView1.Columns["Valor Venta"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView1.Columns["afecto"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView1.Columns["inafecto"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView1.Columns["igv"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView1.Columns["Valor Total"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView1.Columns["Credito"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                        gridView1.GroupRowHeight = 1;
                        gridView1.RowHeight = 1;
                        gridView1.Appearance.Row.FontSizeDelta = 0;
                        gridView1.BestFitColumns();
                    }
                    catch
                    {
                        gridControl1.DataSource = null;
                        gridControl1.Refresh();
                    }
                }
            }

        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entidad.documento = gridView1.GetFocusedRowCellValue("Num Documento").ToString();
            entidad.tipodocumento = gridView1.GetFocusedRowCellValue("Tipo Docum").ToString();
            if (proceso.ConsultarCadena("estado", "documento", "Documento = '" + entidad.documento + "' and tipodoc = '" + entidad.tipodocumento + "'") != "A")
            {
                if (proceso.MensagePregunta("Desea Anular documento : " + entidad.documento) == DialogResult.Yes)
                {
                    if (proceso.actualizar("documento", "Estado = 'A'", "documento = '" + entidad.documento + "' and tipodoc = '" + entidad.tipodocumento + "'"))
                    {
                        MessageBox.Show("documento : " + entidad.documento + " se ha anulado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Documento se encuentra anulado");
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Elementos.frmComprobante frmcomprobante = new frmComprobante();
            frmcomprobante.StartPosition = FormStartPosition.CenterScreen;
            frmcomprobante.Show();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}