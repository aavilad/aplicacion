using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Distribucion
{
    public partial class frmRutas : DevExpress.XtraEditors.XtraForm
    {
        public string Tabla;
        public string NModulo;
        List<string> Lista;
        public frmRutas()
        {
            InitializeComponent();
        }

        private void GridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            MenuPrincipal.ShowPopup(gridControl1.PointToScreen(e.Point));
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
                try
                {
                    gridControl1.DataSource = null;
                    gridView1.Columns.Clear();
                    if (cadena.Length == 0)
                    {
                        Rutina.consultar(Query, Tabla);
                        gridControl1.DataSource = Rutina.ds.Tables[Tabla];
                        gridView1.BestFitColumns();
                    }
                    else
                    {
                        Rutina.consultar(Query + " having " + cadena, Tabla);
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

        private void FrmRutas_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void Modificar()
        {
            var Formulario = new Elementos.frmRuta();
            using (var CTX = new LiderEntities())
            {
                string Valor = Convert.ToString(gridView1.GetFocusedRowCellValue("Codigo"));
                var Result = CTX.RUTAS.Where(w => w.codigo == Valor);
                Formulario.pasar += new Elementos.frmRuta.Variables(Entidad_Ruta);
                Formulario.Codigo.EditValue = Valor;
                Formulario.Codigo.Enabled = false;
                Formulario.Descripcion.EditValue = Result.Select(s => s.descripcion).FirstOrDefault();
                Formulario.Activo.Checked = Convert.ToBoolean(Result.Select(s => s.Activo).FirstOrDefault());
            }
            Formulario.Show();
        }

        private void Entidad_Ruta(string Codigo, string Descripcion, bool Activo)
        {
            using (var CTX = new LiderEntities())
            {
                var Ra = (from R in CTX.RUTAS where R.codigo == Codigo.Trim() select R).FirstOrDefault();
                Ra.descripcion = Descripcion;
                Ra.Activo = Activo;
                CTX.SaveChanges();
                Refrescar();
            }
        }

        private void Entidad_Ruta_(string Codigo, string Descripcion, bool Activo)
        {
            using (var CTX = new LiderEntities())
            {
                RUTA Ra = new RUTA();
                Ra.codigo = Codigo;
                Ra.descripcion = Descripcion;
                Ra.Activo = Activo;
                CTX.RUTAS.Add(Ra);
                CTX.SaveChanges();
                Refrescar();
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

        private void NUEVO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Formulario = new Elementos.frmRuta();
            Formulario.pasar += new Elementos.frmRuta.Variables(Entidad_Ruta_);
            Formulario.Show();
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
                        try
                        {
                            foreach (var Rv in gridView1.GetSelectedRows())
                            {
                                string Codigo = Convert.ToString(gridView1.GetDataRow(Rv)["Codigo"]);
                                CTX.RUTAS.Remove(CTX.RUTAS.Where(w => w.codigo == Codigo).FirstOrDefault());
                                CTX.SaveChanges();
                                Formulario.dataGridView1.Rows.Add(Codigo, "Eliminado Con exito.");
                            }

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
                                    Formulario.dataGridView1.Rows.Add(message);
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