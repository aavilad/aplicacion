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

namespace xtraForm.Modulos.Ventas
{
    public partial class frmListaPrecio : DevExpress.XtraEditors.XtraForm
    {
        string tabla = "Vva_PrecioEscala";
        public frmListaPrecio()
        {
            InitializeComponent();
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
        string Codigo;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Codigo = Convert.ToString(gridView1.GetFocusedRowCellValue("Codigo"));
            using (var Context = new Model.LiderAppEntities())
            {
                var Costo = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.Costo).FirstOrDefault();
                var P1 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.C_MENOR).FirstOrDefault();
                var P2 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.C_MAYOR).FirstOrDefault();
                var MinMay = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.MinimoMayorista).FirstOrDefault();
                var P3 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.CR_MENOR).FirstOrDefault();
                var P4 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.CR_MENOR).FirstOrDefault();
                var MinEsp = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.MinimoEspecial).FirstOrDefault();
                var P5 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL05).FirstOrDefault();
                var P6 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL06).FirstOrDefault();
                var P7 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL07).FirstOrDefault();
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(Costo, P1, MinMay, P2, P3, P4, MinEsp, P5, P6, P7);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && Codigo != null)
            {
                using (var Context = new Model.LiderAppEntities())
                {
                    var Costo = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.Costo).FirstOrDefault();
                    var P1 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.C_MENOR).FirstOrDefault();
                    var P2 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.C_MAYOR).FirstOrDefault();
                    var MinMay = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.MinimoMayorista).FirstOrDefault();
                    var P3 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.CR_MENOR).FirstOrDefault();
                    var P4 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.CR_MENOR).FirstOrDefault();
                    var MinEsp = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.MinimoEspecial).FirstOrDefault();
                    var P5 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL05).FirstOrDefault();
                    var P6 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL06).FirstOrDefault();
                    var P7 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL07).FirstOrDefault();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(Costo, P1,MinMay, P2, P3, P4, MinEsp, P5, P6, P7);
                }
            }
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && Codigo != null)
            {
                try
                {
                    using (var Context = new Model.LiderAppEntities())
                    {
                        Model.PRODUCTO pd = new Model.PRODUCTO { Producto1 = Codigo };
                        Context.PRODUCTO.Attach(pd);
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
                        var Costo = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.Costo).FirstOrDefault();
                        var P1 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.C_MENOR).FirstOrDefault();
                        var P2 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.C_MAYOR).FirstOrDefault();
                        var MinMay = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.MinimoMayorista).FirstOrDefault();
                        var P3 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.CR_MENOR).FirstOrDefault();
                        var P4 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.CR_MENOR).FirstOrDefault();
                        var MinEsp = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.MinimoEspecial).FirstOrDefault();
                        var P5 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL05).FirstOrDefault();
                        var P6 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL06).FirstOrDefault();
                        var P7 = Context.Vva_Producto.Where(x => x.Codigo == Codigo).Select(p => p.ESPECIAL07).FirstOrDefault();
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