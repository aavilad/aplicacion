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
using DevExpress.XtraSplashScreen;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace xtraForm.Modulos.Entidades
{
    public partial class frmSucursal : DevExpress.XtraEditors.XtraForm
    {
        public string NModulo;
        public string Tabla;
        public frmSucursal()
        {
            InitializeComponent();
        }
        void condicion(string cadena)
        {
            using (var Context = new LiderEntities())
            {
                var proceso = new Libreria.Rutina();
                string Query = Convert.ToString(Context.VistaAdministrativas.Where(x => x.IDModulo == (Context.Moduloes.Where(a => a.Nombre == NModulo).Select(b => b.PKID)).FirstOrDefault()).Select(a => a.Vista.Trim()).FirstOrDefault());
                if (cadena.Length == 0)
                {
                    proceso.consultar(Query, Tabla);
                    gridControl1.DataSource = proceso.ds.Tables[Tabla];
                    gridView1.BestFitColumns();
                }
                else
                    try
                    {
                        proceso.consultar(Query + " and " + cadena, Tabla);
                        gridControl1.DataSource = proceso.ds.Tables[Tabla];
                        gridView1.BestFitColumns();
                    }
                    catch
                    {
                        gridControl1.DataSource = null;
                        gridControl1.Refresh();
                    }
            }
        }
        private void Refrescar()
        {
            try
            {
                using (var CTX = new LiderEntities())
                {
                    List<string> Lista = new List<string>();
                    var Result = CTX.Filtroes.Where(w => w.tabla == Tabla).OrderBy(o => o.Orden);
                    foreach (var X in Result)
                        Lista.Add(Tabla + "." + "[" + X.campo + "]" + X.condicion + "'" + X.valor + "'" + X.union);
                    string cadena = string.Join(" ", Lista.ToArray());
                    condicion(cadena);
                }
            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
            }
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
                k.DataSource = CTX.Database.SqlQuery<string>(Libreria.Constante.Mapa_Table + "'" + Tabla + "'").ToList();
                filtro.pasar += new Filtros.frmFiltros.variables(condicion);
                filtro.StartPosition = FormStartPosition.CenterScreen;
                foreach (var fila in CTX.Filtroes.Where(w => w.tabla.Equals(Tabla)).ToList())
                {
                    filtro.dataGridView1.Rows.Add(fila.campo, fila.condicion, fila.valor, fila.union);
                }
                filtro.entidad = Tabla;
                filtro.ShowDialog();
            }
        }

        private void REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Refrescar();
        }

        private void FrmSucursal_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void GridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            MenuPrincipal.ShowPopup(gridControl1.PointToScreen(e.Point));
        }

        private void NUEVO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Formulario = new Elementos.frmSucursal();
            Formulario.pasar += new Elementos.frmSucursal.Variable(Entidad_Sucursal);
            Formulario.Show();
        }

        private void Entidad_Sucursal(string Codigo, int PersonaTp, string Nombre, string Documento, string FIngreso, string FNacimiento, string NTelefono, bool Comision, bool Activo, decimal Sueldo, bool EVendedor, int Clase, string Grupo, string GrupoK, string Distrito, int FVenta, bool Novedad, bool Dms, decimal pParticipa, decimal pCuota, string SCodigo)
        {
            using (var CTX = new LiderEntities())
            {
                string Propiedad;
                PERSONAL Rv = new PERSONAL();
                Rv.Personal1 = Codigo;
                Rv.TipoPersona = Convert.ToString(PersonaTp);
                Rv.Nombre = Nombre;
                Rv.LibElec = Documento;
                Rv.FechIng = Convert.ToDateTime(FIngreso);
                Rv.FechNac = Convert.ToDateTime(FNacimiento);
                Rv.Telefono = NTelefono;
                Rv.Comision = Comision;
                Rv.Activo = Activo;
                Rv.Sueldo = Sueldo;
                Rv.vendedor = EVendedor;
                Rv.clase = Clase;
                Rv.grupo = Grupo;
                Rv.grupok = GrupoK;
                Rv.distrito = Distrito;
                Rv.fzavtas = Convert.ToString(FVenta);
                Rv.novedad = Novedad;
                Rv.dms = Dms;
                Rv.pparticipa = pParticipa;
                Rv.pcuota = pCuota;
                Rv.supercodigo = SCodigo;
                CTX.PERSONALs.Add(Rv);
                Propiedad = "Codigo";
                if (CTX.PERSONALs.Where(w => w.Personal1 == Codigo).FirstOrDefault() == null)
                {
                    Propiedad = "Nombre";
                    if (CTX.PERSONALs.Where(w => w.Nombre == Nombre).FirstOrDefault() == null)
                    {
                        CTX.SaveChanges();
                        Refrescar();
                    }
                }
                else
                    MessageBox.Show("Existe coincidencia en la tabla con la propieda : " + Propiedad);
            }
        }

        private void Entidad_Sucursal_(string Codigo, int PersonaTp, string Nombre, string Documento, string FIngreso, string FNacimiento, string NTelefono, bool Comision, bool Activo, decimal Sueldo, bool EVendedor, int Clase, string Grupo, string GrupoK, string Distrito, int FVenta, bool Novedad, bool Dmd, decimal pParticipa, decimal pCuota, string SCodigo)
        {
            using (var CTX = new LiderEntities())
            {
                var Rv = (from pl in CTX.PERSONALs where pl.Personal1 == Codigo select pl).FirstOrDefault();
                Rv.Personal1 = Codigo;
                Rv.Nombre = Nombre;
                Rv.Activo = Activo;
                Rv.distrito = Distrito;
                CTX.SaveChanges();
                Refrescar();
            }
        }

        private void MODIFICAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                string PersonalCodigo = Convert.ToString(gridView1.GetFocusedRowCellValue("Codigo"));
                var Suc = CTX.PERSONALs.Where(w => w.Activo == true && w.Personal1 == PersonalCodigo);
                string PersonalNombre = Suc.Select(s => s.Nombre.Trim()).FirstOrDefault();
                bool PersonalActivo = Suc.Select(s => s.Activo).FirstOrDefault();
                string DistritoID = Suc.Select(s => s.distrito).FirstOrDefault();
                var Formulario = new Elementos.frmSucursal();
                Formulario.pasar += new Elementos.frmSucursal.Variable(Entidad_Sucursal_);
                Formulario.CODIGO.Text = PersonalCodigo;
                Formulario.CODIGO.Enabled = false;
                Formulario.DESCRIPCION.Text = PersonalNombre;
                Formulario.ESTADO.Checked = PersonalActivo;
                Formulario.IDDISTRITO.EditValue = DistritoID;
                Formulario.Show();
            }
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
                            CTX.PERSONALs.Remove(CTX.PERSONALs.Where(w => w.Personal1 == Codigo).FirstOrDefault());
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