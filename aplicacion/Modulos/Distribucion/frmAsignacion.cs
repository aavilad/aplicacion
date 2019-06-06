using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using xtraForm.Model;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Data.Entity.Validation;
using DevExpress.XtraSplashScreen;
using System.Data.Entity.Infrastructure;

namespace xtraForm.Modulos.Distribucion
{
    public partial class frmAsignacion : DevExpress.XtraEditors.XtraForm
    {
        List<string> Lista;
        public string NModulo;
        public string Tabla;
        public frmAsignacion()
        {
            InitializeComponent();
        }

        void Refrescar()
        {
            using (var CTX = new LiderEntities())
            {
                var FiltroDetalle = CTX.Filtroes.Where(w => w.tabla == Tabla).OrderBy(o => o.Orden).ToList();
                Lista = new List<string>();
                Lista.Clear();
                foreach (var X in FiltroDetalle)
                {
                    string Campo = X.campo;
                    string Condicion = X.condicion;
                    string Valor = X.valor;
                    string Operador = X.union;
                    Lista.Add(Tabla + "." + "[" + Campo + "]" + Condicion + "'" + Valor + "'" + Operador);
                }
                Condicion(string.Join(" ", Lista.ToArray()));
            }
        }
        void Condicion(string cadena)
        {
            using (var CTX = new LiderEntities())
            {
                var Rutina = new Libreria.Rutina();
                string Query = Convert.ToString(CTX.VistaAdministrativas.Where(x => x.IDModulo == (CTX.Moduloes.Where(a => a.Nombre == NModulo).Select(b => b.PKID)).FirstOrDefault()).Select(a => a.Vista.Trim()).FirstOrDefault());
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                try
                {
                    if (cadena.Length == 0)
                    {
                        Rutina.consultar(Query, Tabla);
                        gridControl1.DataSource = Rutina.ds.Tables[Tabla];
                        gridView1.BestFitColumns();
                    }
                    else
                    {
                        Rutina.consultar(Query + " WHERE " + cadena, Tabla);
                        gridControl1.DataSource = Rutina.ds.Tables[Tabla];
                        gridView1.BestFitColumns();
                    }
                }
                catch
                {
                    gridControl1.DataSource = null;
                    gridControl1.Refresh();
                }

            }
        }

        private void REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => Refrescar();

        private void FILTRO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                var Rutina = new Libreria.Rutina();
                Filtros.frmFiltros filtro = new Filtros.frmFiltros();
                DataGridViewComboBoxColumn i = filtro.dataGridView1.Columns["Index1"] as DataGridViewComboBoxColumn;
                i.DataSource = CTX.FiltroConfiguracions.Where(a => a.Tipo == "CONDICION").ToArray();
                i.DisplayMember = "Descripcion";
                i.ValueMember = "Codigo";
                DataGridViewComboBoxColumn j = filtro.dataGridView1.Columns["Index3"] as DataGridViewComboBoxColumn;
                j.DataSource = CTX.FiltroConfiguracions.Where(a => a.Tipo == "OPERADOR").ToList();
                j.DisplayMember = "Descripcion";
                j.ValueMember = "Codigo";
                DataGridViewComboBoxColumn k = filtro.dataGridView1.Columns["Index0"] as DataGridViewComboBoxColumn;
                k.DataSource = CTX.Database.SqlQuery<string>(Libreria.Constante.Mapa_Table + "'" + Tabla + "'").ToList();
                filtro.pasar += new Filtros.frmFiltros.variables(Condicion);
                filtro.StartPosition = FormStartPosition.CenterScreen;
                foreach (var fila in CTX.Filtroes.Where(w => w.tabla.Equals(Tabla)).OrderBy(x => x.Orden).ToList())
                {
                    filtro.dataGridView1.Rows.Add(fila.campo, fila.condicion, fila.valor, fila.union);
                }
                filtro.entidad = Tabla;
                filtro.ShowDialog();
            }
        }

        private void FrmAsignacion_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void GridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            MenuPrincipal.ShowPopup(gridControl1.PointToScreen(e.Point));
        }

        private void NUEVO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Formulario = new Modulos.Elementos.frmAsignacionVendedor();
            Formulario.pasar += new Elementos.frmAsignacionVendedor.Variables(Entidad_Asignacion);
            Formulario.Show();
        }

        private void Entidad_Asignacion(DataTable Tabla, string Rv)
        {
            using (var CTX = new LiderEntities())
            {
                CTX.ZONA_PERSONAL.RemoveRange(CTX.ZONA_PERSONAL.Where(w => w.Personal == Rv));
                foreach (DataRow T in Tabla.Rows)
                {
                    ZONA_PERSONAL Zp = new ZONA_PERSONAL();
                    Zp.Zona = Convert.ToString(T[0]);
                    Zp.Personal = Convert.ToString(T[1]);
                    Zp.Dia = Convert.ToString(T[2]);
                    Zp.Numero = Convert.ToInt32(T[3]);
                    Zp.Registro = Guid.NewGuid();
                    CTX.ZONA_PERSONAL.Add(Zp);
                }
                CTX.SaveChanges();
                Refrescar();
            }
        }

        private void Modificar()
        {
            using (var CTX = new LiderEntities())
                if (gridView1.SelectedRowsCount > 0)
                {
                    string Codigo = Convert.ToString(gridView1.GetFocusedRowCellValue("Codigo"));
                    var Result = CTX.ZONA_PERSONAL.Where(w => w.Personal == Codigo);
                    var Formulario = new Modulos.Elementos.frmAsignacionVendedor();
                    Formulario.Ex = true;
                    Formulario.pasar += new Elementos.frmAsignacionVendedor.Variables(Entidad_Asignacion);
                    Formulario.RVCODIGO.EditValue = Result.Select(s => s.Personal).Distinct().FirstOrDefault();
                    foreach (var Z in Result)
                    {
                        int Ix = 0;
                        int P = 0;
                        if (Formulario.dataGridView1.Rows.Count > 0)
                            for (int i = 0; i < Formulario.dataGridView1.Rows.Count; i++)
                            {
                                string Valor = Convert.ToString(Formulario.dataGridView1.Rows[i].Cells["Codigo"].Value);
                                if (Valor == Z.Zona)
                                {
                                    Ix = Formulario.dataGridView1.Rows[i].Index;
                                    P++;
                                }
                            }
                        var Zn = CTX.ZONAs.Where(w => w.Zona1 == Z.Zona).Select(s => s.Descripcion).FirstOrDefault();
                        if (P == 0)
                        {
                            Formulario.dataGridView1.Rows.Add(Z.Zona, Zn, false, false, false, false, false, false, false);
                            Formulario.dataGridView1.CurrentRow.Cells[0].ReadOnly = true;
                            Formulario.dataGridView1.CurrentRow.Cells[1].ReadOnly = true;
                        }
                        switch (Z.Numero)
                        {
                            case 1:
                                if (P > 0)
                                    Formulario.dataGridView1.Rows[Ix].Cells["Lunes"].Value = true;
                                else
                                    Formulario.dataGridView1.CurrentRow.Cells["Lunes"].Value = true;
                                break;
                            case 2:
                                if (P > 0)
                                    Formulario.dataGridView1.Rows[Ix].Cells["Martes"].Value = true;
                                else
                                    Formulario.dataGridView1.CurrentRow.Cells["Martes"].Value = true;
                                break;
                            case 3:
                                if (P > 0)
                                    Formulario.dataGridView1.Rows[Ix].Cells["Miercoles"].Value = true;
                                else
                                    Formulario.dataGridView1.CurrentRow.Cells["Miercoles"].Value = true;
                                break;
                            case 4:
                                if (P > 0)
                                    Formulario.dataGridView1.Rows[Ix].Cells["Jueves"].Value = true;
                                else
                                    Formulario.dataGridView1.CurrentRow.Cells["Jueves"].Value = true;
                                break;
                            case 5:
                                if (P > 0)
                                    Formulario.dataGridView1.Rows[Ix].Cells["Viernes"].Value = true;
                                else
                                    Formulario.dataGridView1.CurrentRow.Cells["Viernes"].Value = true;
                                break;
                            case 6:
                                if (P > 0)
                                    Formulario.dataGridView1.Rows[Ix].Cells["Sabado"].Value = true;
                                else
                                    Formulario.dataGridView1.CurrentRow.Cells["Sabado"].Value = true;
                                break;
                            case 7:
                                if (P > 0)
                                    Formulario.dataGridView1.Rows[Ix].Cells["Domingo"].Value = true;
                                else
                                    Formulario.dataGridView1.CurrentRow.Cells["Domingo"].Value = true;
                                break;
                        }
                    }
                    Formulario.Ex = false;
                    Formulario.Show();
                }
        }
        private void MODIFICAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            var proceso = new Libreria.Rutina();
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
                Modificar();
        }

        private void GridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                Modificar();
        }

        private void ELIMINAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Rutina = new Libreria.Rutina();
            if (Rutina.MensagePregunta("¿Continuar?") == DialogResult.Yes)
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    using (var CTX = new LiderEntities())
                    {
                        var Formulario = new Elementos.frmMsg();
                        Formulario.Scm03.SplashFormStartPosition = SplashFormStartPosition.Default;
                        Formulario.dataGridView1.Columns[0].HeaderText = "Entidad";
                        Formulario.dataGridView1.Columns[1].HeaderText = "Resultado";
                        Formulario.dataGridView1.Columns[2].HeaderText = string.Empty;
                        Formulario.dataGridView1.Columns[3].HeaderText = string.Empty;
                        Formulario.Show();
                        Formulario.Scm03.ShowWaitForm();
                        foreach (var Rv in gridView1.GetSelectedRows())
                        {
                            string Codigo = Convert.ToString(gridView1.GetDataRow(Rv)["Codigo"]);
                            CTX.ZONA_PERSONAL.RemoveRange(CTX.ZONA_PERSONAL.Where(w => w.Personal == Codigo));
                            try
                            {
                                CTX.SaveChanges();
                                Formulario.dataGridView1.Rows.Add(Codigo, "Eliminado Con exito.");
                            }
                            catch (DbEntityValidationException t)
                            {
                                foreach (DbEntityValidationResult item in t.EntityValidationErrors)
                                {
                                    DbEntityEntry entry = item.Entry;
                                    string entityTypeName = entry.Entity.GetType().Name;
                                    foreach (DbValidationError subItem in item.ValidationErrors)
                                    {
                                        string message = string.Format("Error '{0}' occurred in {1} at {2}", subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                                        Formulario.dataGridView1.Rows.Add(Codigo, message);
                                    }
                                }
                            }
                        }
                        Formulario.Scm03.CloseWaitForm();
                        Refrescar();
                    }
                }
            }
        }
    }
}