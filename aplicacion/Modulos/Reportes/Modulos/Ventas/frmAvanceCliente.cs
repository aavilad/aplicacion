using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xtraForm.Modulos.Reportes.Modulos.Ventas
{
    public partial class frmAvanceCliente : DevExpress.XtraEditors.XtraForm
    {
        public frmAvanceCliente()
        {
            InitializeComponent();
        }

        string PK = "";
        string sql = "";
        string sql1 = "";
        string sql2 = "";
        string IDZona = "";
        private void VARIABLE_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var proceso = new Libreria.Proceso();
            switch (TPSEARCH.SelectedIndex)
            {
                case 0:
                    var FormularioA = new Maestro.frmProveedor();
                    FormularioA.pasar += new Maestro.frmProveedor.variables(IDProveedor);
                    proceso.consultar("select Proveedor, razonsocial as Nombre,ruc,direccion from proveedor", "proveedor");
                    FormularioA.gridControl1.DataSource = proceso.ds.Tables["proveedor"];
                    FormularioA.gridView1.OptionsView.ShowGroupPanel = false;
                    FormularioA.gridView1.BestFitColumns();
                    FormularioA.StartPosition = FormStartPosition.CenterScreen;
                    FormularioA.ShowDialog();
                    break;
                case 1:
                    var FormularioB = new Maestro.frmMarca();
                    FormularioB.pasar += new Maestro.frmMarca.variables(IDMarca);
                    proceso.consultar("select Marca, Descripcion from MARCA order by Proveedor,Descripcion,Orden", "Marca");
                    FormularioB.gridControl1.DataSource = proceso.ds.Tables["Marca"];
                    FormularioB.gridView1.OptionsView.ShowGroupPanel = false;
                    FormularioB.gridView1.BestFitColumns();
                    FormularioB.StartPosition = FormStartPosition.CenterScreen;
                    FormularioB.ShowDialog();
                    break;
                case 2:
                    var FormularioC = new Maestro.frmLinea();
                    FormularioC.pasar += new Maestro.frmLinea.variables(IDLinea);
                    proceso.consultar("select Linea,Descripcion from LINEA order by Linea,Descripcion,orden", "Linea");
                    FormularioC.gridControl1.DataSource = proceso.ds.Tables["Linea"];
                    FormularioC.gridView1.OptionsView.ShowGroupPanel = false;
                    FormularioC.gridView1.BestFitColumns();
                    FormularioC.StartPosition = FormStartPosition.CenterScreen;
                    FormularioC.ShowDialog();
                    break;
                case 3:
                    var FormularioD = new Maestro.frmProducto();
                    FormularioD.pasar += new Maestro.frmProducto.variables(IDProducto);
                    proceso.consultar("select Linea,Descripcion from LINEA order by Linea,Descripcion,orden", "Linea");
                    FormularioD.gridControl1.DataSource = proceso.ds.Tables["Linea"];
                    FormularioD.gridView1.OptionsView.ShowGroupPanel = false;
                    FormularioD.gridView1.BestFitColumns();
                    FormularioD.StartPosition = FormStartPosition.CenterScreen;
                    FormularioD.ShowDialog();
                    break;
            }
        }
        private void IDProveedor(string codigo, string descripcion)
        {
            string Desde = Convert.ToDateTime(DESDE.EditValue).ToString("yyyyMMdd");
            string Hasta = Convert.ToDateTime(HASTA.EditValue).ToString("yyyyMMdd");
            PK = codigo;
            VARIABLE.Text = descripcion;
            sql = Libreria.Constante.AvanceCobertura.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "IDProv = '" + PK + "'");
            sql1 = Libreria.Constante.Cobertura.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "IDProv = '" + PK + "'");
            sql2 = Libreria.Constante.Diferencia.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "IDProv = '" + PK + "'");
        }

        private void IDMarca(string codigo, string descripcion)
        {
            string Desde = Convert.ToDateTime(DESDE.EditValue).ToString("yyyyMMdd");
            string Hasta = Convert.ToDateTime(HASTA.EditValue).ToString("yyyyMMdd");
            PK = codigo;
            VARIABLE.Text = descripcion;
            sql = Libreria.Constante.AvanceCobertura.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "IDMarca = '" + PK + "'");
            sql1 = Libreria.Constante.Cobertura.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "IDMarca = '" + PK + "'");
            sql2 = Libreria.Constante.Diferencia.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "IDMarca = '" + PK + "'");

        }

        private void IDLinea(string codigo, string descripcion)
        {
            string Desde = Convert.ToDateTime(DESDE.EditValue).ToString("yyyyMMdd");
            string Hasta = Convert.ToDateTime(HASTA.EditValue).ToString("yyyyMMdd");
            PK = codigo;
            VARIABLE.Text = descripcion;
            sql = Libreria.Constante.AvanceCobertura.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "IDLinea = '" + PK + "'");
            sql1 = Libreria.Constante.Cobertura.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "IDLinea = '" + PK + "'");
            sql2 = Libreria.Constante.Diferencia.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "IDLinea = '" + PK + "'");
        }

        private void IDProducto(string codigo, string descripcion, string unidad)
        {
            string Desde = Convert.ToDateTime(DESDE.EditValue).ToString("yyyyMMdd");
            string Hasta = Convert.ToDateTime(HASTA.EditValue).ToString("yyyyMMdd");
            PK = codigo;
            VARIABLE.Text = descripcion;
            sql = Libreria.Constante.AvanceCobertura.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "Codigo = '" + PK + "'");
            sql1 = Libreria.Constante.Cobertura.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "Codigo = '" + PK + "'");
            sql2 = Libreria.Constante.Diferencia.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "Codigo = '" + PK + "'");

        }

        private void BTNACEPTAR_Click(object sender, EventArgs e)
        {
            var proceso = new Libreria.Proceso();
            var ds = new Lider2018DataSet();
            proceso.consultar(sql, "Cobertura");
            maestroCoberturaBindingSource.DataSource = proceso.ds.Tables["Cobertura"];
            //gridView1.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gridView1.Columns[3].DisplayFormat.FormatString = "P";
            gridView1.BestFitColumns();
        }

        private void TPSEARCH_SelectedIndexChanged(object sender, EventArgs e)
        {
            VARIABLE.ResetText();
            PK = "";
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //var proceso = new Libreria.Proceso();
            //DXMouseEventArgs ea = e as DXMouseEventArgs;
            //GridView view = sender as GridView;
            //GridHitInfo info = view.CalcHitInfo(ea.Location);
            //if (info.InRow || info.InRowCell)
            //{
            //    //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
            //    //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            //    var Formulario = new Elementos.frmAvanceClienteDetalle();
            //    IDZona = gridView1.GetFocusedRowCellValue("Codigo").ToString();
            //    proceso.consultar(Libreria.Constante.Cartera.Replace("@Zona", "'" + IDZona + "'"), "Cartera");
            //    Formulario.label1.Text = "Filas: " + proceso.ds.Tables["Cartera"].Rows.Count;
            //    Formulario.Cartera.DataSource = proceso.ds.Tables["Cartera"];
            //    proceso.consultar(sql1.Replace("@IDZONA", "'" + IDZona + "'"), "Cobertura");
            //    Formulario.label2.Text = "Filas: " + proceso.ds.Tables["Cobertura"].Rows.Count;
            //    Formulario.Cobertura.DataSource = proceso.ds.Tables["Cobertura"];
            //    Formulario.gridView1.BestFitColumns();
            //    Formulario.gridView2.BestFitColumns();
            //    Formulario.Show();
            //}
        }

        private void PREVIEW_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                gridView1.ShowPrintPreview();
            }
        }

        private void Cartera_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var proceso = new Libreria.Proceso();
            var Formulario = new Elementos.frmAvanceClienteDetalle();
            IDZona = gridView1.GetFocusedRowCellValue("Codigo").ToString();
            proceso.consultar(Libreria.Constante.Cartera.Replace("@Zona", "'" + IDZona + "'"), "Cartera");
            Formulario.label1.Text = "Filas: " + proceso.ds.Tables["Cartera"].Rows.Count;
            Formulario.Cartera.DataSource = proceso.ds.Tables["Cartera"];
            Formulario.gridView1.BestFitColumns();
            Formulario.Show();
        }

        private void Cobertura_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var proceso = new Libreria.Proceso();
            var Formulario = new Elementos.frmAvanceClienteDetalle();
            IDZona = gridView1.GetFocusedRowCellValue("Codigo").ToString();
            proceso.consultar(sql1.Replace("@IDZONA", "'" + IDZona + "'"), "Cobertura");
            Formulario.label1.Text = "Filas: " + proceso.ds.Tables["Cobertura"].Rows.Count;
            Formulario.Cartera.DataSource = proceso.ds.Tables["Cobertura"];
            Formulario.gridView1.BestFitColumns();
            Formulario.Show();
        }

        private void Diferencia_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var proceso = new Libreria.Proceso();
            var Formulario = new Elementos.frmAvanceClienteDetalle();
            IDZona = gridView1.GetFocusedRowCellValue("Codigo").ToString();
            proceso.consultar(sql2.Replace("@IDZONA", "'" + IDZona + "'"), "Diferencia");
            Formulario.label1.Text = "Filas: " + proceso.ds.Tables["Diferencia"].Rows.Count;
            Formulario.Cartera.DataSource = proceso.ds.Tables["Diferencia"];
            Formulario.gridView1.BestFitColumns();
            Formulario.Show();
        }
    }
}