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
using System.Data.Entity.Infrastructure;

namespace xtraForm.Modulos.Distribucion
{
    public partial class frmZona : DevExpress.XtraEditors.XtraForm
    {
        public string Tabla;
        public string NModulo;
        public frmZona()
        {
            InitializeComponent();
        }

        private void FILTRO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
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
                k.DataSource = CTX.Database.SqlQuery<string>(Libreria.Constante.Mapa_View + "'" + Tabla + "'").ToList();
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
        private void Refrescar()
        {
            using (var CTX = new LiderEntities())
            {
                var FiltroDetalle = CTX.Filtroes.Where(w => w.tabla == Tabla).OrderBy(o => o.Orden).ToList();
                List<string> Lista = new List<string>();
                Lista.Clear();
                foreach (var X in FiltroDetalle)
                {
                    string Campo = X.campo;
                    string Condicion = X.condicion;
                    string Valor = X.valor;
                    string Operador = X.union;
                    Lista.Add(Tabla + "." + "[" + Campo + "]" + Condicion + "'" + Valor + "'" + Operador);
                }
                string cadena = string.Join(" ", Lista.ToArray());
                Condicion(cadena);
            }
        }

        void Condicion(string cadena)
        {
            using (var CTX = new LiderEntities())
            {
                var Rutina = new Libreria.Rutina();
                string Query = Convert.ToString(CTX.VistaAdministrativas.Where(x => x.IDModulo == (CTX.Moduloes.Where(a => a.Nombre == NModulo).Select(b => b.PKID)).FirstOrDefault()).Select(a => a.Vista.Trim()).FirstOrDefault());
                if (cadena.Length == 0)
                {
                    gridControl1.DataSource = null;
                    gridView1.Columns.Clear();
                    Rutina.consultar(Query, Tabla);
                    gridControl1.DataSource = Rutina.ds.Tables[Tabla];
                    gridView1.BestFitColumns();
                }
                else
                {
                    try
                    {
                        gridControl1.DataSource = null;
                        gridView1.Columns.Clear();
                        Rutina.consultar(Query + " having " + cadena, Tabla);
                        gridControl1.DataSource = Rutina.ds.Tables[Tabla];
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

        private void FrmZona_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Refrescar();
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

        private void GridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            MenuPrincipal.ShowPopup(gridControl1.PointToScreen(e.Point));
        }

        private void Modificar()
        {
            using (var CTX = new LiderEntities())
            {
                var Formulario = new Elementos.frmZone();
                Formulario.pasar += new Elementos.frmZone.Variables(Entidad_Zona);
                string ZonaCodigo = Convert.ToString(gridView1.GetFocusedRowCellValue("Codigo"));
                var Result = CTX.ZONAs.Where(w => w.Zona1 == ZonaCodigo);
                try
                {
                    if (Result != null)
                    {
                        Formulario.CODIGO.EditValue = ZonaCodigo;
                        Formulario.CODIGO.Enabled = false;
                        Formulario.DESCRIPCION.EditValue = Result.Select(s => s.Descripcion).FirstOrDefault().Trim();
                        Formulario.REPARTO.EditValue = Result.Select(s => s.Reparto).FirstOrDefault();
                        Formulario.VENTA.EditValue = Result.Select(s => s.Venta).FirstOrDefault();
                        Formulario.ESTADO.EditValue = Result.Select(s => s.Activo).FirstOrDefault();
                        Formulario.Show();
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
                            XtraMessageBox.Show(message);
                        }
                    }
                }
            }
        }

        private void Entidad_Zona(string Codigo, string Descripcion, bool Venta, bool Reparto, bool Estado,bool Riesgo)
        {
            using (var CTX = new LiderEntities())
            {
                var Zn = (from z in CTX.ZONAs where z.Zona1 == Codigo select z).FirstOrDefault();
                Zn.proveedor = "";
                Zn.Distancia = 0;
                Zn.Riesgo = Riesgo;
                Zn.Descripcion = Descripcion;
                Zn.Reparto = Reparto;
                Zn.Venta = Venta;
                Zn.Activo = Estado;
                CTX.SaveChanges();
            }
        }

        private void MODIFICAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }
    }
}