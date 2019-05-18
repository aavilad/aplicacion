using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Configuracion
{
    public partial class frmTipoCp : DevExpress.XtraEditors.XtraForm
    {
        public string NModulo;
        string entidad = "DOCTIPO";
        public frmTipoCp()
        {
            InitializeComponent();
            Refrescar();
        }

        void condicion(string cadena)
        {
            using (var Context = new LiderEntities())
            {
                var proceso = new Libreria.Proceso();
                string Query = Convert.ToString(Context.VistaAdministrativas.Where(x => x.IDModulo == (Context.Moduloes.Where(a => a.Nombre == NModulo).Select(b => b.PKID)).FirstOrDefault()).Select(a => a.Vista.Trim()).FirstOrDefault());
                if (cadena.Length == 0)
                {
                    proceso.consultar(Query, entidad);
                    gridControl1.DataSource = null;
                    gridView1.Columns.Clear();
                    gridControl1.DataSource = proceso.ds.Tables[entidad];
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.Columns[0].Visible = false;
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
                    try
                    {
                        gridControl1.DataSource = null;
                        gridView1.Columns.Clear();
                        proceso.consultar(Query + " where " + cadena, entidad);
                        gridControl1.DataSource = proceso.ds.Tables[entidad];
                        gridView1.OptionsView.ColumnAutoWidth = false;
                        gridView1.Columns[0].Visible = false;
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
                    catch
                    {
                        gridControl1.DataSource = null;
                        gridControl1.Refresh();
                    }
                }
            }

        }

        void Refrescar()
        {
            var proceso = new Libreria.Proceso();
            proceso.consultar("select campo, condicion, valor,[union] from filtro where tabla = '" + entidad + "'", entidad);
            List<string> lista_ = new List<string>();
            foreach (DataRow DR_1 in proceso.ds.Tables[entidad].Rows)
                lista_.Add(entidad + "." + "[" + DR_1[0].ToString() + "]" + DR_1[1].ToString() + "'" + DR_1[2].ToString() + "'" + DR_1[3].ToString());
            string cadena = string.Join(" ", lista_.ToArray());
            condicion(cadena);
        }

        private void FILTRO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var Context = new LiderEntities())
            {

                Filtros.frmFiltros filtro = new Filtros.frmFiltros();
                DataGridViewComboBoxColumn i = filtro.dataGridView1.Columns["Index1"] as DataGridViewComboBoxColumn;
                i.DataSource = Context.FiltroConfiguracions.Where(a => a.Tipo == "CONDICION").ToArray();
                i.DisplayMember = "Descripcion";
                i.ValueMember = "Codigo";
                DataGridViewComboBoxColumn j = filtro.dataGridView1.Columns["Index3"] as DataGridViewComboBoxColumn;
                j.DataSource = Context.FiltroConfiguracions.Where(a => a.Tipo == "OPERADOR").ToList();
                j.DisplayMember = "Descripcion";
                j.ValueMember = "Codigo";
                DataGridViewComboBoxColumn k = filtro.dataGridView1.Columns["Index0"] as DataGridViewComboBoxColumn;
                k.DataSource = Context.Database.SqlQuery<string>(Libreria.Constante.Mapa_Table + "'" + entidad + "'").ToList();
                filtro.pasar += new Filtros.frmFiltros.variables(condicion);
                filtro.StartPosition = FormStartPosition.CenterScreen;
                foreach (var fila in Context.Filtroes.Where(w => w.tabla.Equals(entidad)).ToList())
                {
                    filtro.dataGridView1.Rows.Add(fila.campo, fila.condicion, fila.valor, fila.union);
                }
                filtro.entidad = entidad;
                filtro.ShowDialog();
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu1.ShowPopup(gridControl1.PointToScreen(e.Point));
        }

        private void MODIFICAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount == 1)
            {
                int ID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("pkid"));
                using (var CTX = new LiderEntities())
                {
                    var _Result = CTX.DOCTIPOes.Where(x => x.PKID == ID).ToList();
                    var formulario = new Elementos.frmTipoCp();
                    formulario.pasar += new Elementos.frmTipoCp.valores(VALORES);
                    formulario.IDF.Text = ID.ToString();
                    formulario.CODIGO.EditValue = _Result.Select(x => x.DocTipo1).FirstOrDefault();
                    formulario.DESCRIPCION.EditValue = _Result.Select(x => x.Descripcion).FirstOrDefault();
                    formulario.SERIE.EditValue = _Result.Select(x => x.Serie).FirstOrDefault();
                    formulario.NUMERO.EditValue = _Result.Select(x => x.Numero).FirstOrDefault();
                    formulario.SIGNO.EditValue = _Result.Select(x => x.Signo).FirstOrDefault();
                    formulario.CODIGOSUNAT.EditValue = _Result.Select(x => x.codigo).FirstOrDefault();
                    formulario.StartPosition = FormStartPosition.CenterParent;
                    formulario.Show();
                }
            }

        }
        void VALORES(int ID,string Tcodigo, string Tdescripcion, string Tserie, string Tnumero, string Tsigno, string Tsunat)
        {
            using (var CTX = new LiderEntities())
            {
                try
                {
                    var TipoCp = (from TCp in CTX.DOCTIPOes.Where(x => x.PKID == ID) select TCp).FirstOrDefault();
                    TipoCp.DocTipo1 = Tcodigo;
                    TipoCp.Descripcion = Tdescripcion;
                    TipoCp.Serie = Tserie;
                    TipoCp.Numero = Convert.ToInt32(Tnumero);
                    TipoCp.Signo = Convert.ToInt16(Tsigno);
                    TipoCp.codigo = Tsunat;
                    CTX.SaveChanges();
                    Refrescar();
                }
                catch (DbEntityValidationException t)
                {
                    foreach (var eve in t.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show("Propiedad: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
                        }
                    }
                }
            }
        }
    }
}