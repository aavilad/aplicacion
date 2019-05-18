using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xtraForm.Modulos.Reportes.Modulos.Ventas.Cubos
{
    public partial class UnileverDms : DevExpress.XtraEditors.XtraForm
    {
        public UnileverDms()
        {
            InitializeComponent();

        }

        private void UnileverDms_Load(object sender, EventArgs e)
        {

            dateEdit1.EditValue = DateTime.Now;
            dateEdit2.EditValue = DateTime.Now;
        }
        string sql;
        private void BUSCAR_Click(object sender, EventArgs e)
        {
            var proceso = new Libreria.Proceso();
            var formulario0 = new frmPrincipal();
            string Desde = Convert.ToDateTime(dateEdit1.EditValue).ToString("yyyyMMdd");
            string Hasta = Convert.ToDateTime(dateEdit2.EditValue).ToString("yyyyMMdd");
            switch (DATABASE.SelectedIndex)
            {
                case 0:
                    sql =
                      @"
                      select *  from Unilever.importorderinvoice('" + Desde + "','" + Hasta + @"')
                      union all
                      select *  from LiderChepen18.Unilever.importorderinvoice('" + Desde + "','" + Hasta + @"')
                      ";
                    break;
                case 1:
                    sql = @"select *  from Dismarsf18.Unilever.importorderinvoice('" + Desde + "','" + Hasta + @"')";
                    break;
                case 2:
                    sql = @"";
                    break;
            }
            formulario0.splashScreenManager1.SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Default;
            formulario0.splashScreenManager1.ShowWaitForm();
            try
            {
                proceso.consultar(sql, "dms");
                pivotGridControl1.DataSource = proceso.ds.Tables["dms"];
                formulario0.splashScreenManager1.CloseWaitForm();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
            }

        }

        private void Export_Click(object sender, EventArgs e)
        {
            pivotGridControl1.ShowPrintPreview();
        }
    }
}