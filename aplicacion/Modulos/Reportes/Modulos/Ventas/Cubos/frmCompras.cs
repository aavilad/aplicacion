using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;


namespace xtraForm.Modulos.Reportes.Modulos.Ventas.Cubos
{
    public partial class frmCompras : DevExpress.XtraEditors.XtraForm
    {
        public frmCompras()
        {
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                PROVEEDOR.Properties.DataSource = CTX.PROVEEDORs.Select(x=>new { Codigo = x.Proveedor1.Trim(),Nombre = x.RazonSocial.Trim()}).OrderBy(y=>y.Nombre).ToList();
                PROVEEDOR.Properties.ValueMember = "Codigo";
                PROVEEDOR.Properties.DisplayMember = "Nombre";
            }

        }

        private void ACEPTAR_Click(object sender, EventArgs e)
        {
            string FechaInicial = Convert.ToDateTime(Desde.EditValue).ToString("yyyyMMdd");
            string FechaFinal = Convert.ToDateTime(Hasta.EditValue).ToString("yyyyMMdd");
            string Prov = Convert.ToString(PROVEEDOR.EditValue).Trim().Replace(",","','").Replace(" ","").Trim();
            string sql = Libreria.Constante.Compras.Replace("@FechaInicio", FechaInicial).Replace("@FechaFin", FechaFinal).Replace("@Prov", Prov);
            var proceso = new Libreria.Rutina();
            proceso.consultar(sql, "Compras");
            pivotGridControl1.DataSource = proceso.ds.Tables["Compras"];
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            pivotGridControl1.ShowPrintPreview();
        }
    }
}