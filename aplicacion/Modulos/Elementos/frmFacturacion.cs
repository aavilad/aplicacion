using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;
namespace xtraForm.Modulos.Elementos
{
    public partial class frmFacturacion : DevExpress.XtraEditors.XtraForm
    {
        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var proceso = new Libreria.Proceso();
            if (proceso.MensagePregunta("¿Cancelar?") == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            using (var context = new LiderEntities())
            {
                SerieFacturas.Properties.ShowHeader = false;
                SerieFacturas.Properties.DisplayMember = "Serie";
                SerieFacturas.Properties.ValueMember = "ID";
                SerieFacturas.Properties.Columns.Add(new LookUpColumnInfo("Detalle", string.Empty, 10));
                SerieFacturas.Properties.DataSource =
                    context.DOCTIPOes.Where(x => x.codigo == "01").
                    Select(a => new { ID = a.PKID, Serie = a.Serie.Trim(), Detalle = a.Serie.Trim() + ":" + a.Descripcion.Trim() }).ToList();

                SerieBoletas.Properties.ShowHeader = false;
                SerieBoletas.Properties.DisplayMember = "Serie";
                SerieBoletas.Properties.ValueMember = "ID";
                SerieBoletas.Properties.Columns.Add(new LookUpColumnInfo("Detalle", string.Empty, 10));
                SerieBoletas.Properties.DataSource =
                    context.DOCTIPOes.Where(x => x.codigo == "03").
                    Select(a => new { ID = a.PKID, Serie = a.Serie.Trim(), Detalle = a.Serie.Trim() + ":" + a.Descripcion.Trim() }).ToList();

                Gestion.Properties.ShowHeader = false;
                Gestion.Properties.DisplayMember = "codigo";
                Gestion.Properties.ValueMember = "codigo";
                Gestion.Properties.Columns.Add(new LookUpColumnInfo("codigo", string.Empty, 10));
                Gestion.Properties.DataSource = context.Gestions.ToList();
            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            var proceso = new Libreria.Proceso();
            string Fecha = Convert.ToDateTime(FechaProceso.EditValue).ToString("yyyyMMdd");
            if (flRuta.Checked)
            {
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                using (var Context = new LiderEntities())
                {
                    proceso.consultar(@"
                    SELECT 
                           REPARTO.Ruta As Codigo, 
                           RUTAS.Descripcion
                    FROM RUTAS
                         INNER JOIN REPARTO ON RUTAS.codigo = REPARTO.Ruta
                    WHERE(REPARTO.Dia = DATEPART(w, '" + Fecha + @"'))
                         AND (RUTAS.Activo = 1) AND (REPARTO.Activo = 1)
                    GROUP BY REPARTO.Ruta,RUTAS.Descripcion;", "Rutas");
                    gridControl1.DataSource = proceso.ds.Tables["Rutas"];
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsSelection.MultiSelect = true;
                    gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                }
            }
            else if (flVendedor.Checked)
            {
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                using (var Context = new LiderEntities())
                {
                    proceso.consultar(@"
                    SELECT Vva_Vendedor.[Codigo vendedor] AS Codigo, 
                           FuerzaVentas.descrip AS FzaVentas, 
                           Vva_Vendedor.[Nombre Vendedor] AS Nombre
                    FROM Vva_Vendedor
                         INNER JOIN FuerzaVentas ON Vva_Vendedor.IDFzaVentas = FuerzaVentas.fzavtas
                    WHERE FuerzaVentas.PKID > 0;
                    ", "vendedor");
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsSelection.MultiSelect = true;
                    gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                    gridControl1.DataSource = proceso.ds.Tables["vendedor"];
                    gridView1.BestFitColumns();
                    gridView1.Columns[1].GroupIndex = 1;
                }
            }
        }

        private void flRuta_CheckedChanged(object sender, EventArgs e)
        {
            if (flRuta.Checked)
            {
                flVendedor.Checked = false;
            }
        }

        private void flVendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (flVendedor.Checked)
            {
                flRuta.Checked = false;
            }
        }

        private void SerieFacturas_EditValueChanged(object sender, EventArgs e)
        {
            using (var Context = new LiderEntities())
            {
                FCorrelativo.EditValue = Context.DOCTIPOes.Where(x => x.PKID == (int)SerieFacturas.EditValue).Select(s => s.Numero).FirstOrDefault();
                DescripcionF.EditValue = Context.DOCTIPOes.Where(x => x.PKID == (int)SerieFacturas.EditValue).Select(s => s.Descripcion).FirstOrDefault();
            }

        }

        private void SerieBoletas_EditValueChanged(object sender, EventArgs e)
        {
            using (var Context = new LiderEntities())
            {
                BCorrelativo.EditValue = Context.DOCTIPOes.Where(x => x.PKID == (int)SerieBoletas.EditValue).Select(s => s.Numero).FirstOrDefault();
                DescripcionB.EditValue = Context.DOCTIPOes.Where(x => x.PKID == (int)SerieBoletas.EditValue).Select(s => s.Descripcion).FirstOrDefault();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    var frmwaint = new frmPrincipal();
                    frmwaint.splashScreenManager1.SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Default;
                    frmwaint.splashScreenManager1.ShowWaitForm();
                    GeneraDocumentos();
                    SerieFacturas_EditValueChanged(sender, e);
                    SerieBoletas_EditValueChanged(sender, e);
                    frmwaint.splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    MessageBox.Show("Selecione al menos un item de la lista.");
                }
            }
        }
        void GeneraDocumentos()
        {
            var proceso = new Libreria.Proceso();
            var fecha = Convert.ToDateTime(FechaProceso.EditValue).ToString("dd/MM/yyyy");
            var Dia = Convert.ToInt32(DateTime.Parse(fecha).DayOfWeek) == 0 ? 7 : Convert.ToInt32(DateTime.Parse(fecha).DayOfWeek);

            if (flRuta.Checked)
            {
                var Campos = new List<string>();
                foreach (var i in gridView1.GetSelectedRows())
                {
                    Campos.Add("'" + Convert.ToString(gridView1.GetRowCellValue(i, "Codigo")).Trim() + "'");
                }
                string cadena = string.Join(",", Campos.ToArray());
                using (var Context = new LiderEntities())
                {
                    var Pedidos = (from p in Context.PEDIDOes.AsEnumerable()
                                   join r in Context.REPARTOes.AsEnumerable().Where(x => x.Dia == Dia && cadena.Contains(x.Ruta)) on p.Personal equals r.Personal
                                   where p.Fecha == DateTime.Parse(fecha) && p.Aprobado == true && p.Procesado == false && p.gestion == Gestion.EditValue.ToString().Trim()
                                   select new { Pedido = p.Pedido1, Persona = p.TipoPersona, Tipo = p.tipodoc }).ToList();

                    if (Pedidos.Count > 0)
                    {
                        foreach (var fila in Pedidos)
                        {
                            //Context.sp_genera_documento(fila.Pedido, Convert.ToInt32(fila.Persona), fila.Tipo);
                        }
                        var Documentos = (from p in Context.DOCUMENTOes.AsEnumerable()
                                          join r in Pedidos on p.Pedido equals r.Pedido
                                          select new { Documento = p.Documento1.Trim(), Tipo = p.TipoDoc.Trim() }).ToList();
                        foreach (var fila in Documentos)
                        {
                            try
                            {
                                if (fila.Tipo == "B")
                                {
                                    var Numero = Convert.ToInt32((from p in Context.DOCTIPOes.AsEnumerable() where p.PKID == (int)SerieBoletas.EditValue select p.Numero).FirstOrDefault());
                                    var serie = SerieBoletas.Text.Trim();
                                    var NumeroComprobante = serie + Numero.ToString("D8");
                                    var Cp = (from p in Context.DOCUMENTOes where p.Documento1 == fila.Documento && p.TipoDoc == fila.Tipo select p).FirstOrDefault();
                                    Cp.Generado = NumeroComprobante;
                                    var Pd = (from p in Context.PEDIDOes
                                              where p.Pedido1 == Context.DOCUMENTOes.Where(y => y.Documento1 == fila.Documento && y.TipoDoc == fila.Tipo).Select(x => x.Pedido.Trim()).FirstOrDefault()
                                              select p).FirstOrDefault();
                                    Pd.Procesado = true;
                                    Pd.statusWeb = true;
                                    var Dt = (from p in Context.DOCTIPOes where p.PKID == (int)SerieBoletas.EditValue select p).FirstOrDefault();
                                    Dt.Numero = Dt.Numero + 1;
                                }
                                else if (fila.Tipo == "F")
                                {
                                    var Numero = Convert.ToInt32((from p in Context.DOCTIPOes.AsEnumerable()
                                                                  where p.PKID == (int)SerieFacturas.EditValue
                                                                  select p.Numero).FirstOrDefault());
                                    var serie = SerieFacturas.Text.Trim();
                                    var NumeroComprobante = serie + Numero.ToString("D8");
                                    var Cp = (from p in Context.DOCUMENTOes
                                              where p.Documento1 == fila.Documento && p.TipoDoc == fila.Tipo
                                              select p).FirstOrDefault();
                                    Cp.Generado = NumeroComprobante;
                                    var Pd = (from p in Context.PEDIDOes
                                              where p.Pedido1 == Context.DOCUMENTOes.Where(y => y.Documento1 == fila.Documento && y.TipoDoc == fila.Tipo).Select(x => x.Pedido.Trim()).FirstOrDefault()
                                              select p).FirstOrDefault();
                                    Pd.Procesado = true;
                                    Pd.statusWeb = true;
                                    var Dt = (from p in Context.DOCTIPOes
                                              where p.PKID == (int)SerieFacturas.EditValue
                                              select p).FirstOrDefault();
                                    Dt.Numero = Dt.Numero + 1;
                                }
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
                        Context.SaveChanges();
                        MessageBox.Show("Se realizo la facturacion de : " + Pedidos.Count + " Pedidos con exito.\n Detalles en control genera.");
                    }
                    else
                    {
                        MessageBox.Show("No existen pedidos para procesar");
                    }
                }
            }
            else if (flVendedor.Checked)
            {
                var Campos = new List<string>();
                foreach (var i in gridView1.GetSelectedRows())
                {
                    Campos.Add("'" + Convert.ToString(gridView1.GetRowCellValue(i, "Codigo")) + "'");
                }
                string cadena = string.Join(",", Campos.ToArray());
                using (var Context = new LiderEntities())
                {
                    var Pedidos = (from p in Context.PEDIDOes.AsEnumerable()
                                   where p.Fecha == DateTime.Parse(fecha) &&
                                   cadena.Contains(p.Personal) && p.Aprobado == true && p.Procesado == false && p.gestion == Gestion.EditValue.ToString().Trim()
                                   select new { Pedido = p.Pedido1, Persona = p.TipoPersona, Tipo = p.tipodoc }).ToList();
                    if (Pedidos.Count > 0)
                    {
                        foreach (var fila in Pedidos)
                        {
                            //Context.sp_genera_documento(fila.Pedido, Convert.ToInt32(fila.Persona), fila.Tipo);
                        }
                        var Documentos = (from p in Context.DOCUMENTOes.AsEnumerable()
                                          join r in Pedidos on p.Pedido equals r.Pedido
                                          select new { Documento = p.Documento1.Trim(), Tipo = p.TipoDoc.Trim() }).ToList();
                        foreach (var fila in Documentos)
                        {
                            try
                            {
                                if (fila.Tipo == "B")
                                {
                                    var Numero = Convert.ToInt32((from p in Context.DOCTIPOes.AsEnumerable() where p.PKID == (int)SerieBoletas.EditValue select p.Numero).FirstOrDefault());
                                    var serie = SerieBoletas.Text.Trim();
                                    var NumeroComprobante = serie + Numero.ToString("D8");
                                    var Cp = (from p in Context.DOCUMENTOes where p.Documento1 == fila.Documento && p.TipoDoc == fila.Tipo select p).FirstOrDefault();
                                    Cp.Generado = NumeroComprobante;
                                    var Pd = (from p in Context.PEDIDOes
                                              where p.Pedido1 == Context.DOCUMENTOes.Where(y => y.Documento1 == fila.Documento && y.TipoDoc == fila.Tipo).Select(x => x.Pedido.Trim()).FirstOrDefault()
                                              select p).FirstOrDefault();
                                    Pd.Procesado = true;
                                    Pd.statusWeb = true;
                                    var Dt = (from p in Context.DOCTIPOes where p.PKID == (int)SerieBoletas.EditValue select p).FirstOrDefault();
                                    Dt.Numero = Dt.Numero + 1;
                                }
                                else if (fila.Tipo == "F")
                                {
                                    var Numero = Convert.ToInt32((from p in Context.DOCTIPOes.AsEnumerable()
                                                                  where p.PKID == (int)SerieFacturas.EditValue
                                                                  select p.Numero).FirstOrDefault());
                                    var serie = SerieFacturas.Text.Trim();
                                    var NumeroComprobante = serie + Numero.ToString("D8");
                                    var Cp = (from p in Context.DOCUMENTOes
                                              where p.Documento1 == fila.Documento && p.TipoDoc == fila.Tipo
                                              select p).FirstOrDefault();
                                    Cp.Generado = NumeroComprobante;
                                    var Pd = (from p in Context.PEDIDOes
                                              where p.Pedido1 == Context.DOCUMENTOes.Where(y => y.Documento1 == fila.Documento && y.TipoDoc == fila.Tipo).Select(x => x.Pedido.Trim()).FirstOrDefault()
                                              select p).FirstOrDefault();
                                    Pd.Procesado = true;
                                    Pd.statusWeb = true;
                                    var Dt = (from p in Context.DOCTIPOes
                                              where p.PKID == (int)SerieFacturas.EditValue
                                              select p).FirstOrDefault();
                                    Dt.Numero = Dt.Numero + 1;
                                }
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
                        Context.SaveChanges();
                        MessageBox.Show("Se realizo la facturacion de : " + Pedidos.Count + " con exito.\n Detalles en control genera.");
                    }
                    else
                    {
                        MessageBox.Show("No existen pedidos para procesar");
                    }
                }
            }
        }

    }
}