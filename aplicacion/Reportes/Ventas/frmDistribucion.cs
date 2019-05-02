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

namespace xtraForm.Reportes.Ventas
{
    public partial class frmDistribucion : DevExpress.XtraEditors.XtraForm
    {
        public frmDistribucion()
        {
            InitializeComponent();
        }

        private void frmDistribucion_Load(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                var Reporte = (from r in Context.Reporte
                               where r.Tipo == 2
                               select new
                               {
                                   Codigo = r.Codigo,
                                   Nombre = r.Descripcion
                               }).ToList();
                gridControl1.DataSource = Reporte;
                gridView1.OptionsBehavior.ReadOnly = true;
                gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.BestFitColumns();
                gridView1.OptionsView.ShowGroupPanel = false;

            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmrepdistribucion = new Reportes.Vistas.frmVistaPrincipal();
            frmrepdistribucion.Show();
        }
    }
}