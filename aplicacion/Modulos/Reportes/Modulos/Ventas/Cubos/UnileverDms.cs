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

        private void BUSCAR_Click(object sender, EventArgs e)
        {
            string Desde = Convert.ToDateTime(dateEdit1.EditValue).ToString("yyyyMMdd");
            string Hasta = Convert.ToDateTime(dateEdit2.EditValue).ToString("yyyyMMdd");
            var proceso = new Libreria.Proceso();
            proceso.consultar("select * from unilever.importorderinvoice('" + Desde + "','" + Hasta + "')", "dms");
            pivotGridControl1.DataSource = proceso.ds.Tables["dms"];
        }
    }
}