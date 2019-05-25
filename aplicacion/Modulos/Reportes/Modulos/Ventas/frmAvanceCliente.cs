using DevExpress.XtraEditors;
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
        private void VARIABLE_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (TPSEARCH.SelectedIndex)
            {
                case 0:
                    var proceso = new Libreria.Proceso();
                    var Formulario = new Maestro.frmProveedor();
                    Formulario.pasar += new Maestro.frmProveedor.variables(IDProveedor);
                    proceso.consultar("select Proveedor, razonsocial as Nombre,ruc,direccion from proveedor", "proveedor");
                    Formulario.gridControl1.DataSource = proceso.ds.Tables["proveedor"];
                    Formulario.gridView1.OptionsView.ShowGroupPanel = false;
                    Formulario.gridView1.BestFitColumns();
                    Formulario.StartPosition = FormStartPosition.CenterScreen;
                    Formulario.ShowDialog();
                    break;
                    //case 1:
                    //    var Formulario = new Maestro.frmProveedor();
                    //    Formulario.pasar += new Maestro.frmProveedor.variables(IDProveedor);
                    //    Formulario.ShowDialog();
                    //    break;
                    //case 2:
                    //    var Formulario = new Maestro.frmProveedor();
                    //    Formulario.pasar += new Maestro.frmProveedor.variables(IDProveedor);
                    //    Formulario.ShowDialog();
                    //    break;
                    //case 3:
                    //    var Formulario = new Maestro.frmProveedor();
                    //    Formulario.pasar += new Maestro.frmProveedor.variables(IDProveedor);
                    //    Formulario.ShowDialog();
                    //    break;
            }
        }
        private void IDProveedor(string codigo, string descripcion)
        {
            string Desde = Convert.ToDateTime(DESDE.EditValue).ToString("yyyyMMdd");
            string Hasta = Convert.ToDateTime(HASTA.EditValue).ToString("yyyyMMdd");
            PK = codigo;
            VARIABLE.Text = descripcion;
            sql = Libreria.Constante.AvanceCobertura.Replace("@Desde", "'" + Desde + "'").Replace("@Hasta", "'" + Hasta + "'").Replace("@variable", "IDProv = '" + PK + "'");
        }

        private void BTNACEPTAR_Click(object sender, EventArgs e)
        {
            var proceso = new Libreria.Proceso();
            proceso.consultar(sql, "Cobertura");
            gridControl1.DataSource = proceso.ds.Tables["Cobertura"];
            gridView1.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[3].DisplayFormat.FormatString = "P";
        }
    }
}