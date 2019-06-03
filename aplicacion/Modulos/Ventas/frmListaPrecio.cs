using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Ventas
{
    public partial class frmListaPrecio : DevExpress.XtraEditors.XtraForm
    {
        public frmListaPrecio()
        {
            InitializeComponent();
        }

        private void TxtCodigoProducto_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frmprincipal = new frmPrincipal();
            frmprincipal.Scm01.SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Default;
            frmprincipal.Scm01.ShowWaitForm();
            var Codigo = Convert.ToString(TxtCodigoProducto.EditValue);
            try
            {
                using (var Context = new LiderEntities())
                {
                    var ProductoEscala = (from p in Context.PRODUCTOes.AsEnumerable().Where(x => x.Producto1.StartsWith(Codigo))
                                          from pu in Context.PlantillaUnidads.AsEnumerable().Where(x => x.PKID == p.IDUnidad).DefaultIfEmpty()
                                          select new
                                          {
                                              Codigo = p.Producto1.Trim(),
                                              Descripcion = p.Descripcion.Trim(),
                                              UnidadAnterior = p.UniMed.Trim(),
                                              Unidad = pu == null ? string.Empty : pu.Abreviacion.Trim()
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
                frmprincipal.Scm01.CloseWaitForm();
            }
            catch (DbEntityValidationException t)
            {
                foreach (var eve in t.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        MessageBox.Show("- Propiedad: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
                    }
                }
            }

        }
        string Codigo;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Codigo = Convert.ToString(gridView1.GetFocusedRowCellValue("Codigo"));
            using (var Context = new LiderEntities())
            {
                var Costo = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.Costo).FirstOrDefault();
                var P1 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMenContado).FirstOrDefault();
                var P2 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMayContado).FirstOrDefault();
                var MinMay = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.minimomay).FirstOrDefault();
                var P3 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMenCredito).FirstOrDefault();
                var P4 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMayCredito).FirstOrDefault();
                var MinEsp = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.CanEspecial).FirstOrDefault();
                var P5 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecEspecial).FirstOrDefault();
                var P6 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecSEspecial).FirstOrDefault();
                var P7 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecSSEspecial).FirstOrDefault();
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(Costo, P1, MinMay, P2, P3, P4, MinEsp, P5, P6, P7);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && Codigo != null)
            {
                using (var Context = new LiderEntities())
                {
                    var Costo = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.Costo).FirstOrDefault();
                    var P1 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMenContado).FirstOrDefault();
                    var P2 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMayContado).FirstOrDefault();
                    var MinMay = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.minimomay).FirstOrDefault();
                    var P3 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMenCredito).FirstOrDefault();
                    var P4 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMayCredito).FirstOrDefault();
                    var MinEsp = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.CanEspecial).FirstOrDefault();
                    var P5 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecEspecial).FirstOrDefault();
                    var P6 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecSEspecial).FirstOrDefault();
                    var P7 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecSSEspecial).FirstOrDefault();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(Costo, P1, MinMay, P2, P3, P4, MinEsp, P5, P6, P7);
                }
            }
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && Codigo != null)
            {
                try
                {
                    using (var Context = new LiderEntities())
                    {
                        PRODUCTO pd = new PRODUCTO { Producto1 = Codigo };
                        Context.PRODUCTOes.Attach(pd);
                        pd.Costo = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[0].Value);
                        pd.PrecMenContado = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value);
                        pd.PrecMayContado = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[2].Value);
                        pd.minimomay = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value);
                        pd.PrecMenCredito = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value);
                        pd.PrecMayCredito = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[5].Value);
                        pd.CanEspecial = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value);
                        pd.PrecEspecial = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[7].Value);
                        pd.PrecSEspecial = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[8].Value);
                        pd.PrecSSEspecial = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[9].Value);
                        Context.Configuration.ValidateOnSaveEnabled = false;
                        Context.SaveChanges();
                        var Costo = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.Costo).FirstOrDefault();
                        var P1 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMenContado).FirstOrDefault();
                        var P2 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMayContado).FirstOrDefault();
                        var MinMay = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.minimomay).FirstOrDefault();
                        var P3 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMenCredito).FirstOrDefault();
                        var P4 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecMayCredito).FirstOrDefault();
                        var MinEsp = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.CanEspecial).FirstOrDefault();
                        var P5 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecEspecial).FirstOrDefault();
                        var P6 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecSEspecial).FirstOrDefault();
                        var P7 = Context.PRODUCTOes.Where(x => x.Producto1 == Codigo).Select(p => p.PrecSSEspecial).FirstOrDefault();
                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(Costo, P1, MinMay, P2, P3, P4, MinEsp, P5, P6, P7);
                        MessageBox.Show("Lista actualziada con exito.");
                    }
                }
                catch (DbEntityValidationException t)
                {
                    foreach (var eve in t.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show("- Propiedad: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
                        }
                    }
                }
            }
        }
    }
}